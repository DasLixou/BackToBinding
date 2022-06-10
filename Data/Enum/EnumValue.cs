using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data.Enum
{
    internal class EnumValue : IData
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            builder.Indent(indent);
            builder.Append(Name);
            if (Value != null)
            {
                builder.Append(" = ");
                builder.Append(Value);
            }
            builder.Append(",");
            builder.Line();
        }
    }
}
