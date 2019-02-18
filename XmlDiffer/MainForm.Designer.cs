namespace XmlDiffer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnLoadXml1 = new System.Windows.Forms.Button();
            this.tvwLeft = new System.Windows.Forms.TreeView();
            this.btnLoadXml2 = new System.Windows.Forms.Button();
            this.tvwRight = new System.Windows.Forms.TreeView();
            this.imlImages = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadXml1);
            this.splitContainer1.Panel1.Controls.Add(this.tvwLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnLoadXml2);
            this.splitContainer1.Panel2.Controls.Add(this.tvwRight);
            this.splitContainer1.Size = new System.Drawing.Size(1542, 828);
            this.splitContainer1.SplitterDistance = 748;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnLoadXml1
            // 
            this.btnLoadXml1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadXml1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnLoadXml1.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadXml1.Image")));
            this.btnLoadXml1.Location = new System.Drawing.Point(224, 318);
            this.btnLoadXml1.Name = "btnLoadXml1";
            this.btnLoadXml1.Size = new System.Drawing.Size(300, 192);
            this.btnLoadXml1.TabIndex = 1;
            this.btnLoadXml1.Text = "Load File 1";
            this.btnLoadXml1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadXml1.UseVisualStyleBackColor = false;
            this.btnLoadXml1.Click += new System.EventHandler(this.BtnLoadXml1_Click);
            // 
            // tvwLeft
            // 
            this.tvwLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwLeft.ImageIndex = 0;
            this.tvwLeft.ImageList = this.imlImages;
            this.tvwLeft.Location = new System.Drawing.Point(0, 0);
            this.tvwLeft.Name = "tvwLeft";
            this.tvwLeft.SelectedImageIndex = 0;
            this.tvwLeft.Size = new System.Drawing.Size(748, 828);
            this.tvwLeft.TabIndex = 2;
            this.tvwLeft.Visible = false;
            // 
            // btnLoadXml2
            // 
            this.btnLoadXml2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadXml2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnLoadXml2.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadXml2.Image")));
            this.btnLoadXml2.Location = new System.Drawing.Point(255, 318);
            this.btnLoadXml2.Name = "btnLoadXml2";
            this.btnLoadXml2.Size = new System.Drawing.Size(300, 192);
            this.btnLoadXml2.TabIndex = 1;
            this.btnLoadXml2.Text = "Load File 2";
            this.btnLoadXml2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadXml2.UseVisualStyleBackColor = false;
            this.btnLoadXml2.Click += new System.EventHandler(this.BtnLoadXml2_Click);
            // 
            // tvwRight
            // 
            this.tvwRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwRight.ImageIndex = 0;
            this.tvwRight.ImageList = this.imlImages;
            this.tvwRight.Location = new System.Drawing.Point(0, 0);
            this.tvwRight.Name = "tvwRight";
            this.tvwRight.SelectedImageIndex = 0;
            this.tvwRight.Size = new System.Drawing.Size(790, 828);
            this.tvwRight.TabIndex = 2;
            this.tvwRight.Visible = false;
            // 
            // imlImages
            // 
            this.imlImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlImages.ImageStream")));
            this.imlImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imlImages.Images.SetKeyName(0, "attr");
            this.imlImages.Images.SetKeyName(1, "element");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 828);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xml Differ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnLoadXml1;
        private System.Windows.Forms.Button btnLoadXml2;
        private System.Windows.Forms.TreeView tvwLeft;
        private System.Windows.Forms.TreeView tvwRight;
        private System.Windows.Forms.ImageList imlImages;
    }
}

