namespace gInk
{
    partial class PenModifyDlg
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
            this.lightnessColorSlider = new Cyotek.Windows.Forms.LightnessColorSlider();
            this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
            this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
            this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.gpPenWidth = new System.Windows.Forms.Panel();
            this.pboxPenWidthIndicator = new System.Windows.Forms.PictureBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FadingCB = new System.Windows.Forms.CheckBox();
            this.previewPanel.SuspendLayout();
            this.gpPenWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPenWidthIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lightnessColorSlider
            // 
            this.lightnessColorSlider.Location = new System.Drawing.Point(203, 12);
            this.lightnessColorSlider.Name = "lightnessColorSlider";
            this.lightnessColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.lightnessColorSlider.Size = new System.Drawing.Size(33, 182);
            this.lightnessColorSlider.TabIndex = 27;
            // 
            // screenColorPicker
            // 
            this.screenColorPicker.Color = System.Drawing.Color.Black;
            this.screenColorPicker.Cursor = System.Windows.Forms.Cursors.Default;
            this.screenColorPicker.Location = new System.Drawing.Point(120, 291);
            this.screenColorPicker.Name = "screenColorPicker";
            this.screenColorPicker.Size = new System.Drawing.Size(84, 65);
            this.screenColorPicker.Zoom = 6;
            // 
            // colorWheel
            // 
            this.colorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel.Location = new System.Drawing.Point(12, 12);
            this.colorWheel.Name = "colorWheel";
            this.colorWheel.Size = new System.Drawing.Size(184, 182);
            this.colorWheel.TabIndex = 24;
            // 
            // colorEditor
            // 
            this.colorEditor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorEditor.Location = new System.Drawing.Point(319, 12);
            this.colorEditor.Name = "colorEditor";
            this.colorEditor.Size = new System.Drawing.Size(261, 236);
            this.colorEditor.TabIndex = 23;
            // 
            // colorGrid
            // 
            this.colorGrid.AutoAddColors = false;
            this.colorGrid.CellBorderStyle = Cyotek.Windows.Forms.ColorCellBorderStyle.None;
            this.colorGrid.EditMode = Cyotek.Windows.Forms.ColorEditingMode.Both;
            this.colorGrid.Location = new System.Drawing.Point(12, 201);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(0);
            this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Paint;
            this.colorGrid.SelectedCellStyle = Cyotek.Windows.Forms.ColorGridSelectedCellStyle.Standard;
            this.colorGrid.ShowCustomColors = false;
            this.colorGrid.Size = new System.Drawing.Size(192, 72);
            this.colorGrid.Spacing = new System.Drawing.Size(0, 0);
            this.colorGrid.TabIndex = 25;
            // 
            // previewPanel
            // 
            this.previewPanel.BackgroundImage = global::gInk.Properties.Resources.cellbackground;
            this.previewPanel.Controls.Add(this.gpPenWidth);
            this.previewPanel.Location = new System.Drawing.Point(347, 254);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(200, 53);
            this.previewPanel.TabIndex = 26;
            // 
            // gpPenWidth
            // 
            this.gpPenWidth.BackColor = System.Drawing.Color.Transparent;
            this.gpPenWidth.BackgroundImage = global::gInk.Properties.Resources.penwidthpanel;
            this.gpPenWidth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gpPenWidth.Controls.Add(this.pboxPenWidthIndicator);
            this.gpPenWidth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpPenWidth.Location = new System.Drawing.Point(0, 0);
            this.gpPenWidth.Name = "gpPenWidth";
            this.gpPenWidth.Size = new System.Drawing.Size(200, 53);
            this.gpPenWidth.TabIndex = 30;
            this.gpPenWidth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpPenWidth_MouseDown);
            this.gpPenWidth.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpPenWidth_MouseMove);
            this.gpPenWidth.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpPenWidth_MouseUp);
            // 
            // pboxPenWidthIndicator
            // 
            this.pboxPenWidthIndicator.BackColor = System.Drawing.Color.Orange;
            this.pboxPenWidthIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxPenWidthIndicator.Location = new System.Drawing.Point(0, 0);
            this.pboxPenWidthIndicator.Name = "pboxPenWidthIndicator";
            this.pboxPenWidthIndicator.Size = new System.Drawing.Size(5, 53);
            this.pboxPenWidthIndicator.TabIndex = 5;
            this.pboxPenWidthIndicator.TabStop = false;
            this.pboxPenWidthIndicator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pboxPenWidthIndicator_MouseDown);
            this.pboxPenWidthIndicator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pboxPenWidthIndicator_MouseMove);
            this.pboxPenWidthIndicator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pboxPenWidthIndicator_MouseUp);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(472, 344);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 28;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // OkBtn
            // 
            this.OkBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBtn.Location = new System.Drawing.Point(352, 344);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 24);
            this.OkBtn.TabIndex = 29;
            this.OkBtn.Text = "&OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            // 
            // colorEditorManager
            // 
            this.colorEditorManager.ColorEditor = this.colorEditor;
            this.colorEditorManager.ColorGrid = this.colorGrid;
            this.colorEditorManager.ColorWheel = this.colorWheel;
            this.colorEditorManager.LightnessColorSlider = this.lightnessColorSlider;
            this.colorEditorManager.ScreenColorPicker = this.screenColorPicker;
            this.colorEditorManager.ColorChanged += new System.EventHandler(this.colorEditorManager_ColorChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::gInk.Properties.Resources.eyedropper;
            this.pictureBox1.Location = new System.Drawing.Point(73, 291);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 35);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // FadingCB
            // 
            this.FadingCB.AutoSize = true;
            this.FadingCB.Location = new System.Drawing.Point(347, 321);
            this.FadingCB.Name = "FadingCB";
            this.FadingCB.Size = new System.Drawing.Size(58, 17);
            this.FadingCB.TabIndex = 32;
            this.FadingCB.Text = "Fading";
            this.FadingCB.UseVisualStyleBackColor = true;
            // 
            // PenModifyDlg
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(591, 379);
            this.Controls.Add(this.FadingCB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.lightnessColorSlider);
            this.Controls.Add(this.screenColorPicker);
            this.Controls.Add(this.colorWheel);
            this.Controls.Add(this.colorEditor);
            this.Controls.Add(this.colorGrid);
            this.Controls.Add(this.previewPanel);
            this.Name = "PenModifyDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pen Adjustment";
            this.TopMost = true;
            this.previewPanel.ResumeLayout(false);
            this.gpPenWidth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxPenWidthIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cyotek.Windows.Forms.LightnessColorSlider lightnessColorSlider;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker;
        private Cyotek.Windows.Forms.ColorWheel colorWheel;
        private Cyotek.Windows.Forms.ColorGrid colorGrid;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        public System.Windows.Forms.Panel gpPenWidth;
        private System.Windows.Forms.PictureBox pboxPenWidthIndicator;
        public Cyotek.Windows.Forms.ColorEditorManager colorEditorManager;
        public Cyotek.Windows.Forms.ColorEditor colorEditor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox FadingCB;
    }
}