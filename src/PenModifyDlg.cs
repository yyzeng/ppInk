using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gInk
{
    public partial class PenModifyDlg : Form
    {
        Root Root;

        public PenModifyDlg(Root root)
        {
            Root = root;
            InitializeComponent();
            OkBtn.Text = Root.Local.ButtonOkText;
            CancelBtn.Text = Root.Local.ButtonCancelText;
            this.Text = Root.Local.OptionsHotkeysColorEdit;
            string sin = Root.Local.OptionsPensFading;
            int i = sin.IndexOf("(");
            if (i < 0) i = sin.Length;
            FadingCB.Text = sin.Substring(0, i);
            DashStyleGrp.Text = Root.Local.OptionsLineStyle;
        }

        public void setColor(int alpha,Color c)
        {
            colorEditorManager.Color = Color.FromArgb(255-alpha, c);
        }

        public int getAlpha()
        {
            return 255-colorEditorManager.Color.A;
        }

        public Color getColor()
        {
            return colorEditorManager.Color;
        }

        public void setWidth(float w)
        {
            pboxPenWidthIndicator.Left = (int)(Math.Sqrt(w / 1250)* 200);
        }

        public float getWidth()
        {
            double f = (pboxPenWidthIndicator.Left/ 200.0);
            return (float)(f * f * 1250);
        }

        public void setDashStyle(Microsoft.Ink.DrawingAttributes pen)
        {
            if (!pen.ExtendedProperties.Contains(Root.DASHED_LINE_GUID))
                StyleStrokeRd.Checked = true;
            else
            switch((DashStyle)(pen.ExtendedProperties[Root.DASHED_LINE_GUID].Data))
            {
                case DashStyle.Solid:
                    StyleSolidRd.Checked = true;
                    break;
                case DashStyle.Dash:
                    StyleDashRd.Checked = true;
                    break;
                case DashStyle.Dot:
                    StyleDotRd.Checked = true;
                    break;
                case DashStyle.DashDot:
                    StyleDashDotRd.Checked = true;
                    break;
                case DashStyle.DashDotDot:
                    StyleDashDotDotRd.Checked = true;
                    break;
            }

        }

        public DashStyle getDashStyle()
        {

            if (StyleStrokeRd.Checked)
                return DashStyle.Custom; // temporary means stroke
            else if (StyleSolidRd.Checked)
                return DashStyle.Solid;
            else if (StyleDashRd.Checked)
                return DashStyle.Dash;
            else if (StyleDotRd.Checked)
                return DashStyle.Dot;
            else if (StyleDashDotRd.Checked)
                return DashStyle.DashDot;
            else if (StyleDashDotDotRd.Checked)
                return DashStyle.DashDotDot;
            else
                throw (new Exception("can not identify DashStyle"));
        }

        public bool ModifyPen(ref Microsoft.Ink.DrawingAttributes pen)
        {
            setColor(pen.Transparency, pen.Color);
            setWidth(pen.Width);
            FadingCB.Checked = pen.ExtendedProperties.Contains(Root.FADING_PEN);
            setDashStyle(pen);
            if (ShowDialog() == DialogResult.OK)
            {
                pen.Color = getColor();
                pen.Transparency = (byte)getAlpha();
                pen.Width = getWidth();
                if (FadingCB.Checked)
                    pen.ExtendedProperties.Add(Root.FADING_PEN, Root.TimeBeforeFading);
                else
                    try { pen.ExtendedProperties.Remove(Root.FADING_PEN); } catch { };
                DashStyle d = getDashStyle();
                if (d == DashStyle.Custom)
                    try { pen.ExtendedProperties.Remove(Root.DASHED_LINE_GUID); } catch { }
                else
                    pen.ExtendedProperties.Add(Root.DASHED_LINE_GUID, d);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void hideWidth()
        {
            pboxPenWidthIndicator.Visible = false;
            gpPenWidth.BackgroundImage = null;
            //gpPenWidth.Visible = false;
            //previewPanel.Visible = false;
            DashStyleGrp.Visible = false;
        }

        /// inspired from FormCollection
        bool gpPenWidth_MouseOn;
        private void gpPenWidth_MouseDown(object sender, MouseEventArgs e)
        {
            gpPenWidth_MouseOn = true;
        }

        private void gpPenWidth_MouseMove(object sender, MouseEventArgs e)
        {
            if (!gpPenWidth_MouseOn)
                return;
            if (e.X < pboxPenWidthIndicator.Width/2)
                pboxPenWidthIndicator.Left = 0;
            else if (e.X > (gpPenWidth.Width - pboxPenWidthIndicator.Width/2))
                pboxPenWidthIndicator.Left = (gpPenWidth.Width - pboxPenWidthIndicator.Width/2);
            else
                pboxPenWidthIndicator.Left = e.X - pboxPenWidthIndicator.Width / 2;
        }

        private void gpPenWidth_MouseUp(object sender, MouseEventArgs e)
        {
            gpPenWidth_MouseMove(sender, e);
            gpPenWidth_MouseOn = false;
        }

        private void pboxPenWidthIndicator_MouseDown(object sender, MouseEventArgs e)
        {
            gpPenWidth_MouseOn = true;
        }

        private void pboxPenWidthIndicator_MouseMove(object sender, MouseEventArgs e)
        {
            if (gpPenWidth_MouseOn)
                gpPenWidth_MouseMove(sender, new MouseEventArgs(e.Button, e.Clicks, e.X + (sender as Control).Left, e.Y, e.Delta));
        }

        private void pboxPenWidthIndicator_MouseUp(object sender, MouseEventArgs e)
        {
            gpPenWidth_MouseOn = false;
        }

        private void colorEditorManager_ColorChanged(object sender, EventArgs e)
        {
           gpPenWidth.BackColor = colorEditorManager.Color;
        }

    }
}
