namespace gInk
{
	partial class FormCollection
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
            this.components = new System.ComponentModel.Container();
            this.gpButtons = new System.Windows.Forms.Panel();
            this.btVideo = new System.Windows.Forms.Button();
            this.btInkVisible = new System.Windows.Forms.Button();
            this.btPan = new System.Windows.Forms.Button();
            this.btMagn = new System.Windows.Forms.Button();
            this.btDock = new System.Windows.Forms.Button();
            this.btPenWidth = new System.Windows.Forms.Button();
            this.btHand = new System.Windows.Forms.Button();
            this.btLine = new System.Windows.Forms.Button();
            this.btRect = new System.Windows.Forms.Button();
            this.btOval = new System.Windows.Forms.Button();
            this.btArrow = new System.Windows.Forms.Button();
            this.btNumb = new System.Windows.Forms.Button();
            this.btText = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btEraser = new System.Windows.Forms.Button();
            this.btSnap = new System.Windows.Forms.Button();
            this.btPointer = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btUndo = new System.Windows.Forms.Button();
            this.tiSlide = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gpPenWidth = new System.Windows.Forms.Panel();
            this.pboxPenWidthIndicator = new System.Windows.Forms.PictureBox();
            this.longClickTimer = new System.Windows.Forms.Timer(this.components);
            this.FontDlg = new System.Windows.Forms.FontDialog();
            this.gpButtons.SuspendLayout();
            this.gpPenWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPenWidthIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // gpButtons
            // 
            this.gpButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gpButtons.Controls.Add(this.btVideo);
            this.gpButtons.Controls.Add(this.btInkVisible);
            this.gpButtons.Controls.Add(this.btPan);
            this.gpButtons.Controls.Add(this.btMagn);
            this.gpButtons.Controls.Add(this.btDock);
            this.gpButtons.Controls.Add(this.btPenWidth);
            this.gpButtons.Controls.Add(this.btHand);
            this.gpButtons.Controls.Add(this.btLine);
            this.gpButtons.Controls.Add(this.btRect);
            this.gpButtons.Controls.Add(this.btOval);
            this.gpButtons.Controls.Add(this.btArrow);
            this.gpButtons.Controls.Add(this.btNumb);
            this.gpButtons.Controls.Add(this.btText);
            this.gpButtons.Controls.Add(this.btEdit);
            this.gpButtons.Controls.Add(this.btEraser);
            this.gpButtons.Controls.Add(this.btSnap);
            this.gpButtons.Controls.Add(this.btPointer);
            this.gpButtons.Controls.Add(this.btStop);
            this.gpButtons.Controls.Add(this.btClear);
            this.gpButtons.Controls.Add(this.btUndo);
            this.gpButtons.Location = new System.Drawing.Point(24, 48);
            this.gpButtons.Margin = new System.Windows.Forms.Padding(2);
            this.gpButtons.Name = "gpButtons";
            this.gpButtons.Size = new System.Drawing.Size(828, 53);
            this.gpButtons.TabIndex = 3;
            this.gpButtons.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.gpButtons.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.gpButtons.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btVideo
            // 
            this.btVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btVideo.FlatAppearance.BorderSize = 0;
            this.btVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVideo.Location = new System.Drawing.Point(216, 3);
            this.btVideo.Margin = new System.Windows.Forms.Padding(2);
            this.btVideo.Name = "btVideo";
            this.btVideo.Size = new System.Drawing.Size(46, 46);
            this.btVideo.TabIndex = 4;
            this.toolTip.SetToolTip(this.btVideo, "Video Recording");
            this.btVideo.UseVisualStyleBackColor = true;
            this.btVideo.Click += new System.EventHandler(this.btVideo_Click);
            // 
            // btInkVisible
            // 
            this.btInkVisible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btInkVisible.FlatAppearance.BorderSize = 0;
            this.btInkVisible.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btInkVisible.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btInkVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInkVisible.Image = global::gInk.Properties.Resources.visible;
            this.btInkVisible.Location = new System.Drawing.Point(702, 3);
            this.btInkVisible.Margin = new System.Windows.Forms.Padding(2);
            this.btInkVisible.Name = "btInkVisible";
            this.btInkVisible.Size = new System.Drawing.Size(46, 46);
            this.btInkVisible.TabIndex = 3;
            this.toolTip.SetToolTip(this.btInkVisible, "Ink visible");
            this.btInkVisible.UseVisualStyleBackColor = true;
            this.btInkVisible.Click += new System.EventHandler(this.btInkVisible_Click);
            this.btInkVisible.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btInkVisible.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btInkVisible.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btPan
            // 
            this.btPan.BackgroundImage = global::gInk.Properties.Resources.pan;
            this.btPan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPan.FlatAppearance.BorderSize = 0;
            this.btPan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btPan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btPan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPan.Location = new System.Drawing.Point(652, 3);
            this.btPan.Margin = new System.Windows.Forms.Padding(2);
            this.btPan.Name = "btPan";
            this.btPan.Size = new System.Drawing.Size(46, 46);
            this.btPan.TabIndex = 2;
            this.toolTip.SetToolTip(this.btPan, "Pan");
            this.btPan.UseVisualStyleBackColor = true;
            this.btPan.Click += new System.EventHandler(this.btPan_Click);
            this.btPan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btPan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btPan.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btMagn
            // 
            this.btMagn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btMagn.FlatAppearance.BorderSize = 0;
            this.btMagn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btMagn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btMagn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMagn.Location = new System.Drawing.Point(652, 3);
            this.btMagn.Margin = new System.Windows.Forms.Padding(2);
            this.btMagn.Name = "btMagn";
            this.btMagn.Size = new System.Drawing.Size(46, 46);
            this.btMagn.TabIndex = 2;
            this.toolTip.SetToolTip(this.btMagn, "Magnetic drawing");
            this.btMagn.UseVisualStyleBackColor = true;
            this.btMagn.Click += new System.EventHandler(this.btMagn_Click);
            this.btMagn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btMagn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btMagn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btDock
            // 
            this.btDock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btDock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btDock.FlatAppearance.BorderSize = 0;
            this.btDock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btDock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btDock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDock.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btDock.Image = global::gInk.Properties.Resources.dock;
            this.btDock.Location = new System.Drawing.Point(0, 3);
            this.btDock.Margin = new System.Windows.Forms.Padding(2);
            this.btDock.Name = "btDock";
            this.btDock.Size = new System.Drawing.Size(34, 46);
            this.btDock.TabIndex = 0;
            this.toolTip.SetToolTip(this.btDock, "Dock / Undock");
            this.btDock.UseVisualStyleBackColor = false;
            this.btDock.Click += new System.EventHandler(this.btDock_Click);
            this.btDock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btDock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btDock.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btPenWidth
            // 
            this.btPenWidth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPenWidth.FlatAppearance.BorderSize = 0;
            this.btPenWidth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btPenWidth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btPenWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPenWidth.Image = global::gInk.Properties.Resources.penwidth;
            this.btPenWidth.Location = new System.Drawing.Point(266, 3);
            this.btPenWidth.Margin = new System.Windows.Forms.Padding(2);
            this.btPenWidth.Name = "btPenWidth";
            this.btPenWidth.Size = new System.Drawing.Size(46, 46);
            this.btPenWidth.TabIndex = 0;
            this.toolTip.SetToolTip(this.btPenWidth, "Pen width");
            this.btPenWidth.UseVisualStyleBackColor = true;
            this.btPenWidth.Click += new System.EventHandler(this.btPenWidth_Click);
            this.btPenWidth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btPenWidth.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btPenWidth.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btHand
            // 
            this.btHand.BackgroundImage = global::gInk.Properties.Resources.tool_hand;
            this.btHand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btHand.FlatAppearance.BorderSize = 0;
            this.btHand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btHand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btHand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHand.ForeColor = System.Drawing.Color.Transparent;
            this.btHand.Location = new System.Drawing.Point(326, 3);
            this.btHand.Margin = new System.Windows.Forms.Padding(2);
            this.btHand.Name = "btHand";
            this.btHand.Size = new System.Drawing.Size(46, 46);
            this.btHand.TabIndex = 0;
            this.toolTip.SetToolTip(this.btHand, "Hand Drawing");
            this.btHand.UseVisualStyleBackColor = false;
            this.btHand.Click += new System.EventHandler(this.btTool_Click);
            this.btHand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btHand.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btHand.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btLine
            // 
            this.btLine.BackgroundImage = global::gInk.Properties.Resources.tool_line;
            this.btLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btLine.FlatAppearance.BorderSize = 0;
            this.btLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLine.ForeColor = System.Drawing.Color.Transparent;
            this.btLine.Location = new System.Drawing.Point(326, 3);
            this.btLine.Margin = new System.Windows.Forms.Padding(2);
            this.btLine.Name = "btLine";
            this.btLine.Size = new System.Drawing.Size(46, 46);
            this.btLine.TabIndex = 0;
            this.toolTip.SetToolTip(this.btLine, "Line Drawing");
            this.btLine.UseVisualStyleBackColor = false;
            this.btLine.Click += new System.EventHandler(this.btTool_Click);
            this.btLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btLine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btRect
            // 
            this.btRect.BackgroundImage = global::gInk.Properties.Resources.tool_rect;
            this.btRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btRect.FlatAppearance.BorderSize = 0;
            this.btRect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btRect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRect.ForeColor = System.Drawing.Color.Transparent;
            this.btRect.Location = new System.Drawing.Point(326, 3);
            this.btRect.Margin = new System.Windows.Forms.Padding(2);
            this.btRect.Name = "btRect";
            this.btRect.Size = new System.Drawing.Size(46, 46);
            this.btRect.TabIndex = 0;
            this.toolTip.SetToolTip(this.btRect, "Rect Shape");
            this.btRect.UseVisualStyleBackColor = false;
            this.btRect.Click += new System.EventHandler(this.btTool_Click);
            this.btRect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btRect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btRect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btOval
            // 
            this.btOval.BackgroundImage = global::gInk.Properties.Resources.tool_oval;
            this.btOval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOval.FlatAppearance.BorderSize = 0;
            this.btOval.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btOval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btOval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOval.ForeColor = System.Drawing.Color.Transparent;
            this.btOval.Location = new System.Drawing.Point(326, 3);
            this.btOval.Margin = new System.Windows.Forms.Padding(2);
            this.btOval.Name = "btOval";
            this.btOval.Size = new System.Drawing.Size(46, 46);
            this.btOval.TabIndex = 0;
            this.toolTip.SetToolTip(this.btOval, "Oval Shape");
            this.btOval.UseVisualStyleBackColor = false;
            this.btOval.Click += new System.EventHandler(this.btTool_Click);
            this.btOval.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btOval.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btOval.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btArrow
            // 
            this.btArrow.BackgroundImage = global::gInk.Properties.Resources.tool_stAr;
            this.btArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btArrow.FlatAppearance.BorderSize = 0;
            this.btArrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btArrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btArrow.ForeColor = System.Drawing.Color.Transparent;
            this.btArrow.Location = new System.Drawing.Point(326, 3);
            this.btArrow.Margin = new System.Windows.Forms.Padding(2);
            this.btArrow.Name = "btArrow";
            this.btArrow.Size = new System.Drawing.Size(46, 46);
            this.btArrow.TabIndex = 0;
            this.toolTip.SetToolTip(this.btArrow, "Starting or Ending Arrow Shape");
            this.btArrow.UseVisualStyleBackColor = false;
            this.btArrow.Click += new System.EventHandler(this.btTool_Click);
            this.btArrow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btArrow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btArrow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btNumb
            // 
            this.btNumb.BackgroundImage = global::gInk.Properties.Resources.tool_numb;
            this.btNumb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btNumb.FlatAppearance.BorderSize = 0;
            this.btNumb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btNumb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btNumb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNumb.ForeColor = System.Drawing.Color.Transparent;
            this.btNumb.Location = new System.Drawing.Point(326, 3);
            this.btNumb.Margin = new System.Windows.Forms.Padding(2);
            this.btNumb.Name = "btNumb";
            this.btNumb.Size = new System.Drawing.Size(46, 46);
            this.btNumb.TabIndex = 0;
            this.toolTip.SetToolTip(this.btNumb, "Add number tag");
            this.btNumb.UseVisualStyleBackColor = false;
            this.btNumb.Click += new System.EventHandler(this.btTool_Click);
            this.btNumb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btNumb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btNumb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btText
            // 
            this.btText.BackgroundImage = global::gInk.Properties.Resources.tool_txtL;
            this.btText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btText.FlatAppearance.BorderSize = 0;
            this.btText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btText.ForeColor = System.Drawing.Color.Transparent;
            this.btText.Location = new System.Drawing.Point(326, 3);
            this.btText.Margin = new System.Windows.Forms.Padding(2);
            this.btText.Name = "btText";
            this.btText.Size = new System.Drawing.Size(46, 46);
            this.btText.TabIndex = 0;
            this.toolTip.SetToolTip(this.btText, "Add Left aligned text");
            this.btText.UseVisualStyleBackColor = false;
            this.btText.Click += new System.EventHandler(this.btTool_Click);
            this.btText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btEdit
            // 
            this.btEdit.BackgroundImage = global::gInk.Properties.Resources.tool_edit;
            this.btEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btEdit.FlatAppearance.BorderSize = 0;
            this.btEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.ForeColor = System.Drawing.Color.Transparent;
            this.btEdit.Location = new System.Drawing.Point(326, 3);
            this.btEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(46, 46);
            this.btEdit.TabIndex = 0;
            this.toolTip.SetToolTip(this.btEdit, "Edit Text");
            this.btEdit.UseVisualStyleBackColor = false;
            this.btEdit.Click += new System.EventHandler(this.btTool_Click);
            this.btEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btEdit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btEraser
            // 
            this.btEraser.FlatAppearance.BorderSize = 0;
            this.btEraser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btEraser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btEraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEraser.ForeColor = System.Drawing.Color.Transparent;
            this.btEraser.Image = global::gInk.Properties.Resources.eraser;
            this.btEraser.Location = new System.Drawing.Point(326, 3);
            this.btEraser.Margin = new System.Windows.Forms.Padding(2);
            this.btEraser.Name = "btEraser";
            this.btEraser.Size = new System.Drawing.Size(46, 46);
            this.btEraser.TabIndex = 0;
            this.toolTip.SetToolTip(this.btEraser, "Eraser");
            this.btEraser.UseVisualStyleBackColor = false;
            this.btEraser.Click += new System.EventHandler(this.btEraser_Click);
            this.btEraser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btEraser.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btEraser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btSnap
            // 
            this.btSnap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSnap.FlatAppearance.BorderSize = 0;
            this.btSnap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btSnap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btSnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSnap.Image = global::gInk.Properties.Resources.snap;
            this.btSnap.Location = new System.Drawing.Point(469, 3);
            this.btSnap.Margin = new System.Windows.Forms.Padding(2);
            this.btSnap.Name = "btSnap";
            this.btSnap.Size = new System.Drawing.Size(46, 46);
            this.btSnap.TabIndex = 0;
            this.toolTip.SetToolTip(this.btSnap, "Snapshot");
            this.btSnap.UseVisualStyleBackColor = true;
            this.btSnap.Click += new System.EventHandler(this.btSnap_Click);
            this.btSnap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btSnap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btSnap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btPointer
            // 
            this.btPointer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPointer.FlatAppearance.BorderSize = 0;
            this.btPointer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btPointer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btPointer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPointer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btPointer.Image = global::gInk.Properties.Resources.pointer;
            this.btPointer.Location = new System.Drawing.Point(383, 3);
            this.btPointer.Margin = new System.Windows.Forms.Padding(2);
            this.btPointer.Name = "btPointer";
            this.btPointer.Size = new System.Drawing.Size(46, 46);
            this.btPointer.TabIndex = 0;
            this.toolTip.SetToolTip(this.btPointer, "Mouse pointer");
            this.btPointer.UseVisualStyleBackColor = true;
            this.btPointer.Click += new System.EventHandler(this.btPointer_Click);
            this.btPointer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btPointer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btPointer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btStop
            // 
            this.btStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btStop.FlatAppearance.BorderSize = 0;
            this.btStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStop.Image = global::gInk.Properties.Resources.exit;
            this.btStop.Location = new System.Drawing.Point(760, 3);
            this.btStop.Margin = new System.Windows.Forms.Padding(2);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(46, 46);
            this.btStop.TabIndex = 0;
            this.toolTip.SetToolTip(this.btStop, "Exit drawing");
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            this.btStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btStop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btClear
            // 
            this.btClear.BackgroundImage = global::gInk.Properties.Resources.garbage;
            this.btClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClear.FlatAppearance.BorderSize = 0;
            this.btClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClear.Location = new System.Drawing.Point(583, 3);
            this.btClear.Margin = new System.Windows.Forms.Padding(2);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(46, 46);
            this.btClear.TabIndex = 1;
            this.toolTip.SetToolTip(this.btClear, "Clear");
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.RightToLeftChanged += new System.EventHandler(this.btClear_RightToLeftChanged);
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            this.btClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btClear.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // btUndo
            // 
            this.btUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btUndo.FlatAppearance.BorderSize = 0;
            this.btUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUndo.Image = global::gInk.Properties.Resources.undo;
            this.btUndo.Location = new System.Drawing.Point(526, 3);
            this.btUndo.Margin = new System.Windows.Forms.Padding(2);
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(46, 46);
            this.btUndo.TabIndex = 1;
            this.toolTip.SetToolTip(this.btUndo, "Undo");
            this.btUndo.UseVisualStyleBackColor = true;
            this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
            this.btUndo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseDown);
            this.btUndo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseMove);
            this.btUndo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpButtons_MouseUp);
            // 
            // tiSlide
            // 
            this.tiSlide.Interval = 15;
            this.tiSlide.Tick += new System.EventHandler(this.tiSlide_Tick);
            // 
            // gpPenWidth
            // 
            this.gpPenWidth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gpPenWidth.BackgroundImage = global::gInk.Properties.Resources.penwidthpanel;
            this.gpPenWidth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gpPenWidth.Controls.Add(this.pboxPenWidthIndicator);
            this.gpPenWidth.Location = new System.Drawing.Point(116, 217);
            this.gpPenWidth.Name = "gpPenWidth";
            this.gpPenWidth.Size = new System.Drawing.Size(200, 53);
            this.gpPenWidth.TabIndex = 4;
            this.gpPenWidth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpPenWidth_MouseDown);
            this.gpPenWidth.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpPenWidth_MouseMove);
            this.gpPenWidth.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gpPenWidth_MouseUp);
            // 
            // pboxPenWidthIndicator
            // 
            this.pboxPenWidthIndicator.BackColor = System.Drawing.Color.Orange;
            this.pboxPenWidthIndicator.Location = new System.Drawing.Point(78, 0);
            this.pboxPenWidthIndicator.Name = "pboxPenWidthIndicator";
            this.pboxPenWidthIndicator.Size = new System.Drawing.Size(5, 53);
            this.pboxPenWidthIndicator.TabIndex = 5;
            this.pboxPenWidthIndicator.TabStop = false;
            this.pboxPenWidthIndicator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pboxPenWidthIndicator_MouseDown);
            this.pboxPenWidthIndicator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pboxPenWidthIndicator_MouseMove);
            this.pboxPenWidthIndicator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pboxPenWidthIndicator_MouseUp);
            // 
            // longClickTimer
            // 
            this.longClickTimer.Interval = 1200;
            this.longClickTimer.Tick += new System.EventHandler(this.longClickTimer_Tick);
            // 
            // FontDlg
            // 
            this.FontDlg.FontMustExist = true;
            // 
            // FormCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 526);
            this.Controls.Add(this.gpPenWidth);
            this.Controls.Add(this.gpButtons);
            this.ForeColor = System.Drawing.Color.LawnGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCollection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCollection_FormClosing);
            this.gpButtons.ResumeLayout(false);
            this.gpPenWidth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxPenWidthIndicator)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Button btStop;
		public System.Windows.Forms.Button btClear;
		public System.Windows.Forms.Button btUndo;
		public System.Windows.Forms.Panel gpButtons;

        public System.Windows.Forms.Button btHand;
        public System.Windows.Forms.Button btLine;
        public System.Windows.Forms.Button btRect;
        public System.Windows.Forms.Button btOval;
        public System.Windows.Forms.Button btArrow;
        public System.Windows.Forms.Button btNumb;
        public System.Windows.Forms.Button btText;
        public System.Windows.Forms.Button btEdit;
        public System.Windows.Forms.Button btMagn;

        public System.Windows.Forms.Button btEraser;
		private System.Windows.Forms.Timer tiSlide;
		public System.Windows.Forms.Button btDock;
		public System.Windows.Forms.Button btSnap;
		public System.Windows.Forms.Button btPointer;
		public System.Windows.Forms.Button btPenWidth;
		public System.Windows.Forms.ToolTip toolTip;
		public System.Windows.Forms.Panel gpPenWidth;
		private System.Windows.Forms.PictureBox pboxPenWidthIndicator;
		public System.Windows.Forms.Button btPan;
		public System.Windows.Forms.Button btInkVisible;
        private System.Windows.Forms.Timer longClickTimer;
        public System.Windows.Forms.Button btVideo;
        public System.Windows.Forms.FontDialog FontDlg;
    }
}

