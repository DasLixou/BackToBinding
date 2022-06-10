using BackToBinding.Utils;

namespace BackToBinding.Data
{
    internal class DataAlias
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public void Resolve()
        {
            BackType.AddAlias(Type, Name);
        }
    }
}
