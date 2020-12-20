using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Ink;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.WebSockets;

namespace gInk
{
    public enum VideoRecordMode {NoVideo=0 , OBSRec=1 , OBSBcst=2 , FfmpegRec=3 };
    public enum VideoRecInProgress { Stopped=0, Starting=1, Recording=2, Stopping = 3, Pausing=4, Paused=5, Resuming=6, Streaming = 7 };

    public class TestMessageFilter : IMessageFilter
	{
		public Root Root;

		public TestMessageFilter(Root root)
		{
			Root = root;
		}

		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == 0x0312 || m.Msg == Program.StartInkingMsg)                    // 0x0312 is the global hotkey 
            {
                //Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                //int modifier = (int)m.LParam & 0xFFFF;       // The modifier of the hotkey that was pressed.
                //int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.
                bool activePointer = (m.Msg == 0x0312 && Root.FormCollection != null);
                Root.callshortcut();
                if (activePointer)           // StartInkingMsg is received twice, therefore we have to froce pointerMode at that time...
                {
                    Root.FormCollection.btPointer_Click(null,null);
                    if (Root.AltTabPointer && !Root.PointerMode && !Root.FormCollection.Initializing) // to unfold the bar if AltTabPointer option has been set
                    {
                        Root.UnDock();
                    }

                }
                return true;
			}
			return false;
		}
	}

    public static class globalRoot {
        public static bool HideInAltTab=true;
    };

    public class Root
    {
        public Local Local = new Local();
        public const int MaxPenCount = 10;

        //public Guid TYPE_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 0);
        public static Guid TEXT_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 1);
        public static Guid TEXTX_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 2);
        public static Guid TEXTY_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 3);
        public static Guid TEXTHALIGN_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 4);
        public static Guid TEXTVALIGN_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 5);
        public static Guid TEXTFONT_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 6);
        public static Guid TEXTFONTSIZE_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 7);
        public static Guid TEXTFONTSTYLE_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 8);
        public static Guid TEXTWIDTH_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 9);
        public static Guid TEXTHEIGHT_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 0, 10);

        public static Guid ISDELETION_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 1, 0);
        public static Guid ISSTROKE_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 1, 1);
        public static Guid ISTAG_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 1, 2);
        //not yet used : 
        //public Guid ISRECT_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 1, 2);
        //public Guid ISOVAL_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 1, 3);

        public static Guid ISFILLEDCOLOR_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 2, 1);
        public static Guid ISFILLEDWHITE_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 2, 2);
        public static Guid ISFILLEDBLACK_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 2, 3);
        public static Guid ISHIDDEN_GUID = new Guid(10, 11, 12, 10, 0, 0, 0, 0, 0, 2, 4);

        public static int MIN_MAGNETIC = 25;
        // options
        public bool[] PenEnabled = new bool[MaxPenCount];
        public bool ToolsEnabled = true;
        public bool EraserEnabled = true;
        public bool PointerEnabled = true;
        public bool AltTabPointer = false;
        public bool PenWidthEnabled = false;
        public bool WidthAtPenSel = true;
        public bool SnapEnabled = true;
        public bool UndoEnabled = true;
        public bool ClearEnabled = true;
        public bool PanEnabled = true;
        public bool InkVisibleEnabled = true;
        public DrawingAttributes[] PenAttr = new DrawingAttributes[MaxPenCount];
        public bool AutoScroll;
        public bool WhiteTrayIcon;
        public string SnapshotBasePath;
        public int CanvasCursor = 0;
        public bool AllowDraggingToolbar = true;
        public bool AllowHotkeyInPointerMode = true;
        public int gpButtonsLeft, gpButtonsTop;

        // advanced options
        public string CloseOnSnap = "blankonly";
        public bool AlwaysHideToolbar = false;
        public float ToolbarHeight = 0.06f;
        public bool AltAsOneCommand = true;

        public int CursorX, CursorY;
        public int CursorX0 = int.MinValue, CursorY0 = int.MinValue;

        public double LongClickTime = 1.0;

        // the two grays for "white board" effect
        public int[] Gray1 = new int[] { 80, 150, 150, 150 };
        public int[] Gray2 = new int[] {100, 100, 100, 100};
        public int[] ToolbarBGColor = new int[] { 245, 245, 245, 0 };
        public int BoardAtOpening = 0;      // 0:Transparent/1:White/2:Customed/3:Black/4:AtSelection
        public int BoardSelected = 0;       // by default transparent

        // hotkey options
        public Hotkey Hotkey_Global = new Hotkey();
		public Hotkey[] Hotkey_Pens = new Hotkey[10];
		public Hotkey Hotkey_Eraser = new Hotkey();
		public Hotkey Hotkey_InkVisible = new Hotkey();
		public Hotkey Hotkey_Pointer = new Hotkey();
		public Hotkey Hotkey_Pan = new Hotkey();
		public Hotkey Hotkey_Undo = new Hotkey();
		public Hotkey Hotkey_Redo = new Hotkey();
		public Hotkey Hotkey_Snap = new Hotkey();
		public Hotkey Hotkey_Clear = new Hotkey();
        public Hotkey Hotkey_Video = new Hotkey();
        public Hotkey Hotkey_DockUndock = new Hotkey();
        public Hotkey Hotkey_Close = new Hotkey();

        public Hotkey Hotkey_Hand = new Hotkey();
        public Hotkey Hotkey_Line = new Hotkey();
        public Hotkey Hotkey_Rect = new Hotkey();
        public Hotkey Hotkey_Oval = new Hotkey();
        public Hotkey Hotkey_Arrow = new Hotkey();
        public Hotkey Hotkey_Numb = new Hotkey();
        public Hotkey Hotkey_Text = new Hotkey();
        public Hotkey Hotkey_Edit = new Hotkey();
        public Hotkey Hotkey_Move = new Hotkey();
        public Hotkey Hotkey_Magnet = new Hotkey();

        public int ToolSelected = 0;        // indicates which tool (Hand,Line,...) is currently selected
        public int FilledSelected = 0;      // indicates which filling (None, Selected color, ...) is currently select
        public bool EraserMode = false;
		public bool Docked = false;
		public bool PointerMode = false;
		public bool FingerInAction = false;  // true when mouse down, either drawing or snapping or whatever
		public int Snapping = 0;  // <=0: not snapping, 1: waiting finger, 2:dragging
		public int SnappingX = -1, SnappingY = -1;
		public Rectangle SnappingRect;
		public int UponButtonsUpdate = 0;
		public bool UponTakingSnap = false;
		public bool UponBalloonSnap = false;
		public bool UponSubPanelUpdate = false;
		public bool UponAllDrawingUpdate = false;
		public bool MouseMovedUnderSnapshotDragging = false; // used to pause re-drawing when mouse is not moving during dragging to take a screenshot

		public bool PanMode = false;
		public bool InkVisible = true;
        public int MagneticRadius= MIN_MAGNETIC;        // Magnet Radius; <=0 means off;
        public int MinMagneticRadius() { return Math.Max(Math.Abs(MagneticRadius), MIN_MAGNETIC); }

        public bool DefaultArrow_start = true;

        public Ink[] UndoStrokes;
		//public Ink UponUndoStrokes;
		public int UndoP;
		public int UndoDepth, RedoDepth;

		public NotifyIcon trayIcon;
		public ContextMenu trayMenu;
		public FormCollection FormCollection;
		public FormDisplay FormDisplay;
		public FormButtonHitter FormButtonHitter;
		public FormOptions FormOptions;

		public int CurrentPen = 1;  // defaut pen
		public int LastPen = 1;
		public int GlobalPenWidth = 80;
		public bool gpPenWidthVisible = false;
		public string SnapshotFileFullPath = ""; // used to record the last snapshot file name, to select it when the balloon is clicked

        public int FormTop = 100, FormLeft = 100, FormWidth = 48, FormOpacity = -50; // negative opacity means that the window is not displayed
        public CallForm callForm = null;
        public bool OpenIntoSnapMode = false;

        public double ArrowAngle = 15 * Math.PI /180;   // 15°
        public double ArrowLen = 0.0185 * System.Windows.SystemParameters.PrimaryScreenWidth; // == 1.85% of screen width

        public int TagNumbering = 1;
        public int TextSize = 25;
        public string TextFont = "Arial";
        public bool TextItalic = false;
        public bool TextBold = false;

        public VideoRecordMode VideoRecordMode = VideoRecordMode.NoVideo;
        public string ObsUrl = "ws://localhost:4444";
        public string ObsPwd = "obs";
        public string FFMpegCmd = "ffmpeg.exe -f gdigrab  -framerate 15 -offset_x $xx$ -offset_y $yy$ -video_size $ww$x$hh$ -show_region 1 -i desktop -vcodec libx264 %USERPROFILE%/CAPT_%DD%%MM%%YY%_%H%%M%%S%_$nn$.mkv";
        public int VideoRecordCounter = 0;
        public VideoRecInProgress VideoRecInProgress = VideoRecInProgress.Stopped;
        public Process FFmpegProcess = null;
        public bool VideoRecordWindowInProgress = false;
        public ClientWebSocket ObsWs;
        public Task ObsRecvTask;
        public CancellationTokenSource ObsCancel = new CancellationTokenSource();

        public string ProgramFolder;

        public string ExpandVarCmd(string cmd, int x, int y, int w, int h)
        {
            cmd = Environment.ExpandEnvironmentVariables(cmd);
            cmd = cmd.Replace("$xx$", x.ToString());
            cmd = cmd.Replace("$yy$", y.ToString());
            cmd = cmd.Replace("$ww$", w.ToString());
            cmd = cmd.Replace("$hh$", h.ToString());
            cmd = cmd.Replace("$nn$", VideoRecordCounter.ToString());
            DateTime dt = DateTime.Now;
            cmd = cmd.Replace("$H$", dt.Hour.ToString("00"));
            cmd = cmd.Replace("$M$", dt.Minute.ToString("00"));
            cmd = cmd.Replace("$S$", dt.Second.ToString("00"));
            cmd = cmd.Replace("$DD$", dt.Day.ToString("00"));
            cmd = cmd.Replace("$MM$", dt.Month.ToString("00"));
            cmd = cmd.Replace("$YY$", (dt.Year % 100).ToString("00"));
            cmd = cmd.Replace("$YYYY$", dt.Year.ToString("00"));
            return cmd;
        }


        public Root()
		{
			for (int p = 0; p < MaxPenCount; p++)
				Hotkey_Pens[p] = new Hotkey();

			trayMenu = new ContextMenu();
			trayMenu.MenuItems.Add(Local.MenuEntryAbout + "...", OnAbout);
			trayMenu.MenuItems.Add(Local.MenuEntryOptions + "...", OnOptions);
			trayMenu.MenuItems.Add("-");
			trayMenu.MenuItems.Add(Local.MenuEntryExit, OnExit);

			SetDefaultPens();
			SetDefaultConfig();
			ReadOptions("pens.ini");
			ReadOptions("config.ini");
			ReadOptions("hotkeys.ini");
            ProgramFolder = Path.GetDirectoryName(Path.GetFullPath(Environment.GetCommandLineArgs()[0]));
            
            Size size = SystemInformation.SmallIconSize;
			trayIcon = new NotifyIcon();
			trayIcon.Text = "ppInk";
			trayIcon.ContextMenu = trayMenu;
			trayIcon.Visible = true;
			trayIcon.MouseClick += TrayIcon_Click;
			trayIcon.BalloonTipText = Local.NotificationSnapshot;
			trayIcon.BalloonTipClicked += TrayIcon_BalloonTipClicked;
			SetTrayIconColor();

			SetHotkey();

			TestMessageFilter mf = new TestMessageFilter(this);
			Application.AddMessageFilter(mf);

			FormCollection = null;
			FormDisplay = null;

            // to be done once only
            //ReadOptions("pens.ini");
            //ReadOptions("config.ini");
            //ReadOptions("hotkeys.ini");

        }

        public void callshortcut()
        {
            TagNumbering = 1; //reset tag counter 
            if (FormCollection == null && FormDisplay == null)
            {
                //if (FormOpacity > 0) callForm.Hide();
                if (FormOpacity > 0) callForm.Close();
                StartInk();
                if (OpenIntoSnapMode)
                    FormCollection.btSnap_Click(null,null);
            }
            /*
            else if (PointerMode)
            {
                //Root.UnPointer();
                SelectPen(LastPen);
            }
            else
            {
                //Root.Pointer();
                SelectPen(-2);
            }*/

        }

        private void TrayIcon_BalloonTipClicked(object sender, EventArgs e)
		{
			//string snapbasepath = SnapshotBasePath;
			//snapbasepath = Environment.ExpandEnvironmentVariables(snapbasepath);
			//System.Diagnostics.Process.Start(snapbasepath);
			string fullpath = System.IO.Path.GetFullPath(SnapshotFileFullPath);
			System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", fullpath));
		}

		private void TrayIcon_Click(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{

                if (FormDisplay == null && FormCollection == null)
				{
                    callshortcut();
                    //ReadOptions("pens.ini");
                    //ReadOptions("config.ini");
                    //ReadOptions("hotkeys.ini");
                    //StartInk();
				}
				else if (Docked)
					UnDock();
			}
		}

		public void StartInk()
		{
			if (FormDisplay != null || FormCollection != null)
				return;

			//Docked = false;
            FormCollection = new FormCollection(this);
			FormButtonHitter = new FormButtonHitter(this);
			FormDisplay = new FormDisplay(this);  // FormDisplay is created at the end to ensure other objects are created.
			if (CurrentPen < 0)
				CurrentPen = 0;
			if (!PenEnabled[CurrentPen])
			{
				CurrentPen = 0;
				while (CurrentPen < MaxPenCount && !PenEnabled[CurrentPen])
					CurrentPen++;
				if (CurrentPen == MaxPenCount)
					CurrentPen = -2;
			}
			SelectPen(CurrentPen);
			SetInkVisible(true);
			FormCollection.ButtonsEntering = 1;
			FormDisplay.Show();
			FormCollection.Show();
			FormDisplay.DrawButtons(true);

			if (UndoStrokes == null)
			{
				UndoStrokes = new Ink[8];
				UndoStrokes[0] = FormCollection.IC.Ink.Clone();
				UndoDepth = 0;
				UndoP = 0;
			}

			//UponUndoStrokes = FormCollection.IC.Ink.Clone();
		}
		public void StopInk()
		{
			FormCollection.Close();
			FormDisplay.Close();
			FormButtonHitter.Close();
			//FormCollection.Dispose();
			//FormDisplay.Dispose();
			GC.Collect();

            FormCollection = null;
            //  The FormCollection is destroyed, therefore all following calls to the form and its controls will not hit
            ObsCancel.Cancel();
            ObsRecvTask = null;
            ObsWs = null;
            ObsCancel = new CancellationTokenSource();

            FormDisplay = null;

			if (UponBalloonSnap)
			{
				ShowBalloonSnapshot();
				UponBalloonSnap = false;
			}
            //if (FormOpacity > 0) callForm.Show();
            if (FormOpacity > 0)
            {
                callForm = new CallForm(this);
                callForm.Show();
                callForm.Top = FormTop;
                callForm.Left = FormLeft;
                callForm.Width = FormWidth;
                callForm.Height = FormWidth;
                callForm.Opacity = FormOpacity / 100.0;
            }
        }

            public void ClearInk()
		{
			FormCollection.IC.Ink.DeleteStrokes();
            FormDisplay.ClearCanvus();
            FormDisplay.DrawButtons(true);
            FormDisplay.UpdateFormDisplay(true);
        }

        public void ShowBalloonSnapshot()
		{
			trayIcon.ShowBalloonTip(3000);
		}

		public void UndoInk()
		{
			if (UndoDepth <= 0)
				return;
            if(FormCollection.IC.Ink.Strokes.Count>0 && FormCollection.IC.Ink.Strokes[FormCollection.IC.Ink.Strokes.Count - 1].ExtendedProperties.Contains(ISTAG_GUID))
            {
                TagNumbering--;
            }

			UndoP--;
			if (UndoP < 0)
				UndoP = UndoStrokes.GetLength(0) - 1;
			UndoDepth--;
			RedoDepth++;
			FormCollection.IC.Ink.DeleteStrokes();
			if (UndoStrokes[UndoP].Strokes.Count > 0)
            {
				FormCollection.IC.Ink.AddStrokesAtRectangle(UndoStrokes[UndoP].Strokes, UndoStrokes[UndoP].Strokes.GetBoundingBox());
                if (ToolSelected == 11)
                    FormCollection.RestorePolylineData(FormCollection.IC.Ink.Strokes[FormCollection.IC.Ink.Strokes.Count-1]);
            }
			FormDisplay.ClearCanvus();
			FormDisplay.DrawStrokes();
			FormDisplay.DrawButtons(true);
			FormDisplay.UpdateFormDisplay(true);
		}

		public void Pan(int x, int y)
		{
			if (x == 0 && y == 0)
				return;

			FormCollection.IC.Ink.Strokes.Move(x, y);
            // for texts
            foreach(Stroke st in FormCollection.IC.Ink.Strokes)
            {
                if (st.ExtendedProperties.Contains(TEXTX_GUID))
                {
                    st.ExtendedProperties.Add(TEXTX_GUID, (int)(st.ExtendedProperties[TEXTX_GUID].Data) + x);
                    st.ExtendedProperties.Add(TEXTY_GUID, (int)(st.ExtendedProperties[TEXTY_GUID].Data) + y);
                }
            }
			FormDisplay.ClearCanvus();
			FormDisplay.DrawStrokes();
			FormDisplay.DrawButtons(true);
			FormDisplay.UpdateFormDisplay(true);
		}

		public void SetInkVisible(bool visible)
		{
			InkVisible = visible;
			if (visible)
				FormCollection.btInkVisible.BackgroundImage = FormCollection.image_visible;
			else
				FormCollection.btInkVisible.BackgroundImage = FormCollection.image_visible_not;

			FormDisplay.ClearCanvus();
			FormDisplay.DrawStrokes();
			FormDisplay.DrawButtons(true);
			FormDisplay.UpdateFormDisplay(true);
		}

		public void RedoInk()
		{
			if (RedoDepth <= 0)
				return;

			UndoDepth++;
			RedoDepth--;
			UndoP++;
			if (UndoP >= UndoStrokes.GetLength(0))
				UndoP = 0;
			FormCollection.IC.Ink.DeleteStrokes();
			if (UndoStrokes[UndoP].Strokes.Count > 0)
				FormCollection.IC.Ink.AddStrokesAtRectangle(UndoStrokes[UndoP].Strokes, UndoStrokes[UndoP].Strokes.GetBoundingBox());

			FormDisplay.ClearCanvus();
			FormDisplay.DrawStrokes();
			FormDisplay.DrawButtons(true);
			FormDisplay.UpdateFormDisplay(true);
		}

		public void Dock()
		{
			if (FormDisplay == null || FormCollection == null)
				return;

			Docked = true;
			gpPenWidthVisible = false;
			FormCollection.btDock.BackgroundImage = gInk.Properties.Resources.dockback;
			FormCollection.ButtonsEntering = -1;
			UponButtonsUpdate |= 0x2;
		}

		public void UnDock()
		{
			if (FormDisplay == null || FormCollection == null)
				return;

			Docked = false;
			FormCollection.btDock.BackgroundImage = gInk.Properties.Resources.dock;
			FormCollection.ButtonsEntering = 1;
			UponButtonsUpdate |= 0x2;
		}

		public void Pointer()
		{
			if (PointerMode == true)
				return;

			PointerMode = true;
			FormCollection.ToThrough();     
			FormButtonHitter.Show();
            FormButtonHitter.timer1_Tick(null,null); // Force Size recomputation for alt+tab processing
        }

		public void UnPointer()
		{
			if (PointerMode == false)
				return;

			FormButtonHitter.Hide();
			FormCollection.ToUnThrough();
			FormCollection.ToTopMost();
			FormCollection.Activate();
			PointerMode = false;
		}

		public void SelectPen(int pen)
		{
			FormCollection.SelectPen(pen);
		}

		public void SetDefaultPens()
		{
			PenEnabled[0] = false;
			PenAttr[0] = new DrawingAttributes();
			PenAttr[0].Color = Color.FromArgb(80, 80, 80);
			PenAttr[0].Width = 80;
			PenAttr[0].Transparency = 0;

			PenEnabled[1] = true;
			PenAttr[1] = new DrawingAttributes();
			PenAttr[1].Color = Color.FromArgb(225, 60, 60);
			PenAttr[1].Width = 80;
			PenAttr[1].Transparency = 0;

			PenEnabled[2] = true;
			PenAttr[2] = new DrawingAttributes();
			PenAttr[2].Color = Color.FromArgb(30, 110, 200);
			PenAttr[2].Width = 80;
			PenAttr[2].Transparency = 0;

			PenEnabled[3] = true;
			PenAttr[3] = new DrawingAttributes();
			PenAttr[3].Color = Color.FromArgb(235, 180, 55);
			PenAttr[3].Width = 80;
			PenAttr[3].Transparency = 0;

			PenEnabled[4] = true;
			PenAttr[4] = new DrawingAttributes();
			PenAttr[4].Color = Color.FromArgb(120, 175, 70);
			PenAttr[4].Width = 80;
			PenAttr[4].Transparency = 0;

			PenEnabled[5] = true;
			PenAttr[5] = new DrawingAttributes();
			PenAttr[5].Color = Color.FromArgb(235, 125, 15);
			PenAttr[5].Width = 500;
			PenAttr[5].Transparency = 175;

			PenAttr[6] = new DrawingAttributes();
			PenAttr[6].Color = Color.FromArgb(230, 230, 230);
			PenAttr[6].Width = 80;
			PenAttr[6].Transparency = 0;

			PenAttr[7] = new DrawingAttributes();
			PenAttr[7].Color = Color.FromArgb(250, 140, 200);
			PenAttr[7].Width = 80;
			PenAttr[7].Transparency = 0;

			PenAttr[8] = new DrawingAttributes();
			PenAttr[8].Color = Color.FromArgb(25, 180, 175);
			PenAttr[8].Width = 80;
			PenAttr[8].Transparency = 0;

			PenAttr[9] = new DrawingAttributes();
			PenAttr[9].Color = Color.FromArgb(145, 70, 160);
			PenAttr[9].Width = 500;
			PenAttr[9].Transparency = 175;
		}

		public void SetDefaultConfig()
		{
			Hotkey_Global.Control = true;
			Hotkey_Global.Alt = true;
			Hotkey_Global.Shift = false;
			Hotkey_Global.Win = false;
			Hotkey_Global.Key = 'G';

			AutoScroll = false;
			WhiteTrayIcon = false;
			SnapshotBasePath = "%USERPROFILE%/Pictures/gInk/";
		}

		public void SetTrayIconColor()
		{
			if (WhiteTrayIcon)
			{
				if (File.Exists("icon_white.ico"))
					trayIcon.Icon = new Icon("icon_white.ico");
				else
					trayIcon.Icon = global::gInk.Properties.Resources.icon_white;
			}
			else
			{
				if (File.Exists("icon_red.ico"))
					trayIcon.Icon = new Icon("icon_red.ico");
				else
					trayIcon.Icon = global::gInk.Properties.Resources.icon_red;
			}


		}

		public void ReadOptions(string file)
		{
			if (!File.Exists(file))
				file = AppDomain.CurrentDomain.BaseDirectory + file;
			if (!File.Exists(file))
				return;


			FileStream fini = new FileStream(file, FileMode.Open);
			StreamReader srini = new StreamReader(fini);
			string sLine = "";
			string sName = "", sPara = "";
			while (sLine != null)
			{
				sLine = srini.ReadLine();
				if
				(
					sLine != null &&
					sLine != "" &&
					sLine.Substring(0, 1) != "-" &&
					sLine.Substring(0, 1) != "%" &&
					sLine.Substring(0, 1) != "'" &&
					sLine.Substring(0, 1) != "/" &&
					sLine.Substring(0, 1) != "!" &&
					sLine.Substring(0, 1) != "[" &&
					sLine.Substring(0, 1) != "#" &&
					sLine.Contains("=") &&
					!sLine.Substring(sLine.IndexOf("=") + 1).Contains("=")
				)
				{
					sName = sLine.Substring(0, sLine.IndexOf("="));
					sName = sName.Trim();
					sName = sName.ToUpper();
					sPara = sLine.Substring(sLine.IndexOf("=") + 1);
					sPara = sPara.Trim();

					if (sName.StartsWith("PEN"))
					{
						int penid = 0;
						if (int.TryParse(sName.Substring(3, 1), out penid))
						{
							if (sName.EndsWith("_ENABLED"))
							{
								if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
									PenEnabled[penid] = true;
								else if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
									PenEnabled[penid] = false;
							}

							int penc = 0;
							if (int.TryParse(sPara, out penc))
							{
								if (sName.EndsWith("_RED") && penc >= 0 && penc <= 255)
								{
									PenAttr[penid].Color = Color.FromArgb(penc, PenAttr[penid].Color.G, PenAttr[penid].Color.B);
								}
								else if (sName.EndsWith("_GREEN") && penc >= 0 && penc <= 255)
								{
									PenAttr[penid].Color = Color.FromArgb(PenAttr[penid].Color.R, penc, PenAttr[penid].Color.B);
								}
								else if (sName.EndsWith("_BLUE") && penc >= 0 && penc <= 255)
								{
									PenAttr[penid].Color = Color.FromArgb(PenAttr[penid].Color.R, PenAttr[penid].Color.G, penc);
								}
								else if (sName.EndsWith("_ALPHA") && penc >= 0 && penc <= 255)
								{
									PenAttr[penid].Transparency = (byte)(255 - penc);
								}
								else if (sName.EndsWith("_WIDTH") && penc >= 30 && penc <= 3000)
								{
									PenAttr[penid].Width = penc;
								}
							}

							if (sName.EndsWith("_HOTKEY"))
							{
								Hotkey_Pens[penid].Parse(sPara);
							}
						}

					}

					int tempi = 0;
					float tempf = 0;
                    string[] tab;
                    switch (sName)
					{
						case "LANGUAGE_FILE":
							ChangeLanguage(sPara);
							break;
                        case "ALT_AS_TEMPORARY_COMMAND":
                            if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
                                AltAsOneCommand = true;
                            else
                                AltAsOneCommand = false;
                            break;
                        case "HOTKEY_GLOBAL":
							Hotkey_Global.Parse(sPara);
							break;
						case "HOTKEY_ERASER":
							Hotkey_Eraser.Parse(sPara);
							break;
						case "HOTKEY_INKVISIBLE":
							Hotkey_InkVisible.Parse(sPara);
							break;
						case "HOTKEY_POINTER":
							Hotkey_Pointer.Parse(sPara);
							break;
						case "HOTKEY_PAN":
							Hotkey_Pan.Parse(sPara);
							break;
						case "HOTKEY_UNDO":
							Hotkey_Undo.Parse(sPara);
							break;
						case "HOTKEY_REDO":
							Hotkey_Redo.Parse(sPara);
							break;
						case "HOTKEY_SNAPSHOT":
							Hotkey_Snap.Parse(sPara);
							break;
						case "HOTKEY_CLEAR":
							Hotkey_Clear.Parse(sPara);
							break;
                        case "HOTKEY_VIDEOREC":
                            Hotkey_Video.Parse(sPara);
                            break;
                        case "HOTKEY_DOCKUNDOCK":
                            Hotkey_DockUndock.Parse(sPara);
                            break;
                        case "HOTKEY_CLOSE":
                            Hotkey_Close.Parse(sPara);
                            break;
                        case "HOTKEY_HAND":
                            Hotkey_Hand.Parse(sPara);
                            break;
                        case "HOTKEY_LINE":
                            Hotkey_Line.Parse(sPara);
                            break;
                        case "HOTKEY_RECT":
                            Hotkey_Rect.Parse(sPara);
                            break;
                        case "HOTKEY_OVAL":
                            Hotkey_Oval.Parse(sPara);
                            break;
                        case "HOTKEY_ARROW":
                            Hotkey_Arrow.Parse(sPara);
                            break;
                        case "HOTKEY_TEXT":
                            Hotkey_Text.Parse(sPara);
                            break;
                        case "HOTKEY_NUMBCHIP":
                            Hotkey_Numb.Parse(sPara);
                            break;
                        case "HOTKEY_EDIT":
                            Hotkey_Edit.Parse(sPara);
                            break;
                        case "HOTKEY_MOVE":
                            Hotkey_Move.Parse(sPara);
                            break;
                        case "HOTKEY_MAGNET":
                            Hotkey_Magnet.Parse(sPara);
                            break;

						case "WHITE_TRAY_ICON":
							if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
								WhiteTrayIcon = true;
							else
								WhiteTrayIcon = false;
							break;
                        case "HIDE_IN_ALTTAB":
                            if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
                                globalRoot.HideInAltTab = true;
                            else
                                globalRoot.HideInAltTab = false;
                            break;
                        case "SNAPSHOT_PATH":
							SnapshotBasePath = sPara;
							if (!SnapshotBasePath.EndsWith("/") && !SnapshotBasePath.EndsWith("\\"))
								SnapshotBasePath += "/";
							break;
                        case "OPEN_INTO_SNAP":
                            if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "OFF")
                                OpenIntoSnapMode = true;
                            else
                                OpenIntoSnapMode = false;
                            break;
                        case "DRAWING_ICON":
                            if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
                                ToolsEnabled = false;
                            break;
                        case "ARROW":           // angle in degrees, len in % of the screen width
                            tab = sPara.Split(',');
                            if (tab.Length != 2) break;
                            if (float.TryParse(tab[0],NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out tempf))
                                ArrowAngle = tempf * Math.PI / 180;
                            if (float.TryParse(tab[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out tempf))
                                ArrowLen = tempf / 100.0 * System.Windows.SystemParameters.PrimaryScreenWidth;
                            break;
                        case "DEFAULT_ARROW":
                            if (sPara.ToUpper() == "START" )
                                DefaultArrow_start = true;
                            if (sPara.ToUpper() == "END")
                                DefaultArrow_start = false;
                            break;
                        case "TEXT":           // Font(string),italique(boolean),Bold(boolean),size(float) of the text in % of the screen, also defines the size of the
                            tab = sPara.Split(',');
                            if (tab.Length != 4) break;
                            TextFont = tab[0];
                            string s = tab[1];
                            if (s.ToUpper() == "FALSE" || s == "0" || s.ToUpper() == "OFF")
                                TextItalic = false;
                            else if (s.ToUpper() == "TRUE" || s == "1" || s.ToUpper() == "ON")
                                TextItalic = true;
                            s = tab[2];
                            if (s.ToUpper() == "FALSE" || s == "0" || s.ToUpper() == "OFF")
                                TextBold = false;
                            else if (s.ToUpper() == "TRUE" || s == "1" || s.ToUpper() == "ON")
                                TextBold = true;
                            if (float.TryParse(tab[3], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out tempf))
                                TextSize = (int)(tempf / 100.0 * System.Windows.SystemParameters.PrimaryScreenWidth);
                            break;
                        case "MAGNET":
                            if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
                                MagneticRadius = -MIN_MAGNETIC;
                            else if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
                                MagneticRadius = MIN_MAGNETIC;
                            else if (float.TryParse(sPara, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out tempf))
                                MagneticRadius = (int)(tempf / 100.0 * System.Windows.SystemParameters.PrimaryScreenWidth);
                            break;
                        case "ERASER_ICON":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								EraserEnabled = false;
							break;
						case "POINTER_ICON":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								PointerEnabled = false;
                            break;
                        case "ALTTAB_POINTER":
                            if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
                                AltTabPointer = true;
                            else
                                AltTabPointer = false;
                            break;
                        case "PEN_WIDTH_AT_SELECTION":
                            if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
                                WidthAtPenSel = false;
                            else if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
                                WidthAtPenSel = true;
                            break;
                        case "PEN_WIDTH_ICON":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								PenWidthEnabled = false;
							else if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
								PenWidthEnabled = true;
							break;
						case "SNAPSHOT_ICON":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								SnapEnabled = false;
							break;
						case "CLOSE_ON_SNAP":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								CloseOnSnap = "false";
							else if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
								CloseOnSnap = "true";
							else if (sPara.ToUpper() == "BLANKONLY")
								CloseOnSnap = "blankonly";
							break;
						case "ALWAYS_HIDE_TOOLBAR":
							if (sPara.ToUpper() == "TRUE" || sPara == "1" || sPara.ToUpper() == "ON")
								AlwaysHideToolbar = true;
							break;
						case "UNDO_ICON":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								UndoEnabled = false;
							break;
						case "CLEAR_ICON":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								ClearEnabled = false;
							break;
						case "PAN_ICON":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								PanEnabled = false;
							break;
						case "INKVISIBLE_ICON":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								InkVisibleEnabled = false;
							break;
						case "ALLOW_DRAGGING_TOOLBAR":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								AllowDraggingToolbar = false;
							break;
						case "ALLOW_HOTKEY_IN_POINTER_MODE":
							if (sPara.ToUpper() == "FALSE" || sPara == "0" || sPara.ToUpper() == "OFF")
								AllowHotkeyInPointerMode = false;
							break;
						case "TOOLBAR_LEFT":
							if (int.TryParse(sPara, out tempi))
								gpButtonsLeft = tempi;
							break;
						case "TOOLBAR_TOP":
							if (int.TryParse(sPara, out tempi))
								gpButtonsTop = tempi;
							break;
						case "TOOLBAR_HEIGHT":
							if (float.TryParse(sPara, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out tempf))
								ToolbarHeight = tempf;
							break;
						case "CANVAS_CURSOR":
							if (sPara == "0")
								CanvasCursor = 0;
							else if (sPara == "1")
								CanvasCursor = 1;
							break;
						case "WINDOW_POS": // if not defined, no window else 2 to 4 integers Top,Left,[Width/Height,[Opacity]]
							tab = sPara.Split(',');
							if (tab.Length >= 2) { FormTop = Int32.Parse(tab[0]);FormLeft = Int32.Parse(tab[1]); };
							if (tab.Length >= 3 ) { FormWidth = Int32.Parse(tab[2]); }
							if (tab.Length >= 4) { FormOpacity = Int32.Parse(tab[3]); }
							break;
                        case "GRAY_BOARD1": // if not defined, no window else 2 to 4 integers Top,Left,[Width/Height,[Opacity]]
                            tab = sPara.Split(',');
                            if (tab.Length == 4)
                            {
                                for(int i=0; i<4; i++)
                                    Gray1[i] = Int32.Parse(tab[i]);
                            };
                            break;
                        case "GRAY_BOARD2": // if not defined, no window else 2 to 4 integers Top,Left,[Width/Height,[Opacity]]
                            tab = sPara.Split(',');
                            if (tab.Length == 4)
                            {
                                for (int i = 0; i < 4; i++)
                                    Gray2[i] = Int32.Parse(tab[i]);
                            };
                            break;
                        case "TOOLBAR_COLOR": // if not defined, no window else 2 to 4 integers Top,Left,[Width/Height,[Opacity]]
                            tab = sPara.Split(',');
                            if (tab.Length == 4)
                            {
                                for (int i = 0; i < 4; i++)
                                    ToolbarBGColor[i] = Int32.Parse(tab[i]);
                            };
                            break;
                        case "BOARDATOPENING":
                            if (Int32.TryParse(sPara, out tempi))
                                BoardAtOpening  = tempi;
                            if (BoardAtOpening != 4)
                                BoardSelected = BoardAtOpening;
                            break;

                        case "VIDEO_RECORD_MODE":
                            try
                            {
                                this.VideoRecordMode = (VideoRecordMode)Enum.Parse(typeof(VideoRecordMode), sPara, false);
                            }
                            catch
                            {
                                ;
                            }
                            //if (Int32.TryParse(sPara, out tempi))
                            //    VideoRecordMode = (VideoRecordMode)tempi;
                            break;
                        case "OBS_WS_URL":
                            ObsUrl = sPara;
                            break;
                        case "OBS_WS_PWD":
                            ObsPwd = sPara;
                            break;
                        case "FFMPEG_CMD":
                            FFMpegCmd = sPara;
                            break;
    }
}
			}
			fini.Close();
		}

		public void SaveOptions(string file)
		{
			if (!File.Exists(file))
				file = AppDomain.CurrentDomain.BaseDirectory + file;
			if (!File.Exists(file))
				return;

			FileStream fini = new FileStream(file, FileMode.Open);
			StreamReader srini = new StreamReader(fini);
			string sLine = "";
			string sNameO = "";
			string sName = "", sPara = "";

			List<string> writelines = new List<string>();

			while (sLine != null)
			{
				sPara = "";
				sLine = srini.ReadLine();
				if
				(
					sLine != null &&
					sLine != "" &&
					sLine.Substring(0, 1) != "-" &&
					sLine.Substring(0, 1) != "%" &&
					sLine.Substring(0, 1) != "'" &&
					sLine.Substring(0, 1) != "/" &&
					sLine.Substring(0, 1) != "!" &&
					sLine.Substring(0, 1) != "[" &&
					sLine.Substring(0, 1) != "#" &&
					sLine.Contains("=") &&
					!sLine.Substring(sLine.IndexOf("=") + 1).Contains("=")
				)
				{
					sNameO = sLine.Substring(0, sLine.IndexOf("="));
					sName = sNameO.Trim().ToUpper();

					if (sName.StartsWith("PEN"))
					{
						int penid = 0;
						if (int.TryParse(sName.Substring(3, 1), out penid) && penid >= 0 && penid < MaxPenCount)
						{
							if (sName.EndsWith("_ENABLED"))
							{
								if (PenEnabled[penid])
									sPara = "True";
								else
									sPara = "False";
							}
							else if (sName.EndsWith("_RED"))
							{
								sPara = PenAttr[penid].Color.R.ToString();
							}
							else if (sName.EndsWith("_GREEN"))
							{
								sPara = PenAttr[penid].Color.G.ToString();
							}
							else if (sName.EndsWith("_BLUE"))
							{
								sPara = PenAttr[penid].Color.B.ToString();
							}
							else if (sName.EndsWith("_ALPHA"))
							{
								sPara = (255 - PenAttr[penid].Transparency).ToString();
							}
							else if (sName.EndsWith("_WIDTH"))
							{
								sPara = ((int)PenAttr[penid].Width).ToString();
							}
							else if (sName.EndsWith("_HOTKEY"))
							{
								sPara = Hotkey_Pens[penid].ToString();
							}
						}

					}

					switch (sName)
					{
                        case "ALT_AS_TEMPORARY_COMMAND":
                            if (AltAsOneCommand)
                                sPara = "True";
                            else
                                sPara = "False";
                            break;
                        case "LANGUAGE_FILE":
							sPara = Local.CurrentLanguageFile;
							break;
						case "HOTKEY_GLOBAL":
							sPara = Hotkey_Global.ToString();
							break;
						case "HOTKEY_ERASER":
							sPara = Hotkey_Eraser.ToString();
							break;
						case "HOTKEY_INKVISIBLE":
							sPara = Hotkey_InkVisible.ToString();
							break;
						case "HOTKEY_POINTER":
							sPara = Hotkey_Pointer.ToString();
							break;
						case "HOTKEY_PAN":
							sPara = Hotkey_Pan.ToString();
							break;
						case "HOTKEY_UNDO":
							sPara = Hotkey_Undo.ToString();
							break;
						case "HOTKEY_REDO":
							sPara = Hotkey_Redo.ToString();
							break;
						case "HOTKEY_SNAPSHOT":
							sPara = Hotkey_Snap.ToString();
							break;
						case "HOTKEY_CLEAR":
							sPara = Hotkey_Clear.ToString();
							break;
                        case "HOTKEY_VIDEOREC":
                            sPara = Hotkey_Video.ToString();
                            break;
                        case "HOTKEY_DOCKUNDOCK":
                            sPara = Hotkey_DockUndock.ToString();
                            break;
                        case "HOTKEY_CLOSE":
                            sPara = Hotkey_Close.ToString();
                            break;
                        case "HOTKEY_HAND":
                            sPara = Hotkey_Hand.ToString();
                            break;
                        case "HOTKEY_LINE":
                            sPara = Hotkey_Line.ToString();
                            break;
                        case "HOTKEY_RECT":
                            sPara = Hotkey_Rect.ToString();
                            break;
                        case "HOTKEY_OVAL":
                            sPara = Hotkey_Oval.ToString();
                            break;
                        case "HOTKEY_ARROW":
                            sPara = Hotkey_Arrow.ToString();
                            break;
                        case "HOTKEY_TEXT":
                            sPara = Hotkey_Text.ToString();
                            break;
                        case "HOTKEY_NUMBCHIP":
                            sPara = Hotkey_Numb.ToString();
                            break;
                        case "HOTKEY_EDIT":
                            sPara = Hotkey_Edit.ToString();
                            break;
                        case "HOTKEY_MOVE":
                            sPara = Hotkey_Move.ToString();
                            break;
                        case "HOTKEY_MAGNET":
                            sPara = Hotkey_Magnet.ToString();
                            break;

                        case "WHITE_TRAY_ICON":
							if (WhiteTrayIcon)
								sPara = "True";
							else
								sPara = "False";
							break;
                        case "HIDE_IN_ALTTAB":
                            if (WhiteTrayIcon)
                                sPara = "True";
                            else
                                sPara = "False";
                            break;
                        case "SNAPSHOT_PATH":
							sPara = SnapshotBasePath;
							break;
                        case "OPEN_INTO_SNAP":
                            sPara = OpenIntoSnapMode?"True":"False";
                            break;
                        case "DRAWING_ICON":
                            if (ToolsEnabled)
                                sPara = "True";
                            else
                                sPara = "False";
                            break;
                        case "ARROW":           // angle in degrees, len in % of the screen width
                            sPara = (ArrowAngle / Math.PI * 180.0).ToString(CultureInfo.InvariantCulture) +","+ (ArrowLen / System.Windows.SystemParameters.PrimaryScreenWidth * 100.0).ToString(CultureInfo.InvariantCulture);
                            break;
                        case "DEFAULT_ARROW":
                            sPara = DefaultArrow_start ? "START" : "END";
                            break;
                        case "TEXT":           // size of the tag in % of the screen
                            sPara = TextFont+","+(TextItalic?"True":"False")+","+ (TextBold ? "True" : "False")+","+(TextSize / System.Windows.SystemParameters.PrimaryScreenWidth *100.0).ToString(CultureInfo.InvariantCulture);
                            break;
                        case "MAGNET":
                            sPara = (MagneticRadius / System.Windows.SystemParameters.PrimaryScreenWidth * 100.0).ToString(CultureInfo.InvariantCulture);
                            break;
                        case "ERASER_ICON":
							if (EraserEnabled)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "POINTER_ICON":
							if (PointerEnabled)
								sPara = "True";
							else
								sPara = "False";
							break;
                        case "ALTTAB_POINTER":
                            sPara = AltTabPointer?"True":"False";
                            break;
                        case "PEN_WIDTH_AT_SELECTION":
                            sPara = WidthAtPenSel ? "True" : "False";
                            break;
                        case "PEN_WIDTH_ICON":
							if (PenWidthEnabled)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "SNAPSHOT_ICON":
							if (SnapEnabled)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "CLOSE_ON_SNAP":
							if (CloseOnSnap == "true")
								sPara = "True";
							else if (CloseOnSnap == "false")
								sPara = "False";
							else
								sPara = "BlankOnly";
							break;
						case "ALWAYS_HIDE_TOOLBAR":
							if (AlwaysHideToolbar)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "UNDO_ICON":
							if (UndoEnabled)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "CLEAR_ICON":
							if (ClearEnabled)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "PAN_ICON":
							if (PanEnabled)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "INKVISIBLE_ICON":
							if (PanEnabled)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "ALLOW_DRAGGING_TOOLBAR":
							if (AllowDraggingToolbar)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "ALLOW_HOTKEY_IN_POINTER_MODE":
							if (AllowHotkeyInPointerMode)
								sPara = "True";
							else
								sPara = "False";
							break;
						case "TOOLBAR_LEFT":
							sPara = gpButtonsLeft.ToString();
							break;
						case "TOOLBAR_TOP":
							sPara = gpButtonsTop.ToString();
							break;
						case "TOOLBAR_HEIGHT":
							sPara = ToolbarHeight.ToString(CultureInfo.InvariantCulture);
							break;
						case "CANVAS_CURSOR":
							sPara = CanvasCursor.ToString();
							break;
                        case "WINDOW_POS": // if not defined, no window else 2 to 4 integers Top,Left,[Width/Height,[Opacity]]
                            sPara = FormTop.ToString() + "," + FormLeft.ToString() + "," + FormWidth.ToString() + "," + FormOpacity.ToString();
                            break;
                        case "GRAYBOARD1": 
                            sPara = Gray1[0].ToString() + "," + Gray1[1].ToString() + "," + Gray1[2].ToString() + "," + Gray1[3].ToString();
                            break;
                        case "GRAYBOARD2":
                            sPara = Gray2[0].ToString() + "," + Gray2[1].ToString() + "," + Gray2[2].ToString() + "," + Gray2[3].ToString();
                            break;
                        case "TOOLBAR_COLOR":
                            sPara = ToolbarBGColor[0].ToString() + "," + ToolbarBGColor[1].ToString() + "," + ToolbarBGColor[2].ToString() + "," + ToolbarBGColor[3].ToString();
                            break;
                        case "BOARDATOPENING":
                            sPara = BoardAtOpening.ToString();
                            break;
                        case "VIDEO_RECORD_MODE":
                            sPara = VideoRecordMode.ToString();
                            break;
                        case "OBS_WS_URL":
                            sPara = ObsUrl;
                            break;
                        case "OBS_WS_PWD":
                            sPara = ObsPwd;
                            break;
                        case "FFMPEG_CMD":
                            sPara = FFMpegCmd;
                            break;
                    }
                }
				if (sPara != "")
					writelines.Add(sNameO + "= " + sPara);
				else if (sLine != null)
					writelines.Add(sLine);
			}
			fini.Close();

			FileStream frini = new FileStream(file, FileMode.Create);
			StreamWriter swini = new StreamWriter(frini);
			swini.AutoFlush = true;
			foreach (string line in writelines)
				swini.WriteLine(line);
			frini.Close();
		}

		private void OnAbout(object sender, EventArgs e)
		{
			FormAbout FormAbout = new FormAbout();
			FormAbout.Show();
		}
		/*
		private void OnPenSetting(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("notepad.exe", "pens.ini");
		}
		*/
		private void OnOptions(object sender, EventArgs e)
		{
            //ReadOptions("pens.ini");
            //ReadOptions("config.ini");
            //ReadOptions("hotkeys.ini");
            if (FormOptions != null)
                return;
            if (FormDisplay != null || FormCollection != null)
                return;
            FormOptions = new FormOptions(this);
			FormOptions.Show();
		}

		public void SetHotkey()
		{
			int modifier = 0;
			if (Hotkey_Global.Control) modifier |= 0x2;
			if (Hotkey_Global.Alt) modifier |= 0x1;
			if (Hotkey_Global.Shift) modifier |= 0x4;
			if (Hotkey_Global.Win) modifier |= 0x8;
			if (modifier != 0)
				RegisterHotKey(IntPtr.Zero, 0, modifier, Hotkey_Global.Key);
		}

		public void UnsetHotkey()
		{
			int modifier = 0;
			if (Hotkey_Global.Control) modifier |= 0x2;
			if (Hotkey_Global.Alt) modifier |= 0x1;
			if (Hotkey_Global.Shift) modifier |= 0x4;
			if (Hotkey_Global.Win) modifier |= 0x8;
			if (modifier != 0)
				UnregisterHotKey(IntPtr.Zero, 0);
		}

		public void ChangeLanguage(string filename)
		{
			Local.LoadLocalFile(filename);

			trayMenu.MenuItems.Clear();
			trayMenu.MenuItems.Add(Local.MenuEntryAbout + "...", OnAbout);
			trayMenu.MenuItems.Add(Local.MenuEntryOptions + "...", OnOptions);
			trayMenu.MenuItems.Add("-");
			trayMenu.MenuItems.Add(Local.MenuEntryExit, OnExit);
		}

		private void OnExit(object sender, EventArgs e)
		{
			UnsetHotkey();

			trayIcon.Dispose();
			Application.Exit();
		}

        public int HiMetricToPixel(double hi)
        {
            return Convert.ToInt32(hi * 0.037795280352161);
        }

        public int PixelToHiMetric(double pi)
        {
            return Convert.ToInt32(pi / 0.037795280352161);
        }

		[DllImport("user32.dll")]
		private static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
		[DllImport("user32.dll")]
		private static extern int UnregisterHotKey(IntPtr hwnd, int id);
	}
}

