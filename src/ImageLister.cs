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
using gInk.Apng;

namespace gInk
{
    public partial class ImageLister : Form
    {
        Root Root;
        public Point[] ImgSizes = new Point[100]; // I wanted to use the tag, but for an unknown reason it affects image display in dialogbox....
        public int ImageStampFilling=-1;
        public string ImageStamp;
        public int ImgSizeX = -1;
        public int ImgSizeY = -1;
        public Dictionary<string,Image> Originals = new Dictionary<string, Image>();
        public Dictionary<string, ApngImage> Animations = new Dictionary<string, ApngImage>();

        public ImageLister(Root rt)
        {
            Root = rt;

            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {

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
            ImageListViewer.Items.Clear();
            ImageListViewer.LargeImageList.Images.Clear();
            Originals.Clear();
            for (int i = 0; i < Root.StampFileNames.Count; i++)
            {
                try
                {
                    ImageListViewer.Items.Add(new ListViewItem(Path.GetFileNameWithoutExtension(Root.StampFileNames[i]), Root.StampFileNames[i]));
                    Image img = Image.FromFile(Root.StampFileNames[i]);
                    img.Tag = img.Width * 10000 + img.Height;
                    ImageListViewer.LargeImageList.Images.Add(Root.StampFileNames[i], img);
                    int j = ImageListViewer.LargeImageList.Images.IndexOfKey(Root.StampFileNames[i]);
                    Originals.Add(Root.StampFileNames[i], (Image)(img.Clone()));
                    //ImgSize[ImageListViewer.LargeImageList.Images.IndexOfKey(Root.StampFileNames[i])] = new Point(img.Width,img.Height);
                    ImgSizes[j].X = img.Width;
                    ImgSizes[j].Y = img.Height;
                }
                catch
                {
                    MessageBox.Show("Error Loading ClipArt image:\n" + Root.StampFileNames[i], "ppInk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ImageListViewer.LargeImageList.ImageSize = new Size(Root.StampSize, Root.StampSize);
            ImageListViewer.Select();
        }

        private bool OpaqueCorner(Bitmap img, int x0, int y0)
        {
            try
            {
                for (int x = x0; x < (x0 + 10); x++)
                    for (int y = y0; y < (y0 + 10); y++)
                        if (img.GetPixel(x, y).A < 255)
                            return false;
            }
            catch { };
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
                else
                    img = (Bitmap)Clipboard.GetImage();
            }
            else if (Clipboard.ContainsImage())
            {
                img = (Bitmap)Clipboard.GetImage();
            }
            else
            {
                return;
            }
            if (OpaqueCorner(img, 0, 0))
            {
                img.MakeTransparent(img.GetPixel(0, 0));
                Console.WriteLine("transp " + img.PixelFormat.ToString());
            }
            string st = "ClipBoard" + ((int)((DateTime.Now - DateTime.Today).TotalSeconds * 100)).ToString(); // ImageListViewer.Items.Count.ToString();
            ImageListViewer.Items.Add(new ListViewItem("Clipboard",st));
            ImageListViewer.LargeImageList.Images.Add(st,img);
            int j = ImageListViewer.LargeImageList.Images.IndexOfKey(st);
            Originals.Add(st, (Image)(img.Clone())); 
            ImgSizes[j].X = img.Width;
            ImgSizes[j].Y = img.Height;
            ImageListViewer.Items[ImageListViewer.Items.Count-1].EnsureVisible();
            ImageListViewer.SelectedIndices.Clear();
            ImageListViewer.SelectedIndices.Add(ImageListViewer.Items.Count - 1);
            ImageListViewer.Select();
        }
        
        private void LoadImageBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Global.ProgramFolder;
                openFileDialog.Filter = "Images(*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico)|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    LoadImage(openFileDialog.FileName);

                    ImageListViewer.Items[ImageListViewer.Items.Count - 1].EnsureVisible();
                    ImageListViewer.SelectedIndices.Clear();
                    ImageListViewer.SelectedIndices.Add(ImageListViewer.Items.Count - 1);
                    ImageListViewer.Select();
                }
            }
        }

        public string LoadImage(string fn)
        {
            string fn1 = Path.GetFileNameWithoutExtension(fn);
            if (!Originals.ContainsKey(fn))
            {
                ImageListViewer.Items.Add(new ListViewItem(fn1, fn));
                //Image img = Image.FromFile(fn);
                ApngImage img = new ApngImage(fn);
                ImageListViewer.LargeImageList.Images.Add(fn, img.DefaultImage.GetImage());
                int j = ImageListViewer.LargeImageList.Images.IndexOfKey(fn);
                Originals.Add(fn, (Image)(img.DefaultImage.GetImage().Clone()));
                ImgSizes[j].X = img.DefaultImage.GetImage().Width;
                ImgSizes[j].Y = img.DefaultImage.GetImage().Height;
                if(img.IsAnimated())
                {
                    Animations.Add(fn, img);
                }
            }
            return fn1;
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int i = ImageListViewer.SelectedIndices[0];
                // should not remove from originals to keep display in existing image Originals.Remove(ImageListViewer.Items[i].ImageKey);
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
                ImageStamp = ImageListViewer.SelectedItems[0].ImageKey;
                ImageStampFilling = Array.IndexOf(Root.Local.ListFillingsText.Split(';'), FillingCombo.Text) - 1;
                ImgSizeX = ImgSizes[ImageListViewer.LargeImageList.Images.IndexOfKey(ImageStamp)].X;
                ImgSizeY = ImgSizes[ImageListViewer.LargeImageList.Images.IndexOfKey(ImageStamp)].Y;
                DialogResult = DialogResult.OK;
                
                if(AutoCloseCb.Checked)
                    Close();
            }
            catch
            {
                ;
            }
        }

        public ClipArtData getClipArtData(string fn,int fill=-2)
        {
            int ImgX, ImgY;
            //ImageStamp = fn;
            if (!fn.Contains("/"))
                fn = ImageListViewer.FindItemWithText(fn).ImageKey;
            if (fill == -2)
                fill = Array.IndexOf(Root.Local.ListFillingsText.Split(';'), FillingCombo.Text) - 1;
            ImgX = ImgSizes[ImageListViewer.LargeImageList.Images.IndexOfKey(fn)].X;
            ImgY = ImgSizes[ImageListViewer.LargeImageList.Images.IndexOfKey(fn)].Y;
            return new ClipArtData { ImageStamp = fn, X = ImgX, Y = ImgY, Filling = fill };
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImageLister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control|Keys.V))
            {
                e.SuppressKeyPress  = true;
                FromClipB_Click(null, null);
            }
        }
    }
}
