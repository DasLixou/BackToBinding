using BackToBinding.Data.Function;
using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data
{
    internal class DataFunction : IData
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public List<FunctionParameter> Params { get; set; }
        public string Description { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            builder.Indent(indent);
            if(Description != null)
            {
                builder.Documentate(indent, Description);
                builder.Indent(indent);
            }
            // ToDo: dont hardcode raylib
            var dllName = "raylib";
            builder.AppendLine($"@DllImport(\"{dllName}\", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true);");
            builder.Indent(indent);
            builder.Append("public static extern func ");
            builder.Append(Name);
            builder.Append("(");

            builder.Append(ParameterText());

            builder.Append(") -> ");
            builder.Append(BackType.Resolve(ReturnType).Item1);
            builder.Append(";");
            builder.Line();
            builder.Line();
        }

        public string ParameterText()
        {
            if (Params != null && Params.Any())
            {
                string[] prms = new string[Params.Count];
                for (int i = 0; i < prms.Length; i++)
                {
                    var p = Params[i];
                    if (p.Type != "...")
                    {
                        prms[i] = Params[i].AsText();
                    }
                }
                return String.Join(", ", prms);
            }
            return "";
        }
    }
}
