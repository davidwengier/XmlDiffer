﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XmlDiffer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

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
            var loader = new XmlLoader();
            loader.Load(fileName);
            loader.Display(tvw);
            tvw.Tag = loader.Document;
            if (tvwLeft.Tag != null && tvwRight.Tag != null)
            {
                var comparer = new XmlComparer();
                comparer.Compare(tvwLeft, tvwLeft.Tag as XmlDocument, tvwRight, tvwRight.Tag as XmlDocument);
            }
        }
    }
}
