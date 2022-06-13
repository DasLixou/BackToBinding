using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data.Struct
{
    internal class TypeField : IData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            var type = BackType.Resolve(Type);

            builder.Indent(indent);
            if (Description != null)
            {
                builder.Documentate(indent, Description);
                builder.Indent(indent);
            }
            builder.Append("let ");
            if(!type.Item2) // negate const
            {
                builder.Append("mut ");
            }
            builder.Append(Name);
            if(Type.Trim() != "")
            {
                builder.Append(": ");
                builder.Append(type.Item1);
            }
            builder.Append(";");
            builder.Line();
            builder.Line();
        }
    }
}
