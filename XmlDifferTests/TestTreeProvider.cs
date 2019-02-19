using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XmlDiffer;

namespace XmlDifferTests
{
    internal class TestTreeProvider : ITreeProvider
    {
        public List<TestTreeNodeWrapper> Attributes { get; } = new List<TestTreeNodeWrapper>();
        public List<TestTreeNodeWrapper> Elements { get; } = new List<TestTreeNodeWrapper>();
        public bool HasDifferences => this.Elements.Any(n => n.HasDifference);

        public ITreeNode AddAttribute(ITreeNode item, string text)
        {
            var node = new TestTreeNodeWrapper(text, item);
            this.Attributes.Add(node);
            return node;
        }

        public ITreeNode AddElement(ITreeNode item, string text)
        {
            var node = new TestTreeNodeWrapper(text, item);
            this.Elements.Add(node);
            return node;
        }
    }
}