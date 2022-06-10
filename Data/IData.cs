using System.Text;

namespace BackToBinding.Data
{
    public interface IData
    {
        public void AsText(int indent, StringBuilder builder);
    }
}
