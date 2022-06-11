using BackToBinding.Data.Function;
using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data
{
    internal class DataFunction : IData
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public List<FunctionParameter> Params { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            builder.Indent(indent);
            builder.Append("func ");
            builder.Append(Name);
            builder.Append("(");
            // TODO: params
            builder.Append(") extern -> ");
            builder.Append(BackType.Resolve(ReturnType));
            builder.Append(";");
            builder.Line();
        }
    }
}
