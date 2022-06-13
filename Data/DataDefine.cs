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

        public void AsText(int indent, StringBuilder builder)
        {
            if (Type == "GUARD") return;
            if (Type == "MACRO")
            {
                Macros.Add(new MacroDefinition(Name, Value));
                return;
            }
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
                case "COLOR":
                    {
                        // FOR DEBUGGING REASONS HARDCODED
                        var newValue = Macros.Find(_ => _.Name == "CLITERAL(type)").Resolve(Value);
                        text = $"let {Name} = {newValue};";
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
