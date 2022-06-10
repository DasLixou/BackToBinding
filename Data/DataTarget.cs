using System.Text;

namespace BackToBinding.Data
{
    internal class DataTarget : IData
    {
        public List<DataStruct> Structs { get; set; }
        public List<DataEnum> Enums { get; set; }

        public void AsText(int indent, StringBuilder builder)
        {
            Structs.ForEach(st => {
                st.AsText(indent, builder);
                builder.Line();
                });
            Enums.ForEach(e => {
                e.AsText(indent, builder);
                builder.Line();
            });
        }
    }
}
