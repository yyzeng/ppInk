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
        public bool PutClipartOnLine = false;
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

            ParamsToBeSavedCb.Checked = false;
            ParamsToBeSavedCb.Text = Root.Local.PatternStoreParamTxt;

            AutoCloseCb.Text = Root.Local.CheckBoxAutoCloseText;
            ImageListViewer.Items.Clear();
            ImageListViewer.LargeImageList.Images.Clear();
            Originals.Clear();
            Animations.Clear();
            for (int i = 0; i < Root.StampFileNames.Count; i++)
            {
                try
                {
                    LoadImage(Root.StampFileNames[i]);
                }
                catch //(Exception ex)
                {
                    MessageBox.Show("Error Loading ClipArt image:\n" + Root.StampFileNames[i], "ppInk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ImageListViewer.LargeImageList.ImageSize = new Size(Root.StampSize, Root.StampSize);
            ImageListViewer.Select();
        }

        public void SetFillingOrPattern(bool Pattern = false, int f=Filling.NoFrame)
        {
            if (Pattern)
                FillingCombo.SelectedIndex = Root.Local.LineOfPatternsListPos;
            else
                FillingCombo.SelectedIndex = f + 1;
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
            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Global.ProgramFolder;
                openFileDialog.Filter = "Images(*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico;*.apng)|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.ico;*.apng|All files (*.*)|*.*";
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
            // fn2 is required as Windows file system is case insensitive and some names are typed manually in config.ini file
            string fn2 = fn.Replace('\\','/').ToLower();
            bool fnd = false;
            foreach(ListViewItem it in ImageListViewer.Items)
            {
                fnd = it.ImageKey.Equals(fn2);
                if (fnd) break;
            }
            if (!fnd)//ImageListViewer.Items.ContainsKey(fn2))
            {
                ImageListViewer.Items.Add(new ListViewItem(fn1, fn2));
                ApngImage img = new ApngImage(fn);
                img.DefaultImage._image.Tag = img.DefaultImage._image.Width * 10000 + img.DefaultImage._image.Height;
                if(!ImageListViewer.LargeImageList.Images.ContainsKey(fn2))
                    ImageListViewer.LargeImageList.Images.Add(fn2, (Image)(img.DefaultImage.GetImage().Clone()));
                if (!Originals.ContainsKey(fn2))
                    Originals.Add(fn2, (Image)(img.DefaultImage.GetImage().Clone()));
                int j = ImageListViewer.LargeImageList.Images.IndexOfKey(fn2);
                ImgSizes[j].X = Originals[fn2].Width;
                ImgSizes[j].Y = Originals[fn2].Height;
                if (img.IsAnimated() && !Animations.ContainsKey(fn2))
                    Animations.Add(fn2, img);
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
                if (ImageStampFilling == Root.Local.LineOfPatternsListPos-1)
                {
                    PutClipartOnLine = true;
                    ImageStampFilling = Filling.NoFrame;
                }
                else
                    PutClipartOnLine = false;

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

        public ClipArtData getClipArtData(string fn=null,int fill=-2)
        {
            int ImgX, ImgY;
            bool PL;
            //ImageStamp = fn;
            if (fn == null)
                fn = ImageListViewer.SelectedItems[0].ImageKey;
            if (!fn.Contains("/"))
                try
                {
                    fn = ImageListViewer.FindItemWithText(fn).ImageKey;
                }
                catch
                {
                    throw new Exception(fn + " not loaded; prefer to use full path filename");
                }
            if (fill == -2)
                fill = Array.IndexOf(Root.Local.ListFillingsText.Split(';'), FillingCombo.Text) - 1;
            ImgX = ImgSizes[ImageListViewer.LargeImageList.Images.IndexOfKey(fn)].X;
            ImgY = ImgSizes[ImageListViewer.LargeImageList.Images.IndexOfKey(fn)].Y;
            if (fill == Root.Local.LineOfPatternsListPos-1)
            {
                PL= true;
                fill = Filling.NoFrame;
            }
            else
                PL = false;
            return new ClipArtData { ImageStamp = fn, X = -1, Y = -1, Wstored=-1,Hstored=-1, Filling = fill, PatternLine = PL, Distance = -1, Store = ParamsToBeSavedCb.Checked };
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

        private void FillingCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParamsToBeSavedCb.Enabled = FillingCombo.SelectedIndex == Root.Local.LineOfPatternsListPos;
        }
    }
}
