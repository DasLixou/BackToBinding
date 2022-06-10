using System.Text;

namespace BackToBinding.Utils
{
    public interface IData
    {
        public void AsText(int indent, StringBuilder builder);
    }
}
