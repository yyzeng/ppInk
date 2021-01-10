using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace gInk
{
    public partial class CallForm : Form
    {
        public Root Root;
        public CallForm(Root r)
        {
            InitializeComponent();
            Root = r;
            if (File.Exists(Root.ProgramFolder + "FloatingCall.png"))
                BackgroundImage = new Bitmap(Root.ProgramFolder + "FloatingCall.png");
        }

        private void _Click(object sender, EventArgs e)
        {
            Root.callshortcut();
        }

        private void _MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Left += e.X - Width / 2;
                Top += e.Y - Height / 2;
                Root.FormLeft = Left;
                Root.FormTop = Top;
            }
        }
    }
}
