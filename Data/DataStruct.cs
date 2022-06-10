using BackToBinding.Data.Struct;
using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data
{
    public class DataStruct : IData
    {
        public string Name = "";

        public List<TypeField> Fields = new();

        public void AsText(int indent, StringBuilder builder)
        {
            builder.Indent(indent);
            builder.Append("struct " + Name + " {");
            builder.Line();
            Fields.ForEach(f => f.AsText(indent + 1, builder));
            builder.Indent(indent);
            builder.Append("}");
            builder.Line();
        }
    }
}
