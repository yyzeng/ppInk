using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Ink;

namespace gInk
{
    public partial class ArrowSelDlg : Form
    {
        Root Root;
        string ArrowHead;
        string ArrowTail;
        Stroke EditStroke=null;
        public ArrowSelDlg(Root r)
        {
            Root = r;
            InitializeComponent();
            PrevBtn.Text = Root.Local.ButtonPrevText;
            NextBtn.Text = Root.Local.ButtonNextText;
            AddBtn.Text = Root.Local.ButtonAddText;
            DelBtn.Text = Root.Local.ButtonDelText;
            QuitBtn.Text = Root.Local.ButtonExitText;
            SaveBtn.Text = Root.Local.ButtonSaveText;
            Initialize();
        }

        public void Initialize(Stroke st=null)
        {
            ArrowHead_Pnl.BackgroundImage?.Dispose();
            ArrowTail_Pnl.BackgroundImage?.Dispose();
            if (st!=null)
            {
                EditStroke = st;
                ArrowHead = (string)st.ExtendedProperties[Root.ARROWSTART_FN_GUID].Data;
                ArrowTail = (string)st.ExtendedProperties[Root.ARROWEND_FN_GUID].Data;
                PrevBtn.Visible = false;
                NextBtn.Visible = false;
                AddBtn.Visible = false;
                DelBtn.Visible = false;
                this.Text = Root.Local.ArrowDlg;
            }
            else
            {
                ArrowHead = Root.ArrowHead[Root.CurrentArrow];
                ArrowTail = Root.ArrowTail[Root.CurrentArrow];
                this.Text = Root.Local.ArrowDlg + string.Format(" - {0}/{1}", Root.CurrentArrow + 1, Root.ArrowHead.Count);
            }
            ArrowHead_Pnl.BackgroundImage = (Image)FormCollection.getImgFromDiskOrRes(ArrowHead).Clone();          
            ArrowTail_Pnl.BackgroundImage = (Image)FormCollection.getImgFromDiskOrRes(ArrowTail).Clone();
            ArrowTail_Pnl.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            SaveBtn.Enabled = false;
        }

        private void ArrowHead_Pnl_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.FileName = ArrowHead;
                dlg.InitialDirectory = Global.ProgramFolder;
                dlg.Filter = "Images(*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico;*.apng)|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico;*.apng|All files (*.*)|*.*";
                dlg.RestoreDirectory = true;
                dlg.FilterIndex = 1;
                DialogResult rst = dlg.ShowDialog();
                if (rst == DialogResult.OK)
                {
                    ArrowHead_Pnl.BackgroundImage.Dispose();
                    ArrowHead = dlg.FileName;
                    ArrowHead_Pnl.BackgroundImage = new Bitmap(ArrowHead);
                    SaveBtn.Enabled = true;
                }
            }
        }

        private void ArrowTail_Pnl_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.FileName = ArrowTail;
                dlg.InitialDirectory = Global.ProgramFolder;
                dlg.Filter = "Images(*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico;*.apng)|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico;*.apng|All files (*.*)|*.*";
                dlg.RestoreDirectory = true;
                dlg.FilterIndex = 1;
                DialogResult rst = dlg.ShowDialog();
                if (rst == DialogResult.OK)
                {
                    ArrowTail_Pnl.BackgroundImage.Dispose();
                    ArrowTail = dlg.FileName;
                    ArrowTail_Pnl.BackgroundImage = new Bitmap(ArrowTail);
                    ArrowTail_Pnl.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    SaveBtn.Enabled = true;
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(EditStroke!=null)
            {
                double theta = Math.Atan2((int)EditStroke.ExtendedProperties[Root.ARROWEND_Y_GUID].Data - (int)EditStroke.ExtendedProperties[Root.ARROWSTART_Y_GUID].Data,
                                          (int)EditStroke.ExtendedProperties[Root.ARROWEND_X_GUID].Data - (int)EditStroke.ExtendedProperties[Root.ARROWSTART_X_GUID].Data);
                int l1;
                Root.FormCollection.StoredArrowImages[(int)EditStroke.ExtendedProperties[Root.ARROWSTART_GUID].Data].Dispose();
                Bitmap bmp = Root.FormCollection.PrepareArrowBitmap(ArrowHead, EditStroke.DrawingAttributes.Color, EditStroke.DrawingAttributes.Transparency,
                           Root.HiMetricToPixel(EditStroke.DrawingAttributes.Width), (float)theta, out l1);
                Root.FormCollection.StoredArrowImages[(int)EditStroke.ExtendedProperties[Root.ARROWSTART_GUID].Data]=bmp;
                EditStroke.ExtendedProperties.Add(Root.ARROWSTART_FN_GUID, ArrowHead);

                Root.FormCollection.StoredArrowImages[(int)EditStroke.ExtendedProperties[Root.ARROWEND_GUID].Data].Dispose();
                bmp = Root.FormCollection.PrepareArrowBitmap(ArrowTail, EditStroke.DrawingAttributes.Color, EditStroke.DrawingAttributes.Transparency,
                           Root.HiMetricToPixel(EditStroke.DrawingAttributes.Width), (float)(Math.PI + theta), out l1);
                Root.FormCollection.StoredArrowImages[(int)EditStroke.ExtendedProperties[Root.ARROWEND_GUID].Data] = bmp;
                EditStroke.ExtendedProperties.Add(Root.ARROWEND_FN_GUID, ArrowTail);

                Root.UponAllDrawingUpdate = true;
                DialogResult = DialogResult.Cancel;
                Close(); 
            }
            else
            {
                Root.ArrowHead[Root.CurrentArrow] = ArrowHead;
                Root.ArrowTail[Root.CurrentArrow] = ArrowTail;
            }
            SaveBtn.Enabled = false;
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (++Root.CurrentArrow >= Root.ArrowHead.Count) Root.CurrentArrow = 0;
            Initialize();
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            if (--Root.CurrentArrow < 0) Root.CurrentArrow = Root.ArrowHead.Count-1;
            Initialize();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if(Root.ArrowHead.Count>1)
            {
                Root.ArrowHead.RemoveAt(Root.CurrentArrow);
                Root.ArrowTail.RemoveAt(Root.CurrentArrow);
                if (Root.CurrentArrow >= Root.ArrowHead.Count)
                    Root.CurrentArrow = 0;
            }
            Initialize();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Root.CurrentArrow++;
            Root.ArrowHead.Insert(Root.CurrentArrow, "Arw_None");
            Root.ArrowTail.Insert(Root.CurrentArrow, "Arw_None");
            Initialize();
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
        }
    }
}