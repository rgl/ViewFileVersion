namespace ViewFileVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.informationLabel = new System.Windows.Forms.LinkLabel();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.topPanel.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.informationLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(488, 30);
            this.topPanel.TabIndex = 1;
            // 
            // informationLabel
            // 
            this.informationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.informationLabel.Image = global::ViewFileVersion.Resource.i;
            this.informationLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.informationLabel.Location = new System.Drawing.Point(0, 0);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Padding = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.informationLabel.Size = new System.Drawing.Size(488, 30);
            this.informationLabel.TabIndex = 3;
            this.informationLabel.TabStop = true;
            this.informationLabel.Text = "Drag binary files into this form to see their File Version.";
            this.informationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.informationLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.informationLabel_LinkClicked);
            // 
            // centerPanel
            // 
            this.centerPanel.Controls.Add(this.treeView);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(0, 30);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(488, 379);
            this.centerPanel.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(488, 379);
            this.treeView.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 409);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "View File Version";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.topPanel.ResumeLayout(false);
            this.centerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.LinkLabel informationLabel;
    }
}

