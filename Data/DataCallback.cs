using BackToBinding.Data.Function;
using BackToBinding.Data.Struct;
using BackToBinding.Utils;
using System.Text;

namespace BackToBinding.Data
{
    internal class DataCallback
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReturnType { get; set; }
        public List<FunctionParameter> Params { get; set; }

        public string ParameterText()
        {
            if (Params != null && Params.Any())
            {
                string[] prms = new string[Params.Count];
                for (int i = 0; i < prms.Length; i++)
                {
                    var p = Params[i];
                    if (p.Type != "...")
                    {
                        prms[i] = Params[i].AsText();
                    }
                }
                return String.Join(", ", prms);
            }
            return "";
        }
    }
}
