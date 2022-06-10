using System.Text;

namespace BackToBinding.Data
{
    public class TypeField : IData
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            builder.Indent(indent);
            builder.Append("let ");
            builder.Append(Name);
            builder.Append(";");
            builder.Line();
        }
    }
}
