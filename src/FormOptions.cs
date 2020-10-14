using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gInk
{
	public partial class FormOptions : Form
	{
		public Root Root;

		Label[] lbPens = new Label[10];
		CheckBox[] cbPens = new CheckBox[10];
		PictureBox[] pboxPens = new PictureBox[10];
		ComboBox[] comboPensAlpha = new ComboBox[10];
		ComboBox[] comboPensWidth = new ComboBox[10];
		Label lbcbPens, lbpboxPens, lbcomboPensAlpha, lbcomboPensWidth;

		Label[] lbHotkeyPens = new Label[10];
		HotkeyInputBox[] hiPens = new HotkeyInputBox[10];

		public FormOptions(Root root)
		{
			Root = root;
			InitializeComponent();
		}

		private void FormOptions_Load(object sender, EventArgs e)
		{
			Root.UnsetHotkey();

			if (Root.EraserEnabled)
				cbEraserEnabled.Checked = true;
			if (Root.PointerEnabled)
				cbPointerEnabled.Checked = true;
			if (Root.SnapEnabled)
				cbSnapEnabled.Checked = true;
			if (Root.UndoEnabled)
				cbUndoEnabled.Checked = true;
			if (Root.ClearEnabled)
				cbClearEnabled.Checked = true;
            WidthAtPenSelCb.Checked = Root.WidthAtPenSel;
            cbWidthEnabled.Checked = Root.PenWidthEnabled;
            if (Root.PanEnabled)
				cbPanEnabled.Checked = true;
			if (Root.InkVisibleEnabled)
				cbInkVisibleEnabled.Checked = true;
            if (Root.ToolsEnabled)
                cbToolsEnabled.Checked = true;

            if (Root.WhiteTrayIcon)
				cbWhiteIcon.Checked = true;
			if (Root.AllowDraggingToolbar)
				cbAllowDragging.Checked = true;
			if (Root.AllowHotkeyInPointerMode)
				cbAllowHotkeyInPointer.Checked = true;

            ToolBarHeight.Text = string.Format("{0:F1}", Root.ToolbarHeight * 100);
            //MoveToolBarCb.Checked = Root.AllowDraggingToolbar;

			comboCanvasCursor.SelectedIndex = Root.CanvasCursor;

            BoardAtOpenCombo.SelectedIndex = Root.BoardAtOpening;
            BoardCustColorPnl.BackColor = Color.FromArgb(Root.Gray1[0], Root.Gray1[1], Root.Gray1[2], Root.Gray1[3]);


            tbSnapPath.Text = Root.SnapshotBasePath;
            this.OpenIntoSnapCb.Checked = Root.OpenIntoSnapMode;
            ShowFloatingWinCb.Checked = Root.FormOpacity > 0;
            ArrHdAperture.Text = (Root.ArrowAngle * 180.0 / Math.PI).ToString("#0",CultureInfo.InvariantCulture);
            ArrHdLength.Text = (Root.ArrowLen / System.Windows.SystemParameters.PrimaryScreenWidth *100.0).ToString("#0.0000",CultureInfo.InvariantCulture);
            Magnet_TB.Text = (Root.MagneticRadius / System.Windows.SystemParameters.PrimaryScreenWidth * 100.0).ToString("#0.0000", CultureInfo.InvariantCulture);
            DefArrStartCb.Checked = Root.DefaultArrow_start;
            lbNote.ForeColor = Color.Black;

			lbcbPens = new Label();
			lbcbPens.Left = (int)(this.Width / 500.0 * 25);
			lbcbPens.Width = 100;
			lbcbPens.Top = 15;
			
			tabPage2.Controls.Add(lbcbPens);
			lbpboxPens = new Label();
			lbpboxPens.Left = (int)(this.Width / 500.0 * 140);
			lbpboxPens.Width = 60;
			lbpboxPens.Top = 15;
			
			tabPage2.Controls.Add(lbpboxPens);
			lbcomboPensAlpha = new Label();
			lbcomboPensAlpha.Left = (int)(this.Width / 500.0 * 200);
			lbcomboPensAlpha.Width = 100;
			lbcomboPensAlpha.Top = 15;
			
			tabPage2.Controls.Add(lbcomboPensAlpha);
			lbcomboPensWidth = new Label();
			lbcomboPensWidth.Left = (int)(this.Width / 500.0 * 325);
			lbcomboPensWidth.Width = 100;
			lbcomboPensWidth.Top = 15;
			
			tabPage2.Controls.Add(lbcomboPensWidth);

			for (int p = 0; p < Root.MaxPenCount; p++)
			{
				int top = p * (int)(this.Height * 0.075) + (int)(this.Height * 0.09);
				lbPens[p] = new Label();
				lbPens[p].Left = (int)(this.Width / 500.0 * 60);
				lbPens[p].Width = 80;
				lbPens[p].Top = top;

				cbPens[p] = new CheckBox();
				cbPens[p].Left = (int)(this.Width / 500.0 * 30);
				cbPens[p].Width = 25;
				cbPens[p].Top = top - 5;
				cbPens[p].Text = "";
				cbPens[p].Checked = Root.PenEnabled[p];
				cbPens[p].CheckedChanged += cbPens_CheckedChanged;

				pboxPens[p] = new PictureBox();
				pboxPens[p].Left = (int)(this.Width / 500.0 * 145);
				pboxPens[p].Top = top;
				pboxPens[p].Width = 15;
				pboxPens[p].Height = 15;
				pboxPens[p].BackColor = Root.PenAttr[p].Color;
				pboxPens[p].Click += pboxPens_Click;

				comboPensAlpha[p] = new ComboBox();
				
				comboPensAlpha[p].Left = (int)(this.Width / 500.0 * 205);
				comboPensAlpha[p].Top = top - 2;
				comboPensAlpha[p].Width = 100;
				comboPensAlpha[p].Text = (255 - Root.PenAttr[p].Transparency).ToString();
				comboPensAlpha[p].TextChanged += comboPensAlpha_TextChanged;

				comboPensWidth[p] = new ComboBox();
				
				comboPensWidth[p].Left = (int)(this.Width / 500.0 * 330);
				comboPensWidth[p].Top = top - 2;
				comboPensWidth[p].Width = 100;
				comboPensWidth[p].Text = ((int)Root.PenAttr[p].Width).ToString();
				comboPensWidth[p].TextChanged += comboPensWidth_TextChanged;

				tabPage2.Controls.Add(lbPens[p]);
				tabPage2.Controls.Add(cbPens[p]);
				tabPage2.Controls.Add(pboxPens[p]);
				tabPage2.Controls.Add(comboPensAlpha[p]);
				tabPage2.Controls.Add(comboPensWidth[p]);
			}

			cbAllowHotkeyInPointer.Top = (int)(this.Height * 0.18);

			for (int p = 0; p < Root.MaxPenCount; p++)
			{
				int top = p * (int)(this.Height * 0.055) + (int)(this.Height * 0.24);
				lbHotkeyPens[p] = new Label();
				lbHotkeyPens[p].Left = 20;
				lbHotkeyPens[p].Width = 80;
				lbHotkeyPens[p].Top = top;

				hiPens[p] = new HotkeyInputBox();
				hiPens[p].Hotkey = Root.Hotkey_Pens[p];
				hiPens[p].Left = 100;
				hiPens[p].Width = 120;
				hiPens[p].Top = top;
				hiPens[p].OnHotkeyChanged += hi_OnHotkeyChanged;

				tabPage3.Controls.Add(lbHotkeyPens[p]);
				tabPage3.Controls.Add(hiPens[p]);
			}

            AltAsOneCommandCb.Checked = Root.AltAsOneCommand;

			hiGlobal.Hotkey = Root.Hotkey_Global;
			hiEraser.Hotkey = Root.Hotkey_Eraser;
			hiPan.Hotkey = Root.Hotkey_Pan;
			hiInkVisible.Hotkey = Root.Hotkey_InkVisible;
			hiPointer.Hotkey = Root.Hotkey_Pointer;
			hiSnapshot.Hotkey = Root.Hotkey_Snap;
			hiUndo.Hotkey = Root.Hotkey_Undo;
			hiRedo.Hotkey = Root.Hotkey_Redo;
			hiClear.Hotkey = Root.Hotkey_Clear;

            hiToolHand.Hotkey = Root.Hotkey_Hand;
            hiToolLine.Hotkey = Root.Hotkey_Line;
            hiToolRect.Hotkey = Root.Hotkey_Rect;
            hiToolOval.Hotkey = Root.Hotkey_Oval;
            hiToolArrow.Hotkey = Root.Hotkey_Arrow;
            hiToolNumb.Hotkey = Root.Hotkey_Numb;
            HiToolText.Hotkey = Root.Hotkey_Text;
            hiToolEdit.Hotkey = Root.Hotkey_Edit;
            hiToolMagnet.Hotkey = Root.Hotkey_Magnet;


            FormOptions_LocalReload();
		}

		private void FormOptions_LocalReload()
		{   string shortTxt(string sin)
            {
                int i = sin.IndexOf("(");
                if (i < 0) i = sin.Length;
                return sin.Substring(0, i);
            }
			this.Text = Root.Local.MenuEntryOptions + " - gInk";
			tabControl1.TabPages[0].Text = Root.Local.OptionsTabGeneral;
			tabControl1.TabPages[1].Text = Root.Local.OptionsTabPens;
			tabControl1.TabPages[2].Text = Root.Local.OptionsTabHotkeys;
            this.lblToolbarHeight.Text = Root.Local.OptionsGeneralToolbarHeight;
			this.lbLanguage.Text = Root.Local.OptionsGeneralLanguage;
			this.lbCanvascursor.Text = Root.Local.OptionsGeneralCanvascursor;
			this.lbSnapshotsavepath.Text = Root.Local.OptionsGeneralSnapshotsavepath;
            this.OpenIntoSnapCb.Text = Root.Local.OptionsGeneralOpenIntoSnapMode;
            this.cbWhiteIcon.Text = Root.Local.OptionsGeneralWhitetrayicon;
			this.cbAllowDragging.Text = Root.Local.OptionsGeneralAllowdragging;
            this.ShowFloatingWinCb.Text = Root.Local.OptionsGeneralShowFloatingWindow;
            this.SaveWindowPosBtn.Text = Root.Local.OptionsGeneralSaveFloatingWindowPos;
            this.ArrwGrp.Text = Root.Local.OptionsGeneralArrowHead;
            this.ArrHdAptLbl.Text = Root.Local.OptionsGeneralArrowHeadApt;
            this.ArrHdLenLbl.Text = Root.Local.OptionsGeneralArrowHeadLen;
            this.DefTxtLbl.Text = Root.Local.OptionsGeneralDefaultTextLbl;
            this.DefaultFontBtn.Text = Root.Local.OptionsGeneralDefaultTextBtn;
            this.DefArrStartCb.Text = Root.Local.OptionsGeneralDefaultArrHdBtn;
            this.MagnetLbl.Text = Root.Local.OptionsGeneralMagnetLbl;
            this.SaveConfigBtn.Text = Root.Local.OptionsGeneralSaveConfigToFile;
			this.lbNote.Text = Root.Local.OptionsGeneralNotePenwidth;

            this.AltAsOneCommandCb.Text = Root.Local.OptionsHotKeyAltAsOneCommand;
			this.lbHkClear.Text = shortTxt(Root.Local.ButtonNameClear);
			this.lbHkEraser.Text = shortTxt(Root.Local.ButtonNameErasor);
			this.lbHkInkVisible.Text = shortTxt(Root.Local.ButtonNameInkVisible);
			this.lbHkPan.Text = shortTxt(Root.Local.ButtonNamePan);
			this.lbHkPointer.Text = shortTxt(Root.Local.ButtonNameMousePointer);
			this.lbHkRedo.Text = shortTxt(Root.Local.ButtonNameRedo);
			this.lbHkSnapshot.Text = shortTxt(Root.Local.ButtonNameSnapshot);
			this.lbHkUndo.Text = shortTxt(Root.Local.ButtonNameUndo);
            this.lbHkHand.Text = shortTxt(Root.Local.ButtonNameHand);
            this.lbHkLine.Text = shortTxt(Root.Local.ButtonNameLine);
            this.lbHkRect.Text = shortTxt(Root.Local.ButtonNameRect);
            this.lbHkOval.Text = shortTxt(Root.Local.ButtonNameOval);
            this.lbHkArrow.Text = shortTxt(Root.Local.ButtonNameArrow);
            this.lbHkNumb.Text = shortTxt(Root.Local.ButtonNameNumb);
            this.lbHkText.Text = shortTxt(Root.Local.ButtonNameText);
            this.lbHkEdit.Text = shortTxt(Root.Local.ButtonNameEdit);
            this.lbHkMagn.Text = shortTxt(Root.Local.ButtonNameMagn);

            this.lbGlobalHotkey.Text = Root.Local.OptionsHotkeysglobal;
            this.cbAllowHotkeyInPointer.Text = Root.Local.OptionsHotkeysEnableinpointer;

			this.comboCanvasCursor.Items[0] = Root.Local.OptionsGeneralCanvascursorArrow;
			this.comboCanvasCursor.Items[1] = Root.Local.OptionsGeneralCanvascursorPentip;

            this.BoardBx.Text = Root.Local.OptionsGeneralBoardBox;
            this.BoardAtOpenLbl.Text = Root.Local.OptionsGeneralBoardAtOpenLbl;
            this.BoardCustColorLbl.Text = Root.Local.OptionsGeneralBoardCustColorLbl;
            this.BoardAtOpenCombo.Items[0] = Root.Local.BoardTransparent;
            this.BoardAtOpenCombo.Items[1] = Root.Local.BoardWhite;
            this.BoardAtOpenCombo.Items[2] = Root.Local.BoardGray;
            this.BoardAtOpenCombo.Items[3] = Root.Local.BoardBlack;
            this.BoardAtOpenCombo.Items[4] = Root.Local.BoardLast;
            
            for (int p = 0; p < Root.MaxPenCount; p++)
			{
				comboPensAlpha[p].Items.Clear();
				comboPensWidth[p].Items.Clear();
				comboPensAlpha[p].Items.AddRange(new object[] { Root.Local.OptionsPensPencil, Root.Local.OptionsPensHighlighter });
				comboPensWidth[p].Items.AddRange(new object[] { Root.Local.OptionsPensThin, Root.Local.OptionsPensNormal, Root.Local.OptionsPensThick });

				lbPens[p].Text = Root.Local.ButtonNamePen[p];
				lbHotkeyPens[p].Text = Root.Local.ButtonNamePen[p];

				lbcbPens.Text = Root.Local.OptionsPensShow;
				lbpboxPens.Text = Root.Local.OptionsPensColor;
				lbcomboPensAlpha.Text = Root.Local.OptionsPensAlpha;
				lbcomboPensWidth.Text = Root.Local.OptionsPensWidth;
			}
            WidthAtPenSelCb.Text = Root.Local.OptionsPensWidthAtSelection;

				comboLanguage.Items.Clear();
			List<string> langs = Root.Local.GetLanguagenames();
			foreach (string languagename in langs)
			{
				comboLanguage.Items.Add(languagename);
			}

			string ln = Root.Local.GetLanguagenameByFilename(Root.Local.CurrentLanguageFile);
			if (comboLanguage.Items.Contains(ln))
				comboLanguage.SelectedIndex = comboLanguage.Items.IndexOf(ln);
		}

		private void comboPensAlpha_TextChanged(object sender, EventArgs e)
		{
			for (int p = 0; p < Root.MaxPenCount; p++)
				if ((ComboBox)sender == comboPensAlpha[p])
				{
					byte o;
					if (byte.TryParse(comboPensAlpha[p].Text, out o) && o >= 0 && o <= 255)
					{
						Root.PenAttr[p].Transparency = (byte)(255 - o);
						comboPensAlpha[p].BackColor = Color.White;
					}
					else
					{
						comboPensAlpha[p].BackColor = Color.IndianRed;
					}
				}
		}

		private void comboPensWidth_TextChanged(object sender, EventArgs e)
		{
			for (int p = 0; p < Root.MaxPenCount; p++)
				if ((ComboBox)sender == comboPensWidth[p])
				{
					int o;
					if (int.TryParse(comboPensWidth[p].Text, out o) && o >= 30 && o <= 3000)
					{
						Root.PenAttr[p].Width = o;
						comboPensWidth[p].BackColor = Color.White;
					}
					else
					{
						comboPensWidth[p].BackColor = Color.IndianRed;
					}
				}
		}

		private void pboxPens_Click(object sender, EventArgs e)
		{
			for (int p = 0; p < Root.MaxPenCount; p++)
				if ((PictureBox)sender == pboxPens[p])
				{
                    PenModifyDlg dlg = new PenModifyDlg(Root);
                    if (dlg.ModifyPen(ref Root.PenAttr[p]))
                    {
                        (sender as PictureBox).BackColor = Color.FromArgb(255, Root.PenAttr[p].Color);
                        comboPensAlpha[p].Text = string.Format("{0}", Root.PenAttr[p].Transparency);
                        comboPensWidth[p].Text = string.Format("{0}", Root.PenAttr[p].Width);
                    }
				}
		}

		private void cbPens_CheckedChanged(object sender, EventArgs e)
		{
			for (int p = 0; p < Root.MaxPenCount; p++)
				if ((CheckBox)sender == cbPens[p])
					Root.PenEnabled[p] = cbPens[p].Checked;
		}

		private void FormOptions_FormClosing(object sender, FormClosingEventArgs e)
		{
			Root.SetHotkey();

            // Save button added
            //Root.SaveOptions("pens.ini");
            //Root.SaveOptions("config.ini");
            //Root.SaveOptions("hotkeys.ini");

            Root.FormOptions = null;

        }

        private void cbWidthEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Root.PenWidthEnabled = cbWidthEnabled.Checked;
			lbNote.ForeColor = Color.Red;
		}

		private void cbEraserEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Root.EraserEnabled = cbEraserEnabled.Checked;
		}

		private void cbPointerEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Root.PointerEnabled = cbPointerEnabled.Checked;
		}

		private void cbSnapEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Root.SnapEnabled = cbSnapEnabled.Checked;
		}

		private void cbUndoEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Root.UndoEnabled = cbUndoEnabled.Checked;
		}

		private void cbClearEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Root.ClearEnabled = cbClearEnabled.Checked;
		}

		private void cbPanEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Root.PanEnabled = cbPanEnabled.Checked;
		}

		private void cbInkVisibleEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Root.InkVisibleEnabled = cbInkVisibleEnabled.Checked;
		}

		private void cbWhiteIcon_CheckedChanged(object sender, EventArgs e)
		{
			Root.WhiteTrayIcon = cbWhiteIcon.Checked;
			Root.SetTrayIconColor();
		}

		private void btSnapPath_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1 = new FolderBrowserDialog();
			folderBrowserDialog1.SelectedPath = Root.SnapshotBasePath;

			DialogResult result = folderBrowserDialog1.ShowDialog();

			if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath))
			{
				tbSnapPath.Text = folderBrowserDialog1.SelectedPath;
				Root.SnapshotBasePath = folderBrowserDialog1.SelectedPath;
			}
		}

		private void tbSnapPath_ModifiedChanged(object sender, EventArgs e)
		{
			Root.SnapshotBasePath = tbSnapPath.Text;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			for (int p = 0; p < Root.MaxPenCount; p++)
			{
				if (comboPensWidth[p].Text == Root.Local.OptionsPensThin)
				{
					comboPensWidth[p].Text = "30";
				}
				else if (comboPensWidth[p].Text == Root.Local.OptionsPensNormal)
				{
					comboPensWidth[p].Text = "80";
				}
				else if (comboPensWidth[p].Text == Root.Local.OptionsPensThick)
				{
					comboPensWidth[p].Text = "500";
				}

				if (comboPensAlpha[p].Text == Root.Local.OptionsPensPencil)
				{
					comboPensAlpha[p].Text = "255";
				}
				else if (comboPensAlpha[p].Text == Root.Local.OptionsPensHighlighter)
				{
					comboPensAlpha[p].Text = "80";
				}
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Root.CanvasCursor = comboCanvasCursor.SelectedIndex;
		}

		private void cbAllowDragging_CheckedChanged(object sender, EventArgs e)
		{
			Root.AllowDraggingToolbar = cbAllowDragging.Checked;
		}

        private void cbToolsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Root.ToolsEnabled = cbToolsEnabled.Checked;
        }

        private void SaveWindowPosBtn_Click(object sender, EventArgs e)
        {
            Root.FormTop = Root.callForm.Top;
            Root.FormLeft = Root.callForm.Left;
        }

        private void SaveConfigBtn_Click(object sender, EventArgs e)
        {
            Root.SaveOptions("pens.ini");
            Root.SaveOptions("config.ini");
            Root.SaveOptions("hotkeys.ini");
        }

        private void ArrHdFloat_Validating(object sender, CancelEventArgs e)
        {
            float tempf;
            if (!float.TryParse(((TextBox)sender).Text.Replace(",","."), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out tempf))
            {
                e.Cancel = true;
                ((TextBox)sender).Select();
            }
        }

        private void DefaultFontBtn_Click(object sender, EventArgs e)
        {
            FontDlg.Font = new Font(Root.TextFont, (float)Root.TextSize,
                                        (Root.TextItalic ? FontStyle.Italic : FontStyle.Regular) | (Root.TextBold ? FontStyle.Bold : FontStyle.Regular));
            if (FontDlg.ShowDialog() == DialogResult.OK)
            {
                Root.TextFont = FontDlg.Font.Name;
                Root.TextItalic = (FontDlg.Font.Style & FontStyle.Italic) != 0;
                Root.TextBold = (FontDlg.Font.Style & FontStyle.Bold) != 0;
                Root.TextSize = (int)FontDlg.Font.Size;
            }
        }

        private void ArrHdAperture_Validated(object sender, EventArgs e)
        {
            Root.ArrowAngle = float.Parse(ArrHdAperture.Text.Replace(",","."), CultureInfo.InvariantCulture) /180.0*Math.PI;
        }

        private void ArrHdLength_Validated(object sender, EventArgs e)
        {
            Root.ArrowLen = float.Parse(ArrHdLength.Text.Replace(",", "."), CultureInfo.InvariantCulture) / 100.0 * System.Windows.SystemParameters.PrimaryScreenWidth;
        }

        private void ShowFloatingWinCb_Click(object sender, EventArgs e)
        {
            Root.FormOpacity = ((((CheckBox)sender).Checked)?1:-1) * Math.Abs(Root.FormOpacity);
            if (((CheckBox)sender).Checked && (Root.FormTop <= Screen.PrimaryScreen.WorkingArea.Top || Root.FormTop >= Screen.PrimaryScreen.WorkingArea.Bottom || 
                                               Root.FormLeft <= Screen.PrimaryScreen.WorkingArea.Left || Root.FormLeft >= Screen.PrimaryScreen.WorkingArea.Right))
            {
                Root.FormTop = Screen.PrimaryScreen.WorkingArea.Top + 100;
                Root.FormLeft = Screen.PrimaryScreen.WorkingArea.Left + 100;
            }
            if (Root.FormOpacity > 0)
            {
                Root.callForm.Show();
                Root.callForm.Top = Root.FormTop;
                Root.callForm.Left = Root.FormLeft;
                Root.callForm.Width = Root.FormWidth;
                Root.callForm.Height = Root.FormWidth;
                Root.callForm.Opacity = Root.FormOpacity / 100.0;
            }
            else
            {
                Root.callForm.Hide();
            }
        }

        private void Magnet_TB_Validated(object sender, EventArgs e)
        {
            Root.MagneticRadius = (int)(float.Parse(Magnet_TB.Text.Replace(",", "."), CultureInfo.InvariantCulture) / 100.0 * System.Windows.SystemParameters.PrimaryScreenWidth);
        }

        private void DefArrStartCb_CheckedChanged(object sender, EventArgs e)
        {
            Root.DefaultArrow_start = DefArrStartCb.Checked;
        }

        private void AltAsOneCommandCb_CheckedChanged(object sender, EventArgs e)
        {
            Root.AltAsOneCommand = AltAsOneCommandCb.Checked;
        }

        private void OpenIntoSnapCb_CheckedChanged(object sender, EventArgs e)
        {
            Root.OpenIntoSnapMode = OpenIntoSnapCb.Checked;
        }

        private void WidthAtPenSelCb_CheckedChanged(object sender, EventArgs e)
        {
            Root.WidthAtPenSel = WidthAtPenSelCb.Checked;
        }

        private void ToolBarHeight_TextChanged(object sender, EventArgs e)
        {
        }

        private void ToolBarHeight_Validated(object sender, EventArgs e)
        {
            Root.ToolbarHeight = float.Parse(ToolBarHeight.Text.Replace(",", "."), CultureInfo.InvariantCulture) / 100;
        }

        private void ValidateOnEnter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                (sender as TextBox).Select();
                e.Handled = true;
            }
        }

        private void MoveToolBarCb_CheckedChanged(object sender, EventArgs e)
        {
            Root.AllowDraggingToolbar = MoveToolBarCb.Checked;
        }

        private void BoardAtOpenCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Root.BoardAtOpening = BoardAtOpenCombo.SelectedIndex;
        }

        private void BoardCustColorPnl_Click(object sender, EventArgs e)
        {
            PenModifyDlg dlg = new PenModifyDlg(Root);
            dlg.Text = Root.Local.BoardCustColorModifyTitle;
            Microsoft.Ink.DrawingAttributes at = new Microsoft.Ink.DrawingAttributes();

            at.Transparency = (byte)(255 - Root.Gray1[0]);
            at.Color = Color.FromArgb(Root.Gray1[0], Root.Gray1[1], Root.Gray1[2], Root.Gray1[3]);
            at.Width = 0;

            if (dlg.ModifyPen(ref at))
            {
                Root.Gray1[0] = 255 - at.Transparency;
                Root.Gray1[1] = at.Color.R;
                Root.Gray1[2] = at.Color.G;
                Root.Gray1[3] = at.Color.B;
                BoardCustColorPnl.BackColor = Color.FromArgb(Root.Gray1[0], at.Color);
            }

        }

        private void cbAllowHotkeyInPointer_CheckedChanged(object sender, EventArgs e)
		{
			Root.AllowHotkeyInPointerMode = cbAllowHotkeyInPointer.Checked;
		}

		private void hi_OnHotkeyChanged(object sender, EventArgs e)
		{
			foreach (Control c in tabPage3.Controls)
			{
				if (c.GetType() != typeof(HotkeyInputBox))
					continue;
				HotkeyInputBox hi = (HotkeyInputBox)c;

				hi.ExternalConflictFlag = false;
				foreach (Control c2 in tabPage3.Controls)
				{
					if (c2.GetType() != typeof(HotkeyInputBox))
						continue;
					if (c == c2)
						continue;
					HotkeyInputBox hi2 = (HotkeyInputBox)c2;

					if (hi.Hotkey.ConflictWith(hi2.Hotkey))
					{
						hi.ExternalConflictFlag = true;
						break;
					}
				}
			}
		}

		private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboLanguage.Text != Root.Local.GetLanguagenameByFilename(Root.Local.CurrentLanguageFile))
			{
				Root.ChangeLanguage(Root.Local.GetFilenameByLanguagename(comboLanguage.Text));
				FormOptions_LocalReload();
			}
		}
	}
}
