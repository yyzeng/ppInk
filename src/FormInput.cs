using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gInk
{
    public partial class FormInput : Form
    {
        Microsoft.Ink.Stroke stroke;
        Root Root;
        public FormInput(string caption,string label, string txt, bool ML, gInk.Root rt = null, Microsoft.Ink.Stroke stk = null)
        {
            InitializeComponent();

            // local
            this.btOK.Text = rt.Local.ButtonOkText;
            this.btCancel.Text = rt.Local.ButtonCancelText;
            this.FontBtn.Text = rt.Local.ButtonFontText;

            Text = caption;
            captionLbl.Text = label;
            if (ML)
            {
                InputML.Visible = true;
                InputML.Text = txt;
                ActiveControl = InputML;
            }
            else
            {
                InputSL.Visible = true;
                InputSL.Text = txt;
                ActiveControl = InputSL;
            }
            Root = rt;
            stroke = stk;
            if (stroke == null)
                FontBtn.Visible = false;
            else
            {
                FontBtn.Visible = true;
                FontDlg.Font = new Font((string)stk.ExtendedProperties[Root.TEXTFONT_GUID].Data, (float)stk.ExtendedProperties[Root.TEXTFONTSIZE_GUID].Data,
                                        (System.Drawing.FontStyle)stk.ExtendedProperties[Root.TEXTFONTSTYLE_GUID].Data);
                InputML.TextChanged += new System.EventHandler(this.InputML_TextChanged);
            }
        }

        public void TextIn(string txt)
        {
            if (InputML.Visible)
                InputML.Text=txt;
            else
                InputSL.Text=txt;
        }

        public string TextOut()
        {
            if (InputML.Visible)
                return InputML.Text;
            else
                return InputSL.Text;
        }

        private void FontBtn_Click(object sender, EventArgs e)
        {
            if (FontDlg.ShowDialog() == DialogResult.OK)
            {
                //stroke.ExtendedProperties.Remove(Root.TEXTFONT_GUID);
                //stroke.ExtendedProperties.Remove(Root.TEXTFONTSIZE_GUID);
                //stroke.ExtendedProperties.Remove(Root.TEXTFONTSTYLE_GUID);
                stroke.ExtendedProperties.Add(Root.TEXTFONT_GUID, FontDlg.Font.Name);
                stroke.ExtendedProperties.Add(Root.TEXTFONTSIZE_GUID, (float)FontDlg.Font.Size);
                stroke.ExtendedProperties.Add(Root.TEXTFONTSTYLE_GUID, FontDlg.Font.Style);
                string st=InputML.Text;
                // to run event for refresh
                InputML.Text = "";InputML.Text = st;
            }
        }
        private void InputML_TextChanged(object sender, EventArgs e)
        {
            string t = ((TextBox)sender).Text;
            if (t.Length == 0) t = " ";
            stroke.ExtendedProperties.Remove(Root.TEXT_GUID);
            stroke.ExtendedProperties.Add(Root.TEXT_GUID, t);
            Root.FormDisplay.ClearCanvus();
            Root.FormDisplay.DrawStrokes();
            Root.FormDisplay.UpdateFormDisplay(true);
        }

        private void TB_CtrlAPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(1))
            {
                (sender as TextBox).SelectAll();
                e.Handled = true;
            }

        }
    }
}
