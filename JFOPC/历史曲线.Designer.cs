namespace JFMonitor {
    partial class 历史曲线 {
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(历史曲线));
            this.GC = new ZedGraph.ZedGraphControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Button前一天 = new System.Windows.Forms.ToolStripButton();
            this.Button后一天 = new System.Windows.Forms.ToolStripButton();
            this.Button当天 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Button温度放大 = new System.Windows.Forms.ToolStripButton();
            this.Button温度缩小 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Button湿度放大 = new System.Windows.Forms.ToolStripButton();
            this.Button湿度缩小 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Button时间放大 = new System.Windows.Forms.ToolStripButton();
            this.Button时间缩小 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GC
            // 
            this.GC.BackColor = System.Drawing.Color.White;
            this.GC.BackgroundImage = global::JFMonitor.Properties.Resources.bj1;
            this.GC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GC.IsEnableWheelZoom = false;
            this.GC.IsZoomOnMouseCenter = true;
            this.GC.LinkModifierKeys = System.Windows.Forms.Keys.None;
            this.GC.Location = new System.Drawing.Point(0, 29);
            this.GC.Name = "GC";
            this.GC.ScrollGrace = 0D;
            this.GC.ScrollMaxX = 0D;
            this.GC.ScrollMaxY = 0D;
            this.GC.ScrollMaxY2 = 0D;
            this.GC.ScrollMinX = 0D;
            this.GC.ScrollMinY = 0D;
            this.GC.ScrollMinY2 = 0D;
            this.GC.Size = new System.Drawing.Size(877, 491);
            this.GC.TabIndex = 0;
            this.GC.ContextMenuBuilder += new ZedGraph.ZedGraphControl.ContextMenuBuilderEventHandler(this.GC_ContextMenuBuilder);
            this.GC.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.GC_ZoomEvent);
            this.GC.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.GC_PointValueEvent);
            this.GC.Click += new System.EventHandler(this.GC_Click);
            this.GC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GC_MouseClick);
            this.GC.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GC_MouseMove);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button前一天,
            this.Button后一天,
            this.Button当天,
            this.toolStripSeparator1,
            this.Button温度放大,
            this.Button温度缩小,
            this.toolStripSeparator4,
            this.Button湿度放大,
            this.Button湿度缩小,
            this.toolStripSeparator2,
            this.Button时间放大,
            this.Button时间缩小,
            this.toolStripSeparator3,
            this.toolStripButton2,
            this.toolStripButton7,
            this.toolStripButton1,
            this.toolStripButton6,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(877, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "上移";
            // 
            // Button前一天
            // 
            this.Button前一天.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button前一天.Image = ((System.Drawing.Image)(resources.GetObject("Button前一天.Image")));
            this.Button前一天.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button前一天.Name = "Button前一天";
            this.Button前一天.Size = new System.Drawing.Size(48, 22);
            this.Button前一天.Text = "前一天";
            this.Button前一天.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Button后一天
            // 
            this.Button后一天.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button后一天.Image = ((System.Drawing.Image)(resources.GetObject("Button后一天.Image")));
            this.Button后一天.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button后一天.Name = "Button后一天";
            this.Button后一天.Size = new System.Drawing.Size(48, 22);
            this.Button后一天.Text = "后一天";
            this.Button后一天.Click += new System.EventHandler(this.Button后一天_Click);
            // 
            // Button当天
            // 
            this.Button当天.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button当天.Image = ((System.Drawing.Image)(resources.GetObject("Button当天.Image")));
            this.Button当天.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button当天.Name = "Button当天";
            this.Button当天.Size = new System.Drawing.Size(36, 22);
            this.Button当天.Text = "当天";
            this.Button当天.Click += new System.EventHandler(this.Button当天_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Button温度放大
            // 
            this.Button温度放大.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button温度放大.Image = ((System.Drawing.Image)(resources.GetObject("Button温度放大.Image")));
            this.Button温度放大.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button温度放大.Name = "Button温度放大";
            this.Button温度放大.Size = new System.Drawing.Size(60, 22);
            this.Button温度放大.Text = "温度放大";
            this.Button温度放大.Click += new System.EventHandler(this.Button温度放大_Click);
            // 
            // Button温度缩小
            // 
            this.Button温度缩小.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button温度缩小.Image = ((System.Drawing.Image)(resources.GetObject("Button温度缩小.Image")));
            this.Button温度缩小.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button温度缩小.Name = "Button温度缩小";
            this.Button温度缩小.Size = new System.Drawing.Size(60, 22);
            this.Button温度缩小.Text = "温度缩小";
            this.Button温度缩小.Click += new System.EventHandler(this.Button温度缩小_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // Button湿度放大
            // 
            this.Button湿度放大.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button湿度放大.Image = ((System.Drawing.Image)(resources.GetObject("Button湿度放大.Image")));
            this.Button湿度放大.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button湿度放大.Name = "Button湿度放大";
            this.Button湿度放大.Size = new System.Drawing.Size(60, 22);
            this.Button湿度放大.Text = "湿度放大";
            this.Button湿度放大.Click += new System.EventHandler(this.ButtonY湿度放大_Click);
            // 
            // Button湿度缩小
            // 
            this.Button湿度缩小.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button湿度缩小.Image = ((System.Drawing.Image)(resources.GetObject("Button湿度缩小.Image")));
            this.Button湿度缩小.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button湿度缩小.Name = "Button湿度缩小";
            this.Button湿度缩小.Size = new System.Drawing.Size(60, 22);
            this.Button湿度缩小.Text = "湿度缩小";
            this.Button湿度缩小.Click += new System.EventHandler(this.Button湿度缩小_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Button时间放大
            // 
            this.Button时间放大.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button时间放大.Image = ((System.Drawing.Image)(resources.GetObject("Button时间放大.Image")));
            this.Button时间放大.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button时间放大.Name = "Button时间放大";
            this.Button时间放大.Size = new System.Drawing.Size(60, 22);
            this.Button时间放大.Text = "时间放大";
            this.Button时间放大.ToolTipText = "按住鼠标左键拖动可选择时间范围";
            this.Button时间放大.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // Button时间缩小
            // 
            this.Button时间缩小.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Button时间缩小.Image = ((System.Drawing.Image)(resources.GetObject("Button时间缩小.Image")));
            this.Button时间缩小.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button时间缩小.Name = "Button时间缩小";
            this.Button时间缩小.Size = new System.Drawing.Size(60, 22);
            this.Button时间缩小.Text = "时间缩小";
            this.Button时间缩小.ToolTipText = "按住鼠标左键拖动可选择时间范围";
            this.Button时间缩小.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton2.Text = "上移";
            this.toolStripButton2.ToolTipText = "可按Ctrl+鼠标左键拖动";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton7.Text = "下移";
            this.toolStripButton7.ToolTipText = "可按Ctrl+鼠标左键拖动";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton1.Text = "左移";
            this.toolStripButton1.ToolTipText = "可按Ctrl+鼠标左键拖动";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton6.Text = "右移";
            this.toolStripButton6.ToolTipText = "可按Ctrl+鼠标左键拖动";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
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
            this.splitContainer1.Panel1.Controls.Add(this.GC);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(877, 565);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 29);
            this.panel1.TabIndex = 7;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(303, 7);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(96, 16);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Text = "底部湿度(H2)";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(206, 7);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(96, 16);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "顶部湿度(H1)";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(109, 7);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 16);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "底部温度(T2)";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "顶部温度(T1)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // 历史曲线
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 565);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "历史曲线";
            this.Text = "历史曲线";
            this.Load += new System.EventHandler(this.历史曲线_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl GC;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Button当天;
        private System.Windows.Forms.ToolStripButton Button前一天;
        private System.Windows.Forms.ToolStripButton Button后一天;
        private System.Windows.Forms.ToolStripButton Button湿度放大;
        private System.Windows.Forms.ToolStripButton Button湿度缩小;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton Button时间放大;
        private System.Windows.Forms.ToolStripButton Button时间缩小;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Button温度放大;
        private System.Windows.Forms.ToolStripButton Button温度缩小;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}