using System.Text;

namespace BackToBinding.Data
{
    internal class EnumValue : IData
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            builder.Indent(indent);
            builder.Append(Name);
            builder.Append(" = ");
            builder.Append(Value);
            builder.Append(",");
            builder.Line();
        }
    }
}
