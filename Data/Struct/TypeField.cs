using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data.Struct
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
            if(Type.Trim() != "")
            {
                builder.Append(": ");
                builder.Append(BackType.Resolve(Type));
            }
            builder.Append(";");
            builder.Line();
        }
    }
}
