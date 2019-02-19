using System.Drawing;
using XmlDiffer;

namespace XmlDifferTests
{
    internal class TestTreeNodeWrapper : ITreeNode
    {
        public string Text { get; }
        public ITreeNode Parent { get; }
        public Color Color { get;set; }
        public bool HasDifference => this.Color != Color.Empty;

        public TestTreeNodeWrapper(string text, ITreeNode parent)
        {
            this.Text = text;
            this.Parent = parent;
        }
    }
}