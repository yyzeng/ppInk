using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gInk
{
    public partial class ImageLister : Form
    {
        Root Root;
        public Point[] ImgSize = new Point[100]; // I wanted to use the tag, but for an unknown reason it affects image display in dialogbox....
        public int ImageStampFilling=-1;
        
        public ImageLister(Root rt)
        {
            Root = rt;

            InitializeComponent();
            AutoCloseCb.Checked = true;
            Text = Root.Local.FormClipartsTitle;
            InsertBtn.Text = Root.Local.ButtonInsertText;
            CancelBtn.Text = Root.Local.ButtonCancelText;
            FromClpBtn.Text = Root.Local.ButtonFromClipBText;
            LoadImageBtn.Text = Root.Local.ButtonLoadImageText;
            DelBtn.Text = Root.Local.ButtonDeleteText;        
            FillingCombo.Items.Clear();
            FillingCombo.Items.AddRange(Root.Local.ListFillingsText.Split(';'));
            FillingCombo.Text = (string)FillingCombo.Items[Root.ImageStampFilling + 1];
            AutoCloseCb.Text = Root.Local.CheckBoxAutoCloseText;
            for (int i=0;i<Root.StampFileNames.Count;i++)
            {
                ImageListViewer.Items.Add(new ListViewItem(Path.GetFileNameWithoutExtension(Root.StampFileNames[i]), Root.StampFileNames[i]));
                Image img = Image.FromFile(Root.StampFileNames[i]);
                img.Tag = img.Width * 10000 + img.Height;
                ImageListViewer.LargeImageList.Images.Add(Root.StampFileNames[i], img);
                //ImgSize[ImageListViewer.LargeImageList.Images.IndexOfKey(Root.StampFileNames[i])] = new Point(img.Width,img.Height);
                ImgSize[ImageListViewer.LargeImageList.Images.IndexOfKey(Root.StampFileNames[i])].X = img.Width;
                ImgSize[ImageListViewer.LargeImageList.Images.IndexOfKey(Root.StampFileNames[i])].Y = img.Height;
            }
            ImageListViewer.LargeImageList.ImageSize = new Size(Root.StampSize , Root.StampSize);
        }

        private bool OpaqueCorner(Bitmap img, int x0, int y0)
        {
            for (int x = x0; x < (x0 + 10); x++)
                for (int y = y0; y < (y0 + 10); y++)
                    if (img.GetPixel(x, y).A < 255)
                        return false;
            return true;
        }

        private void FromClipB_Click(object sender, EventArgs e)
        {
            Bitmap img=null;
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Dib))
            {
                var dib = ((System.IO.MemoryStream)Clipboard.GetData(DataFormats.Dib)).ToArray();
                var width = BitConverter.ToInt32(dib, 4);
                var height = BitConverter.ToInt32(dib, 8);
                var bpp = BitConverter.ToInt16(dib, 14);
                if (bpp == 32)
                {
                    var gch = GCHandle.Alloc(dib, GCHandleType.Pinned);
                    try
                    {
                        var ptr = new IntPtr((long)gch.AddrOfPinnedObject() + 40);
                        img = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, ptr);
                        img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    }
                    catch
                    {
                        return;
                    }
                    gch.Free();
                }
            }
            else if (Clipboard.ContainsImage())
            {
                img = (Bitmap)Clipboard.GetImage();
            }
            else
            {
                return;
            }
            if(OpaqueCorner(img,0,0))
            {
                img.MakeTransparent(img.GetPixel(0, 0));
                Console.WriteLine("transp " + img.PixelFormat.ToString());
            }
            string st = "ClipBoard"+ImageListViewer.Items.Count.ToString();
            ImageListViewer.Items.Add(new ListViewItem("Clipboard",st));
            ImageListViewer.LargeImageList.Images.Add(st,img);
            ImgSize[ImageListViewer.LargeImageList.Images.IndexOfKey(st)].X = img.Width;
            ImgSize[ImageListViewer.LargeImageList.Images.IndexOfKey(st)].Y = img.Height;
        }
        
        private void LoadImageBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Root.ProgramFolder;
                openFileDialog.Filter = "Images(*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico)|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    String fn = openFileDialog.FileName;

                    ImageListViewer.Items.Add(new ListViewItem(Path.GetFileNameWithoutExtension(fn), fn));
                    Image img = Image.FromFile(fn);
                    ImageListViewer.LargeImageList.Images.Add(fn, img);
                    ImgSize[ImageListViewer.LargeImageList.Images.IndexOfKey(fn)].X = img.Width;
                    ImgSize[ImageListViewer.LargeImageList.Images.IndexOfKey(fn)].Y = img.Height;

                }
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int i = ImageListViewer.SelectedIndices[0];
                ImageListViewer.Items.RemoveAt(i);
            }
            catch
            {
                ;
            }
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Root.ImageStamp = ImageListViewer.SelectedItems[0].ImageKey;
                ImageStampFilling = Array.IndexOf(Root.Local.ListFillingsText.Split(';'), FillingCombo.Text) - 1;

                DialogResult = DialogResult.OK;

                if(AutoCloseCb.Checked)
                    Close();
            }
            catch
            {
                ;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImageLister_Enter(object sender, EventArgs e)
        {
            return; 
        }

        private void ImageLister_Leave(object sender, EventArgs e)
        {
            return; 
        }
    }
}
