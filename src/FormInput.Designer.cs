namespace gInk
{
    partial class FormInput
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
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.InputML = new System.Windows.Forms.TextBox();
            this.InputSL = new System.Windows.Forms.TextBox();
            this.captionLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Location = new System.Drawing.Point(313, 125);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 42);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "&OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(394, 125);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 42);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "&Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // InputML
            // 
            this.InputML.AcceptsReturn = true;
            this.InputML.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputML.Location = new System.Drawing.Point(18, 26);
            this.InputML.Multiline = true;
            this.InputML.Name = "InputML";
            this.InputML.Size = new System.Drawing.Size(450, 93);
            this.InputML.TabIndex = 2;
            this.InputML.Text = "inputML\r\nline2";
            this.InputML.Visible = false;
            // 
            // InputSL
            // 
            this.InputSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputSL.Location = new System.Drawing.Point(18, 62);
            this.InputSL.Name = "InputSL";
            this.InputSL.Size = new System.Drawing.Size(450, 26);
            this.InputSL.TabIndex = 3;
            this.InputSL.Text = "inputSL";
            this.InputSL.Visible = false;
            // 
            // captionLbl
            // 
            this.captionLbl.AutoSize = true;
            this.captionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captionLbl.Location = new System.Drawing.Point(15, 10);
            this.captionLbl.Name = "captionLbl";
            this.captionLbl.Size = new System.Drawing.Size(45, 16);
            this.captionLbl.TabIndex = 4;
            this.captionLbl.Text = "label1";
            // 
            // FormInput
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(481, 179);
            this.Controls.Add(this.captionLbl);
            this.Controls.Add(this.InputSL);
            this.Controls.Add(this.InputML);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInput";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        public  System.Windows.Forms.TextBox InputML;
        public  System.Windows.Forms.TextBox InputSL;
        public  System.Windows.Forms.Label captionLbl;
    }
}