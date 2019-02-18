using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XmlDiffer
{
    public class XmlLoader
    {
        private readonly Dictionary<XmlNode, ITreeNode> _nodeMappings = new Dictionary<XmlNode, ITreeNode>();

        public Dictionary<XmlNode, ITreeNode> NodeMappings => _nodeMappings;

        public XmlNode RootElement { get; internal set; }

        public XmlLoader(string fileName, ITreeProvider tvw)
        {
            var doc = new XmlDocument { XmlResolver = null };
            doc.Load(fileName);

            this.RootElement = doc.DocumentElement;
            AddNode(tvw, null, doc.DocumentElement);
        }

        private void AddNode(ITreeProvider tvw, ITreeNode? current, XmlNode xmlNode)
        {
            var item = tvw.AddElement(current, GetNodeText(xmlNode));
            _nodeMappings[xmlNode] = item;
            if (xmlNode.Attributes.Count > 0)
            {
                DisplayAttributes(tvw, item, xmlNode);
            }
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                AddNode(tvw, item, childNode);
            }
        }

        private void DisplayAttributes(ITreeProvider tvw, ITreeNode item, XmlNode child)
        {
            foreach (XmlAttribute attr in child.Attributes)
            {
                var node = tvw.AddAttribute(item, GetAttributeText(attr));
                _nodeMappings[attr] = node;
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