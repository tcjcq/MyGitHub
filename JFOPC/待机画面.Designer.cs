namespace JFMonitor {
    partial class 待机画面 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null)) {
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(待机画面));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.HPCurr = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HRDown = new System.Windows.Forms.Label();
            this.HRTop = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TempDown = new System.Windows.Forms.Label();
            this.TempTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.GC = new ZedGraph.ZedGraphControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = global::JFMonitor.Properties.Resources.bj1;
            this.splitContainer1.Panel1.Controls.Add(this.HPCurr);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1512, 1053);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // HPCurr
            // 
            this.HPCurr.AutoSize = true;
            this.HPCurr.BackColor = System.Drawing.Color.Transparent;
            this.HPCurr.Dock = System.Windows.Forms.DockStyle.Right;
            this.HPCurr.Font = new System.Drawing.Font("宋体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HPCurr.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HPCurr.Location = new System.Drawing.Point(1308, 0);
            this.HPCurr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HPCurr.Name = "HPCurr";
            this.HPCurr.Size = new System.Drawing.Size(204, 144);
            this.HPCurr.TabIndex = 1;
            this.HPCurr.Text = "10";
            this.HPCurr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::JFMonitor.Properties.Resources.君峰科技图标;
            this.pictureBox1.Location = new System.Drawing.Point(34, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::JFMonitor.Properties.Resources.wdbj;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.HRDown);
            this.panel2.Controls.Add(this.HRTop);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(602, 14);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 135);
            this.panel2.TabIndex = 1;
            // 
            // HRDown
            // 
            this.HRDown.AutoSize = true;
            this.HRDown.BackColor = System.Drawing.Color.Transparent;
            this.HRDown.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            this.HRDown.ForeColor = System.Drawing.Color.Blue;
            this.HRDown.Location = new System.Drawing.Point(96, 80);
            this.HRDown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HRDown.Name = "HRDown";
            this.HRDown.Size = new System.Drawing.Size(128, 36);
            this.HRDown.TabIndex = 0;
            this.HRDown.Text = "下 50%";
            // 
            // HRTop
            // 
            this.HRTop.AutoSize = true;
            this.HRTop.BackColor = System.Drawing.Color.Transparent;
            this.HRTop.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            this.HRTop.ForeColor = System.Drawing.Color.Blue;
            this.HRTop.Location = new System.Drawing.Point(96, 16);
            this.HRTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HRTop.Name = "HRTop";
            this.HRTop.Size = new System.Drawing.Size(128, 36);
            this.HRTop.TabIndex = 0;
            this.HRTop.Text = "上 50%";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 108);
            this.label2.TabIndex = 0;
            this.label2.Text = "湿度";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::JFMonitor.Properties.Resources.wdbj;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.TempDown);
            this.panel1.Controls.Add(this.TempTop);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(243, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 135);
            this.panel1.TabIndex = 1;
            // 
            // TempDown
            // 
            this.TempDown.AutoSize = true;
            this.TempDown.BackColor = System.Drawing.Color.Transparent;
            this.TempDown.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            this.TempDown.ForeColor = System.Drawing.Color.Blue;
            this.TempDown.Location = new System.Drawing.Point(98, 84);
            this.TempDown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TempDown.Name = "TempDown";
            this.TempDown.Size = new System.Drawing.Size(146, 36);
            this.TempDown.TabIndex = 0;
            this.TempDown.Text = "下 15℃";
            // 
            // TempTop
            // 
            this.TempTop.AutoSize = true;
            this.TempTop.BackColor = System.Drawing.Color.Transparent;
            this.TempTop.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            this.TempTop.ForeColor = System.Drawing.Color.Blue;
            this.TempTop.Location = new System.Drawing.Point(98, 15);
            this.TempTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TempTop.Name = "TempTop";
            this.TempTop.Size = new System.Drawing.Size(146, 36);
            this.TempTop.TabIndex = 0;
            this.TempTop.Text = "上 15℃";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 108);
            this.label1.TabIndex = 0;
            this.label1.Text = "温度";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer2.Panel1.Controls.Add(this.GC);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackgroundImage = global::JFMonitor.Properties.Resources.bj1;
            this.splitContainer2.Panel2.Controls.Add(this.button4);
            this.splitContainer2.Panel2.Controls.Add(this.button3);
            this.splitContainer2.Panel2.Controls.Add(this.button2);
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Size = new System.Drawing.Size(1512, 916);
            this.splitContainer2.SplitterDistance = 1295;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(364, 16);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(124, 22);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "显示平均值";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // GC
            // 
            this.GC.BackColor = System.Drawing.Color.Transparent;
            this.GC.BackgroundImage = global::JFMonitor.Properties.Resources.bj1;
            this.GC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GC.IsEnableWheelZoom = false;
            this.GC.IsZoomOnMouseCenter = true;
            this.GC.LinkModifierKeys = System.Windows.Forms.Keys.None;
            this.GC.Location = new System.Drawing.Point(0, 39);
            this.GC.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.GC.Name = "GC";
            this.GC.ScrollGrace = 0D;
            this.GC.ScrollMaxX = 0D;
            this.GC.ScrollMaxY = 0D;
            this.GC.ScrollMaxY2 = 0D;
            this.GC.ScrollMinX = 0D;
            this.GC.ScrollMinY = 0D;
            this.GC.ScrollMinY2 = 0D;
            this.GC.Size = new System.Drawing.Size(1295, 877);
            this.GC.TabIndex = 1;
            this.GC.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.GC_ZoomEvent);
            this.GC.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.GC_PointValueEvent);
            this.GC.Resize += new System.EventHandler(this.GC_Resize);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1295, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::JFMonitor.Properties.Resources.按钮3;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "1";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton1.ToolTipText = "显示1小时曲线";
            this.toolStripButton1.Click += new System.EventHandler(this.button5_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::JFMonitor.Properties.Resources.按钮3;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton4.Text = "2";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton4.ToolTipText = "显示2小时曲线";
            this.toolStripButton4.Click += new System.EventHandler(this.button6_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::JFMonitor.Properties.Resources.按钮3;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "5";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton3.ToolTipText = "显示5小时曲线";
            this.toolStripButton3.Click += new System.EventHandler(this.button7_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::JFMonitor.Properties.Resources.按钮3;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "12";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton2.ToolTipText = "显示12小时曲线";
            this.toolStripButton2.Click += new System.EventHandler(this.button8_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = global::JFMonitor.Properties.Resources.按钮3;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton5.Text = "24";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton5.ToolTipText = "显示24小时曲线";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.Color.MediumBlue;
            this.button4.Location = new System.Drawing.Point(51, 250);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(231, 99);
            this.button4.TabIndex = 0;
            this.button4.Text = "入库";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.MediumBlue;
            this.button3.Location = new System.Drawing.Point(51, 92);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(231, 99);
            this.button3.TabIndex = 0;
            this.button3.Text = "出库";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::JFMonitor.Properties.Resources.按钮背景;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.MediumBlue;
            this.button2.Location = new System.Drawing.Point(51, 678);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 99);
            this.button2.TabIndex = 0;
            this.button2.Text = "手动操作";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.MediumBlue;
            this.button1.Location = new System.Drawing.Point(51, 410);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 99);
            this.button1.TabIndex = 0;
            this.button1.Text = "管理";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 待机画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 1053);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "待机画面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备运行正常";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.待机画面_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HRDown;
        private System.Windows.Forms.Label HRTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TempDown;
        private System.Windows.Forms.Label TempTop;
        private ZedGraph.ZedGraphControl GC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label HPCurr;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}