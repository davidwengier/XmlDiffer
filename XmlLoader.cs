using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XmlDiffer
{
    internal class XmlLoader
    {
        private XmlDocument _doc;

        public XmlDocument Document => _doc;

        internal void Load(string fileName)
        {
            _doc = new XmlDocument { XmlResolver = null };
            _doc.Load(fileName);
        }

        internal void Display(TreeView tvw)
        {
            tvw.BeginUpdate();
            tvw.Nodes.Clear();
            var root = tvw.Nodes.Add(GetNodeText(_doc.DocumentElement));
            FormatElementNode(root);
            Display(root, _doc.DocumentElement);
            root.Expand();
            tvw.EndUpdate();
        }

        private void FormatElementNode(TreeNode root)
        {
            root.ImageKey = "element";
        }

        private void FormatAttributeNode(TreeNode root)
        {
            root.ImageKey = "attr";
        }

        private void Display(TreeNode root, XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                var item = root.Nodes.Add(GetNodeText(child));
                FormatElementNode(item);
                if (child.Attributes.Count > 0)
                {
                    var attrs = item.Nodes.Add("Attributes");
                    FormatAttributeNode(attrs);
                    DisplayAttributes(attrs, child);
                }
                Display(item, child);
                item.Expand();
            }
        }

        private void DisplayAttributes(TreeNode attrNode, XmlNode child)
        {
            foreach (XmlAttribute attr in child.Attributes)
            {
                FormatAttributeNode(attrNode.Nodes.Add(GetAttributeText(attr)));
            }
        }

        private static string GetAttributeText(XmlNode attr)
        {
            return $"{attr.Name}=\"{attr.Value}\"";
        }

        private string GetNodeText(XmlNode node)
        {
            var sb = new StringBuilder();
            sb.Append('<');
            sb.Append(node.Name);
            var attr = node.Attributes.GetNamedItem("Name") ?? node.Attributes.GetNamedItem("Description") ?? node.Attributes.GetNamedItem("ID");
            if (attr != null)
            {
                sb.Append(' ');
                sb.Append(GetAttributeText(attr));
            }
            sb.Append('>');
            return sb.ToString();
        }
    }
}