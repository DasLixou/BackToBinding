using System.Text;

namespace BackToBinding
{
    public static class StringBuilderExtension
    {
        public static void Indent(this StringBuilder builder, int indent)
        {
            builder.Append(new string('\t', indent));
        }

        public static void Line(this StringBuilder builder)
        {
            builder.AppendLine("");
        }
    }
}
