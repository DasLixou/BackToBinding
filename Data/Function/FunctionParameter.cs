using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data.Function
{
    internal class FunctionParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public string AsText()
        {
            return Name + ": " + BackType.Resolve(Type).Item1;
        }
    }
}
