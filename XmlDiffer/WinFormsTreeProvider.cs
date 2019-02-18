using System;
using System.Windows.Forms;

namespace XmlDiffer
{
    internal class WinFormsTreeProvider : ITreeProvider
    {
        private readonly TreeView _tvw;

        public WinFormsTreeProvider(TreeView tvw)
        {
            _tvw = tvw;
        }

        public ITreeNode AddAttribute(ITreeNode item, string text)
        {
            TreeNode node;
            if (item is TreeNodeWrapper wrapper)
            {
                if (wrapper.Node.Nodes.Count == 0)
                {
                    wrapper.Node.Nodes.Add("Attributes").ImageKey = "attr";
                    wrapper.Node.Expand();
                }
                node = wrapper.Node.Nodes[0].Nodes.Add(text);
                node.ImageKey = "attr";
                return new TreeNodeWrapper(node);
            }
            throw new InvalidOperationException("This TreeProvider can only work with TreeNodeWrapper instances.");
        }

        public ITreeNode AddElement(ITreeNode? current, string text)
        {
            TreeNode node;
            if (current == null)
            {
                node = _tvw.Nodes.Add(text);
            }
            else if (current is TreeNodeWrapper wrapper)
            {
                node = wrapper.Node.Nodes.Add(text);
                wrapper.Node.Expand();
            }
            else
            {
                throw new InvalidOperationException("This TreeProvider can only work with TreeNodeWrapper instances.");
            }
            node.ImageKey = "element";

            return new TreeNodeWrapper(node);
        }
    }
}