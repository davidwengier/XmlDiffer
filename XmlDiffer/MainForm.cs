using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace XmlDiffer
{
    public partial class MainForm : Form
    {
#nullable disable
        public MainForm()
        {
            InitializeComponent();
        }
#nullable enable

        private void BtnLoadXml1_Click(object sender, EventArgs e)
        {
            AskForAndLoadXmlFile(btnLoadXml1, tvwLeft);
        }
        private void BtnLoadXml2_Click(object sender, EventArgs e)
        {
            AskForAndLoadXmlFile(btnLoadXml2, tvwRight);
        }

        private void AskForAndLoadXmlFile(Button btn, TreeView tvw)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "XML Files|*.xml;*.xaml|All Files|*.*";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadXmlFile(btn, tvw, dlg.FileName);
                }
            }
        }

        private void LoadXmlFile(Button button, TreeView tvw, string fileName)
        {
            if (button != null)
            {
                button.Visible = false;
            }

            tvw.Visible = true;
            tvw.Tag = null;
            tvw.BeginUpdate();
            tvw.Nodes.Clear();
            var loader = new XmlLoader(fileName, new WinFormsTreeProvider(tvw));
            tvw.EndUpdate();
            tvw.Tag = loader;
            if (tvwLeft.Tag is XmlLoader loaderLeft && tvwRight.Tag is XmlLoader loaderRight)
            {
                var comparer = new XmlComparer();
                comparer.Compare(loaderLeft.RootElement, loaderLeft.NodeMappings, loaderRight.RootElement, loaderRight.NodeMappings);
            }
        }
    }
}

