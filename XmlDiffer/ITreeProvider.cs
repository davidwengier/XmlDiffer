using System.Windows.Forms;

namespace XmlDiffer
{
    public interface ITreeProvider
    {
        ITreeNode AddElement(ITreeNode? current, string text);
        ITreeNode AddAttribute(ITreeNode item, string text);
    }
}