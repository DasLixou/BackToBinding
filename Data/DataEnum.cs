using System.Text;

namespace BackToBinding.Data
{
    internal class DataEnum : IData
    {
        public string Name { get; set; }

        public List<EnumValue> Values { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            builder.Indent(indent);
            builder.Append("enum " + Name + " {");
            builder.Line();
            Values.ForEach(v => v.AsText(indent + 1, builder));
            builder.Indent(indent);
            builder.Append("}");
            builder.Line();
        }
    }
}
