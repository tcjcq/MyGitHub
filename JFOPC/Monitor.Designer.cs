namespace JFMonitor {
    partial class Monitor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.labelDoor = new System.Windows.Forms.Label();
            this.panelLed = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelTopT = new System.Windows.Forms.Label();
            this.labelBmtHR = new System.Windows.Forms.Label();
            this.labelTopHR = new System.Windows.Forms.Label();
            this.labelBmtT = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelAMStat = new System.Windows.Forms.Label();
            this.labelErrCode = new System.Windows.Forms.Label();
            this.labelRunStat = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.labelHPCurr = new System.Windows.Forms.Label();
            this.LightNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.LEDStart = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.HPNum = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LEDStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HPNum)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDoor
            // 
            this.labelDoor.AutoSize = true;
            this.labelDoor.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDoor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelDoor.Location = new System.Drawing.Point(26, 29);
            this.labelDoor.Name = "labelDoor";
            this.labelDoor.Size = new System.Drawing.Size(84, 21);
            this.labelDoor.TabIndex = 0;
            this.labelDoor.Text = "门状态:";
            // 
            // panelLed
            // 
            this.panelLed.AutoScroll = true;
            this.panelLed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLed.Location = new System.Drawing.Point(3, 328);
            this.panelLed.Name = "panelLed";
            this.panelLed.Size = new System.Drawing.Size(495, 39);
            this.panelLed.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "led_green.png");
            this.imageList1.Images.SetKeyName(1, "led_gray.png");
            this.imageList1.Images.SetKeyName(2, "led_green16.png");
            this.imageList1.Images.SetKeyName(3, "led_gray16.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(753, 522);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(753, 486);
            this.splitContainer2.SplitterDistance = 501;
            this.splitContainer2.TabIndex = 9;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer3.Size = new System.Drawing.Size(501, 486);
            this.splitContainer3.SplitterDistance = 112;
            this.splitContainer3.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelTopT);
            this.groupBox4.Controls.Add(this.labelBmtHR);
            this.groupBox4.Controls.Add(this.labelTopHR);
            this.groupBox4.Controls.Add(this.labelBmtT);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(501, 112);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // labelTopT
            // 
            this.labelTopT.AutoSize = true;
            this.labelTopT.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTopT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTopT.Location = new System.Drawing.Point(16, 30);
            this.labelTopT.Name = "labelTopT";
            this.labelTopT.Size = new System.Drawing.Size(94, 21);
            this.labelTopT.TabIndex = 4;
            this.labelTopT.Text = "顶部温度";
            // 
            // labelBmtHR
            // 
            this.labelBmtHR.AutoSize = true;
            this.labelBmtHR.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBmtHR.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelBmtHR.Location = new System.Drawing.Point(221, 68);
            this.labelBmtHR.Name = "labelBmtHR";
            this.labelBmtHR.Size = new System.Drawing.Size(94, 21);
            this.labelBmtHR.TabIndex = 4;
            this.labelBmtHR.Text = "底部湿度";
            this.labelBmtHR.Click += new System.EventHandler(this.labelBmtHR_Click);
            // 
            // labelTopHR
            // 
            this.labelTopHR.AutoSize = true;
            this.labelTopHR.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTopHR.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTopHR.Location = new System.Drawing.Point(221, 30);
            this.labelTopHR.Name = "labelTopHR";
            this.labelTopHR.Size = new System.Drawing.Size(94, 21);
            this.labelTopHR.TabIndex = 4;
            this.labelTopHR.Text = "顶部湿度";
            // 
            // labelBmtT
            // 
            this.labelBmtT.AutoSize = true;
            this.labelBmtT.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBmtT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelBmtT.Location = new System.Drawing.Point(16, 68);
            this.labelBmtT.Name = "labelBmtT";
            this.labelBmtT.Size = new System.Drawing.Size(94, 21);
            this.labelBmtT.TabIndex = 4;
            this.labelBmtT.Text = "底部温度";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelLed);
            this.groupBox3.Controls.Add(this.labelDoor);
            this.groupBox3.Controls.Add(this.labelAMStat);
            this.groupBox3.Controls.Add(this.labelErrCode);
            this.groupBox3.Controls.Add(this.labelRunStat);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(501, 370);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // labelAMStat
            // 
            this.labelAMStat.AutoSize = true;
            this.labelAMStat.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAMStat.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelAMStat.Location = new System.Drawing.Point(26, 60);
            this.labelAMStat.Name = "labelAMStat";
            this.labelAMStat.Size = new System.Drawing.Size(105, 21);
            this.labelAMStat.TabIndex = 0;
            this.labelAMStat.Text = "操作状态:";
            // 
            // labelErrCode
            // 
            this.labelErrCode.AutoSize = true;
            this.labelErrCode.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelErrCode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelErrCode.Location = new System.Drawing.Point(26, 121);
            this.labelErrCode.Name = "labelErrCode";
            this.labelErrCode.Size = new System.Drawing.Size(105, 21);
            this.labelErrCode.TabIndex = 0;
            this.labelErrCode.Text = "设备状态:";
            // 
            // labelRunStat
            // 
            this.labelRunStat.AutoSize = true;
            this.labelRunStat.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRunStat.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelRunStat.Location = new System.Drawing.Point(26, 90);
            this.labelRunStat.Name = "labelRunStat";
            this.labelRunStat.Size = new System.Drawing.Size(105, 21);
            this.labelRunStat.TabIndex = 0;
            this.labelRunStat.Text = "运行状态:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 486);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 17);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.labelHPCurr);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.LightNum);
            this.splitContainer4.Panel2.Controls.Add(this.label7);
            this.splitContainer4.Panel2.Controls.Add(this.LEDStart);
            this.splitContainer4.Panel2.Controls.Add(this.label8);
            this.splitContainer4.Panel2.Controls.Add(this.HPNum);
            this.splitContainer4.Panel2.Controls.Add(this.button1);
            this.splitContainer4.Panel2.Controls.Add(this.label9);
            this.splitContainer4.Size = new System.Drawing.Size(242, 466);
            this.splitContainer4.SplitterDistance = 170;
            this.splitContainer4.TabIndex = 9;
            // 
            // labelHPCurr
            // 
            this.labelHPCurr.AutoSize = true;
            this.labelHPCurr.BackColor = System.Drawing.Color.Transparent;
            this.labelHPCurr.Font = new System.Drawing.Font("宋体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelHPCurr.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelHPCurr.Location = new System.Drawing.Point(44, 30);
            this.labelHPCurr.Name = "labelHPCurr";
            this.labelHPCurr.Size = new System.Drawing.Size(138, 97);
            this.labelHPCurr.TabIndex = 0;
            this.labelHPCurr.Text = "10";
            this.labelHPCurr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labelHPCurr, "当前料斗位置");
            // 
            // LightNum
            // 
            this.LightNum.AutoSize = true;
            this.LightNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LightNum.Location = new System.Drawing.Point(134, 85);
            this.LightNum.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.LightNum.Name = "LightNum";
            this.LightNum.Size = new System.Drawing.Size(48, 29);
            this.LightNum.TabIndex = 7;
            this.LightNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.LightNum, "指示灯亮起个数");
            this.LightNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(34, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 21);
            this.label7.TabIndex = 4;
            this.label7.Text = "料斗位置";
            // 
            // LEDStart
            // 
            this.LEDStart.AutoSize = true;
            this.LEDStart.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LEDStart.Location = new System.Drawing.Point(134, 50);
            this.LEDStart.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.LEDStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LEDStart.Name = "LEDStart";
            this.LEDStart.Size = new System.Drawing.Size(48, 29);
            this.LEDStart.TabIndex = 7;
            this.LEDStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.LEDStart, "指示灯亮起始位置");
            this.LEDStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(34, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 21);
            this.label8.TabIndex = 4;
            this.label8.Text = "点亮个数";
            // 
            // HPNum
            // 
            this.HPNum.AutoSize = true;
            this.HPNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HPNum.Location = new System.Drawing.Point(134, 15);
            this.HPNum.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.HPNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HPNum.Name = "HPNum";
            this.HPNum.Size = new System.Drawing.Size(48, 29);
            this.HPNum.TabIndex = 7;
            this.HPNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.HPNum, "设置料斗位置");
            this.HPNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(13, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 21);
            this.label9.TabIndex = 4;
            this.label9.Text = "灯启始位置";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 522);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Monitor";
            this.Text = "Monitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Monitor_FormClosed);
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LightNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LEDStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HPNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelDoor;
        private System.Windows.Forms.Panel panelLed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelBmtT;
        private System.Windows.Forms.Label labelTopT;
        private System.Windows.Forms.Label labelBmtHR;
        private System.Windows.Forms.Label labelTopHR;
        private System.Windows.Forms.NumericUpDown LightNum;
        private System.Windows.Forms.NumericUpDown LEDStart;
        private System.Windows.Forms.NumericUpDown HPNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelRunStat;
        private System.Windows.Forms.Label labelAMStat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelErrCode;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelHPCurr;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}