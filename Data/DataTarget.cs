using System.Text;

namespace BackToBinding.Data
{
    internal class DataTarget : IData
    {
        public List<DataStruct> Structs { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            Structs.ForEach(st => {
                st.AsText(indent, builder);
                builder.Line();
                });
        }
    }
}
