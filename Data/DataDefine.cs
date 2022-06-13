using BackToBinding.Data.Define;
using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data
{
    internal class DataDefine : IData
    {
        private static List<MacroDefinition> Macros = new();

        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public void Resolve()
        {
            if (Type == "MACRO")
            {
                Macros.Add(new MacroDefinition(Name, Value));
                return;
            }
        }

        public void AsText(int indent, StringBuilder builder)
        {
            if (Type == "GUARD" || Type == "MACRO") return;
            builder.Indent(indent);
            var text = $"// ! INVALID TYPE '{Type}' IN VARIABLE '{Name}' WITH VALUE '{Value}' !";
            switch(Type)
            {
                case "STRING":
                    {
                        text = String();
                        break;
                    }
                case "FLOAT":
                case "FLOAT_MATH":
                    {
                        text = Float();
                        break;
                    }
                case "UNKNOWN":
                    {
                        var enumClass = Program.target.Enums.FirstOrDefault(_ => _.Values.Any(entry => entry.Name == Value));
                        if(enumClass != null)
                        {
                            var enumValue = enumClass.Values.Find(_ => _.Name == Value);
                            text = $"let {Name}: {enumClass.Name} = {enumClass.Name}.{enumValue.Name};";
                        }
                        break;
                    }
                default:
                    {
                        var openParen = Value.IndexOf('(');
                        var macroName = Value.Substring(0, openParen);
                        var macro = Macros.FirstOrDefault(_ => _.StrippedName == macroName);
                        if (macro != null)
                        {
                            var macroValue = macro.Resolve(Value);
                            var closeParen = Value.IndexOf(')');
                            if(closeParen != Value.Length - 1)
                            {
                                var appendValue = Value.Substring(closeParen + 1);
                                if(appendValue.StartsWith("{"))
                                {
                                    // make constructor
                                    var stringPrms = appendValue.Replace("{", "").Replace("}", "").Replace(" ", "");
                                    var constructorPrms = stringPrms.Split(",");
                                    appendValue = "::new(" + string.Join(", ", constructorPrms) + ")";
                                }
                                macroValue = macroValue + appendValue;
                            }
                            text = $"let {Name} = {macroValue};";
                        }
                        break;
                    }
            }
            builder.AppendLine(text);
            builder.Line();
        }

        private string String() => $"let {Name}: string = \"{Value}\";";
        private string Float() => $"let {Name}: f32 = {Value};";
    }
}
