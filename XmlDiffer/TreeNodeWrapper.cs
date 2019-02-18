using System.Drawing;
using System.Windows.Forms;

namespace XmlDiffer
{
    internal class TreeNodeWrapper : ITreeNode
    {
        public TreeNode Node { get; }

        public TreeNodeWrapper(TreeNode node)
        {
            this.Node = node;
        }

        public Color Color
        {
            get { return this.Node.BackColor; }
            set { this.Node.BackColor = value; }
        }
    }
}