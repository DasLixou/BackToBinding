using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data.Function
{
    internal class FunctionParameter : IData
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
