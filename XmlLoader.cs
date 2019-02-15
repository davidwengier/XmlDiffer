using System;
using System.Windows.Forms;
using System.Xml;

namespace XmlDiffer
{
    internal class XmlLoader
    {
        private XmlDocument _doc;

        internal void Load(string fileName)
        {
            _doc = new XmlDocument { XmlResolver = null };
            _doc.Load(fileName);
        }

        internal void Display(TreeView tvw)
        {
            tvw.BeginUpdate();
            tvw.Nodes.Clear();
            var root = tvw.Nodes.Add(_doc.DocumentElement.Name);
            Display(root, _doc.DocumentElement);
            tvw.EndUpdate();
        }

        private void Display(TreeNode root, XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                var item = root.Nodes.Add(node.Name);
                Display(item, child);
            }
        }
    }
}