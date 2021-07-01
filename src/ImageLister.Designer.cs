namespace gInk
{
    partial class ImageLister
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
            this.ImageListViewer = new System.Windows.Forms.ListView();
            this.Images = new System.Windows.Forms.ImageList(this.components);
            this.CancelBtn = new System.Windows.Forms.Button();
            this.InsertBtn = new System.Windows.Forms.Button();
            this.FromClpBtn = new System.Windows.Forms.Button();
            this.LoadImageBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.FillingCombo = new System.Windows.Forms.ComboBox();
            this.AutoCloseCb = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ImageListViewer
            // 
            this.ImageListViewer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ImageListViewer.GridLines = true;
            this.ImageListViewer.HideSelection = false;
            this.ImageListViewer.LargeImageList = this.Images;
            this.ImageListViewer.Location = new System.Drawing.Point(2, 3);
            this.ImageListViewer.MultiSelect = false;
            this.ImageListViewer.Name = "ImageListViewer";
            this.ImageListViewer.ShowGroups = false;
            this.ImageListViewer.Size = new System.Drawing.Size(795, 344);
            this.ImageListViewer.TabIndex = 0;
            this.ImageListViewer.UseCompatibleStateImageBehavior = false;
            this.ImageListViewer.DoubleClick += new System.EventHandler(this.InsertBtn_Click);
            // 
            // Images
            // 
            this.Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.Images.ImageSize = new System.Drawing.Size(16, 16);
            this.Images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CancelBtn
            // 
            this.CancelBtn.AllowDrop = true;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(719, 353);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // InsertBtn
            // 
            this.InsertBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.InsertBtn.Location = new System.Drawing.Point(638, 353);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(75, 23);
            this.InsertBtn.TabIndex = 2;
            this.InsertBtn.Text = "&Insert";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // FromClpBtn
            // 
            this.FromClpBtn.Location = new System.Drawing.Point(17, 353);
            this.FromClpBtn.Name = "FromClpBtn";
            this.FromClpBtn.Size = new System.Drawing.Size(102, 23);
            this.FromClpBtn.TabIndex = 3;
            this.FromClpBtn.Text = "&From Clipboard";
            this.FromClpBtn.UseVisualStyleBackColor = true;
            this.FromClpBtn.Click += new System.EventHandler(this.FromClipB_Click);
            // 
            // LoadImageBtn
            // 
            this.LoadImageBtn.Location = new System.Drawing.Point(125, 353);
            this.LoadImageBtn.Name = "LoadImageBtn";
            this.LoadImageBtn.Size = new System.Drawing.Size(102, 23);
            this.LoadImageBtn.TabIndex = 4;
            this.LoadImageBtn.Text = "Load Image";
            this.LoadImageBtn.UseVisualStyleBackColor = true;
            this.LoadImageBtn.Click += new System.EventHandler(this.LoadImageBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Location = new System.Drawing.Point(233, 353);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(75, 23);
            this.DelBtn.TabIndex = 5;
            this.DelBtn.Text = "Delete";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // FillingCombo
            // 
            this.FillingCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FillingCombo.FormattingEnabled = true;
            this.FillingCombo.Items.AddRange(new object[] {
            "No Frame",
            "Empty",
            "Color Filled",
            "White Filled",
            "Black Filled"});
            this.FillingCombo.Location = new System.Drawing.Point(438, 353);
            this.FillingCombo.MaxDropDownItems = 5;
            this.FillingCombo.Name = "FillingCombo";
            this.FillingCombo.Size = new System.Drawing.Size(121, 21);
            this.FillingCombo.TabIndex = 7;
            // 
            // AutoCloseCb
            // 
            this.AutoCloseCb.AutoSize = true;
            this.AutoCloseCb.Checked = true;
            this.AutoCloseCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoCloseCb.Location = new System.Drawing.Point(581, 353);
            this.AutoCloseCb.Name = "AutoCloseCb";
            this.AutoCloseCb.Size = new System.Drawing.Size(51, 30);
            this.AutoCloseCb.TabIndex = 8;
            this.AutoCloseCb.Text = "Auto\r\nclose";
            this.AutoCloseCb.UseVisualStyleBackColor = true;
            this.AutoCloseCb.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ImageLister
            // 
            this.AcceptButton = this.InsertBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(800, 383);
            this.Controls.Add(this.AutoCloseCb);
            this.Controls.Add(this.FillingCombo);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.LoadImageBtn);
            this.Controls.Add(this.FromClpBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ImageListViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "ImageLister";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageLister_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ImageList Images;
        public System.Windows.Forms.ListView ImageListViewer;
        public System.Windows.Forms.Button CancelBtn;
        public System.Windows.Forms.Button InsertBtn;
        public System.Windows.Forms.Button FromClpBtn;
        public System.Windows.Forms.Button LoadImageBtn;
        public System.Windows.Forms.Button DelBtn;
        public System.Windows.Forms.ComboBox FillingCombo;
        public System.Windows.Forms.CheckBox AutoCloseCb;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}