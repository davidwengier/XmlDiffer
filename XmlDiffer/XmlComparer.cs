using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XmlDiffer
{
    public class XmlComparer
    {
        private readonly HashSet<XmlNode> _seenNodes = new HashSet<XmlNode>();

        public void Compare(XmlNode xmlNode1, Dictionary<XmlNode, ITreeNode> xmlLeft, XmlNode xmlNode2, Dictionary<XmlNode, ITreeNode> xmlRight)
        {
            if (!xmlNode1.Name.Equals(xmlNode2.Name, StringComparison.OrdinalIgnoreCase))
            {
                xmlLeft[xmlNode1].Color = Color.Red;
            }

            CompareAttributes(xmlNode1, xmlLeft, xmlNode2, xmlRight);

            CompareChildren(xmlNode1.ChildNodes, xmlLeft, xmlNode2.ChildNodes, xmlRight);
        }

        private void CompareChildren(XmlNodeList xmlNodes1, Dictionary<XmlNode, ITreeNode> xmlLeft, XmlNodeList xmlNodes2, Dictionary<XmlNode, ITreeNode> xmlRight)
        {
            int i;
            for (i = 0; i < xmlNodes1.Count; i++)
            {
                var node = xmlNodes1[i];
                var other = AggressivelyFindNode(node, xmlNodes2, i);
                if (other == null)
                {
                    xmlLeft[xmlNodes1[i]].Color = Color.Green;
                    break;
                }
                else
                {
                    Compare(xmlNodes1[i], xmlLeft, xmlNodes2[i], xmlRight);
                }
            }

            foreach (XmlNode child in xmlNodes2)
            {
                if (!_seenNodes.Contains(child))
                {
                    xmlRight[child].Color = Color.Green;
                }
            }
        }

        private XmlNode? AggressivelyFindNode(XmlNode node, XmlNodeList xmlNodes2, int i)
        {
            XmlNode? imperfectMatch = null;
            foreach (XmlNode other in xmlNodes2)
            {
                if (_seenNodes.Contains(other)) continue;

                if (!other.Name.Equals(node.Name, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                if (other.Attributes.Count != node.Attributes.Count)
                {
                    continue;
                }

                bool allMatch = true;
                foreach (XmlAttribute attr in node.Attributes)
                {
                    var otherAttr = other.Attributes.Cast<XmlAttribute>().FirstOrDefault(a => a.Name.Equals(attr.Name));
                    if (otherAttr == null)
                    {
                        allMatch = false;
                        break;
                    }
                }
                if (allMatch)
                {
                    return other;
                }
                else
                {
                    var attr = node.Attributes.GetNamedItem("Name") ?? node.Attributes.GetNamedItem("Description") ?? node.Attributes.GetNamedItem("ID");
                    var attr2 = other.Attributes.GetNamedItem("Name") ?? other.Attributes.GetNamedItem("Description") ?? other.Attributes.GetNamedItem("ID");
                    if (attr != null && attr2 != null && attr.Value.Equals(attr2.Value, StringComparison.OrdinalIgnoreCase))
                    {
                        imperfectMatch = other;
                    }
                }
            }
            if (imperfectMatch != null)
            {
                _seenNodes.Add(imperfectMatch);
                return imperfectMatch;
            }


            while (i < xmlNodes2.Count)
            {
                var child = xmlNodes2[i];
                if (_seenNodes.Contains(child))
                {
                    _seenNodes.Add(child);
                    return child;
                }
                i++;
            }

            return null;
        }

        private static void CompareAttributes(XmlNode xmlNode1, Dictionary<XmlNode, ITreeNode> xmlLeft, XmlNode xmlNode2, Dictionary<XmlNode, ITreeNode> xmlRight)
        {
            foreach (XmlAttribute attr in xmlNode1.Attributes)
            {
                var otherAttr = xmlNode2.Attributes.Cast<XmlAttribute>().FirstOrDefault(a => a.Name.Equals(attr.Name));
                if (otherAttr == null)
                {
                    xmlLeft[attr].Color = Color.Green;
                    xmlLeft[xmlNode1].Color = Color.Red;
                }
                else if (!attr.Value.Equals(otherAttr.Value, StringComparison.OrdinalIgnoreCase))
                {
                    xmlLeft[attr].Color = Color.Red;
                    xmlLeft[xmlNode1].Color = Color.Red;
                    xmlRight[otherAttr].Color = Color.Red;
                    xmlRight[xmlNode2].Color = Color.Red;
                }
            }

            foreach (XmlAttribute attr in xmlNode2.Attributes)
            {
                var otherAttr = xmlNode1.Attributes.Cast<XmlAttribute>().FirstOrDefault(a => a.Name.Equals(attr.Name));
                if (otherAttr == null)
                {
                    xmlRight[attr].Color = Color.Green;
                    xmlRight[xmlNode2].Color = Color.Red;
                }
            }
        }
    }
}