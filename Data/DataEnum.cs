using BackToBinding.Data.Enum;
using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data
{
    internal class DataEnum : IData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EnumValue> Values { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            BackType.Register(Name);

            builder.Indent(indent);
            if (Description != null)
            {
                builder.Documentate(indent, Description);
                builder.Indent(indent);
            }
            builder.Append("enum " + Name + " {");
            builder.Line();
            Values.ForEach(v => v.AsText(indent + 1, builder));
            builder.Indent(indent);
            builder.Append("}");
            builder.Line();
        }
    }
}
