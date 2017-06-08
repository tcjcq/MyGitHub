using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace JFMonitor {

    public partial class 待机画面: Form {
        public OPCAPI  myOPC=new OPCAPI();
        public string ConnectionString;
        public string PLCIP;
        public bool EnableManual;
        public delegate void CK出库按键ClickHandler();
        public delegate void RK入库按键ClickHandler();
        public delegate void GL管理按键ClickHandler();
      //  public delegate void FormClosingHandler( object sender,FormClosingEventArgs e );

        public event CK出库按键ClickHandler CK出库按键Click;
        public event RK入库按键ClickHandler RK入库按键Click;
        public event GL管理按键ClickHandler GL管理按键Click;
     //   public event FormClosingHandler 待机画面Closing;


        public 待机画面() {
            InitializeComponent();
        }

        void RefreshView() {
            var a=myOPC.Items[PLCTagName.TopTemp.ToString()];
            if (a.Quality != (int) Quality.GOOD) {
                TempTop.Text = string.Format("上 {0}℃","##");
                TempDown.Text = string.Format("下 {0}℃","##");
                HRTop.Text = string.Format("上 {0}%","##");
                HRDown.Text = string.Format("下 {0}%","##");
                return;
            }
            TempTop.Text = string.Format("上 {0:0.0}℃",myOPC.Items[PLCTagName.TopTemp.ToString()].Value);
            TempDown.Text = string.Format("下 {0:0.0}℃",myOPC.Items[PLCTagName.BTMTemp.ToString()].Value);
            HRTop.Text = string.Format("上 {0:0.0}%",myOPC.Items[PLCTagName.TopHR.ToString()].Value);
            HRDown.Text = string.Format("下 {0:0.0}%",myOPC.Items[PLCTagName.BTMHR.ToString()].Value);
            HPCurr.Text = string.Format("{0}",myOPC.Items[PLCTagName.HPCurNum.ToString()].Value);
        }
        PointPairList LTopTemp ;
        PointPairList LBMTTemp;
        PointPairList LTopHR;
        PointPairList LBMTHR;
        const int DisplayTimeSpan=3600*24; //秒
        const int timeGap=10; //时间间隔 秒

        double[] TopTemp=new double[DisplayTimeSpan/timeGap];
        double[] BMTTemp=new double[DisplayTimeSpan/timeGap];
        double[] TopHR=new double[DisplayTimeSpan/timeGap];
        double[] BMTHR=new double[DisplayTimeSpan/timeGap];
        double[] date=new double[DisplayTimeSpan/timeGap];

        double[] TempAVG=new double[DisplayTimeSpan/timeGap];
        double[] HRAVG=new double[DisplayTimeSpan/timeGap];
         
        DateTime x0,x1;
        public  RealDataOperter rdo;
        void InitPointList() {
            x1 = DateTime.Now;
            x0 = x1.AddSeconds(-DisplayTimeSpan);

            if(rdo == null) {
                rdo = new RealDataOperter();
                rdo.DataCount = DisplayTimeSpan / timeGap;
                rdo.Fname = Application.StartupPath + "\\RealData.bin";
            }
            var j=0;
            var x=x0;

            if (rdo.Read()) {
                var i=0;
                while (rdo.DataList[i].Time < x) {
                    i++;
                    if (i >= rdo.DataList.Count)
                        break;
                }

                for (; i < rdo.DataList.Count; i++) {
                    while (x < rdo.DataList[i].Time) {
                        if ((rdo.DataList[i].Time - x).TotalSeconds < 300) {
                            TopTemp[j] = rdo.DataList[i].T1;
                            BMTTemp[j] = rdo.DataList[i ].T2;
                            TopHR[j] = rdo.DataList[i].H1;
                            BMTHR[j] = rdo.DataList[i ].H2;
                            date[j] = new XDate(x).XLDate;
                        } else if ((rdo.DataList[i].Time - x).TotalSeconds == 300) {
                            TopTemp[j] = rdo.DataList[i].T1;
                            BMTTemp[j] = rdo.DataList[i].T2;
                            TopHR[j] = rdo.DataList[i].H1;
                            BMTHR[j] = rdo.DataList[i].H2;
                            date[j] = new XDate(rdo.DataList[i - 1].Time).XLDate;
                        } else {
                            TopTemp[j] = 0;
                            BMTTemp[j] = 0;
                            TopHR[j] = 0;
                            BMTHR[j] = 0;
                            date[j] = new XDate(x).XLDate;
                        }
                     
                        x = x.AddSeconds(timeGap);
                        j++;
                    }
                    if(j>= DisplayTimeSpan / timeGap) {
                        j = DisplayTimeSpan / timeGap - 1;
                    }
                    var r= rdo.DataList[i];
                    TopTemp[j] = r.T1;
                    BMTTemp[j] = r.T2;
                    TopHR[j] = r.H1;
                    BMTHR[j] = r.H2;
                    date[j] = new XDate(r.Time);
                    j++;
                    x = x.AddSeconds(timeGap);
                }
            }
            x=x0.AddSeconds(j*timeGap);
            for (; j < DisplayTimeSpan / timeGap; j++) {
                TopTemp[j] = 0;
                BMTTemp[j] = 0;
                TopHR[j] = 0;
                BMTHR[j] = 0;
                date[j] = new XDate(x).XLDate;
                x = x.AddSeconds(timeGap);
            }
            LTopTemp = new PointPairList(date,TopTemp);
            LBMTTemp = new PointPairList(date,BMTTemp);
            LTopHR = new PointPairList(date,TopHR);
            LBMTHR = new PointPairList(date,BMTHR);
            for (j=0; j < DisplayTimeSpan / timeGap; j++) {
                TempAVG[j] =(TopTemp[j]+BMTTemp[j])/2.0;
                HRAVG[j] = (TopHR[j] + BMTHR[j]) / 2.0;
            }
        }
        int minIndex=0;
        void UpdatePointList() {
            x1 = DateTime.Now;
            x0 = x1.AddSeconds(-DisplayTimeSpan);

            var x=x0;
            int i;
            for (i = 1; i < DisplayTimeSpan / timeGap; i++) {
                TopTemp[i - 1] = TopTemp[i];
                BMTTemp[i - 1] = BMTTemp[i];
                TopHR[i - 1] = TopHR[i];
                BMTHR[i - 1] = BMTHR[i];
                date[i - 1] = date[i];
            }
            TopTemp[i - 1] = double.Parse(myOPC.Items[PLCTagName.TopTemp.ToString()].Value.ToString());
            BMTTemp[i - 1] = double.Parse(myOPC.Items[PLCTagName.BTMTemp.ToString()].Value.ToString());
            TopHR[i - 1] = double.Parse(myOPC.Items[PLCTagName.TopHR.ToString()].Value.ToString());
            BMTHR[i - 1] = double.Parse(myOPC.Items[PLCTagName.BTMHR.ToString()].Value.ToString());
            date[i - 1] = new XDate(x1).XLDate;

            for (var j = 0; j < DisplayTimeSpan / timeGap; j++) {
                TempAVG[j] = (TopTemp[j] + BMTTemp[j]) / 2.0;
                HRAVG[j] = (TopHR[j] + BMTHR[j]) / 2.0;
            }

            var r=new RealData();
            r.T1 =(float) TopTemp[i - 1];
            r.T2 = (float) BMTTemp[i - 1];
            r.H1 = (float) TopHR[i - 1];
            r.H2 = (float) BMTHR[i - 1];
            r.Time = x1;
            rdo.Add(r);

            LTopTemp = new PointPairList(date,TopTemp);
            LBMTTemp = new PointPairList(date,BMTTemp);
            LTopHR = new PointPairList(date,TopHR);
            LBMTHR = new PointPairList(date,BMTHR);

           

            var g1= GC.MasterPane[0];
            var g2= GC.MasterPane[1];

            g1.CurveList.Clear();
            g2.CurveList.Clear();


            CurveItem c=g1.AddCurve("温度上",LTopTemp,Color.Blue,SymbolType.None);
            c = g1.AddCurve("温度下",LBMTTemp,Color.YellowGreen,SymbolType.None);
            c = g1.AddCurve("温度",new PointPairList(date,TempAVG),Color.DarkRed,SymbolType.None);


            c = g2.AddCurve("湿度上",LTopHR,Color.MediumVioletRed,SymbolType.None);
            //  c.IsY2Axis = true;
            c = g2.AddCurve("湿度下",LBMTHR,Color.BlueViolet,SymbolType.None);

            c = g2.AddCurve("湿度",new PointPairList(date,HRAVG),Color.Blue,SymbolType.None);
            //  c.IsY2Axis = true;
            g1.XAxis.Scale.Max = date[i - 1];
            g1.XAxis.Scale.Min = date[minIndex];
            g2.XAxis.Scale.Max = date[i - 1];
            g2.XAxis.Scale.Min = date[minIndex];

            g1.AxisChange();
            g2.AxisChange();

            SetScalFormat(g1.XAxis,g1);
            SetScalFormat(g2.XAxis,g2);

            if (checkBox1.Checked) {
                GC.MasterPane[0].CurveList["温度"].IsVisible = true;
                GC.MasterPane[1].CurveList["湿度"].IsVisible = true;
            } else {
                GC.MasterPane[0].CurveList["温度"].IsVisible = false;
                GC.MasterPane[1].CurveList["湿度"].IsVisible = false;

            }

            GC.Refresh();
        }

        void SetXAxis( XAxis Ax ) {
            Ax.Title.IsVisible = false;
            Ax.Scale.MinAuto = false;
            Ax.Scale.MaxAuto = false;

            Ax.Scale.Max = new XDate(LTopHR[LTopHR.Count - 1].X);
            Ax.Scale.Min = new XDate(LTopHR[0].X);

            Ax.Type = ZedGraph.AxisType.Date;

            Ax.Scale.Format = "yyyy-MM-dd HH:mm:ss";
            Ax.Scale.FontSpec.Size = 12;
            Ax.Scale.MajorStepAuto = true;
            Ax.Scale.MinorStepAuto = true;

           // Ax.Scale.FontSpec.Fill.IsScaled = false;

            Ax.MajorTic.IsCrossInside = false;
            Ax.MajorTic.IsCrossOutside = false;
            Ax.MajorTic.IsOutside = false;
            Ax.MajorTic.IsInside = true;
            Ax.MajorTic.IsOpposite = true;


            Ax.MinorTic.IsCrossInside = false;
            Ax.MinorTic.IsCrossOutside = false;
            Ax.MinorTic.IsOutside = false;
            Ax.MinorTic.IsInside = true;
            Ax.MinorTic.IsOpposite = true;


            Ax.IsAxisSegmentVisible = false;
        }
        const double TempMax=100;
        void SetYAxis( Axis Ax ) {
            Ax.IsVisible = true;
            Ax.Type = ZedGraph.AxisType.Linear;
            Ax.IsAxisSegmentVisible = false;

            //  Ax.Title.IsVisible = false;
            if (Ax.GetType() == typeof(Y2Axis))
                Ax.Title.FontSpec.Angle = 270;
            else Ax.Title.FontSpec.Angle = 90;
            Ax.Title.FontSpec.Size = 12;

            Ax.Scale.MinAuto = false;
            Ax.Scale.MaxAuto = false;
            Ax.Scale.Max = TempMax;
            Ax.Scale.Min = 0;
            Ax.Scale.Format = "f0";
            Ax.Scale.FontSpec.Size = 8;
            Ax.Scale.MajorStep = 10;
            Ax.Scale.MinorStep = 1;
             

            //  Ax.Scale.MajorStepAuto = true;
            //  Ax.Scale.MinorStepAuto = true;

            Ax.Scale.MinGrace = 0.1;

            Ax.MajorTic.IsCrossInside = false;
            Ax.MajorTic.IsCrossOutside = false;
            Ax.MajorTic.IsOutside = true;
            Ax.MajorTic.IsInside = false;
            Ax.MajorTic.IsOpposite = false;


            Ax.MinorTic.IsCrossInside = false;
            Ax.MinorTic.IsCrossOutside = false;
            Ax.MinorTic.IsOutside = true;
            Ax.MinorTic.IsInside = false;
            Ax.MinorTic.IsOpposite = false;


            Ax.Scale.BaseTic = 0;

        }
        void SetXStep( double sec ,GraphPane g) {
           g.XAxis.Scale.Format = "HH:mm";
            if (sec <= 600) {
                g.XAxis.Scale.MinorStep = 0.5;
               g.XAxis.Scale.MinorUnit = DateUnit.Minute;
                g.XAxis.Scale.MajorStep = 2;
               g.XAxis.Scale.MajorUnit = DateUnit.Minute;
               g.XAxis.Scale.Format = "HH:mm:ss";
            } else if (sec <= 1800) {
                g.XAxis.Scale.MinorStep = 1;
                g.XAxis.Scale.MinorUnit = DateUnit.Minute;
                g.XAxis.Scale.MajorStep = 5;
                g.XAxis.Scale.MajorUnit = DateUnit.Minute;
            } else if (sec <= 3600 * 2) {
                g.XAxis.Scale.MinorStep = 2;
                g.XAxis.Scale.MinorUnit = DateUnit.Minute;
                g.XAxis.Scale.MajorStep = 10;
                g.XAxis.Scale.MajorUnit = DateUnit.Minute;
            } else if (sec <= 3600 * 3) {
                g.XAxis.Scale.MinorStep = 5;
                g.XAxis.Scale.MinorUnit = DateUnit.Minute;
                g.XAxis.Scale.MajorStep = 30;
                g.XAxis.Scale.MajorUnit = DateUnit.Minute;

            } else if (sec <= 3600 * 6) {
                g.XAxis.Scale.MinorStep = 5;
                g.XAxis.Scale.MinorUnit = DateUnit.Minute;
                g.XAxis.Scale.MajorStep = 30;
                g.XAxis.Scale.MajorUnit = DateUnit.Minute;

            } else {
                g.XAxis.Scale.MinorStep = 10;
                g.XAxis.Scale.MinorUnit = DateUnit.Minute;
                g.XAxis.Scale.MajorStep = 1;
                g.XAxis.Scale.MajorUnit = DateUnit.Hour;
            }

        }
        void SetScalFormat( XAxis xA ,GraphPane g) {
            DateTime d1 = new XDate( xA.Scale.Max);
            DateTime d2 = new XDate(xA.Scale.Min);
            var x=d1-d2;
            xA.Scale.MajorStepAuto = false;
            xA.Scale.MinorStepAuto = false;
            SetXStep(x.TotalSeconds,g);


        }
        void SetGrid( GraphPane gp) {
            var xa=gp.XAxis;
            var ya=gp.YAxis;
            xa.MajorGrid.Color = Color.DarkGray;
            xa.MajorGrid.IsVisible = true;
            ya.MajorGrid.Color = Color.DarkGray;
            ya.MajorGrid.IsVisible = true;
        }
        void SetGraph2() {

            var g1=GC.GraphPane;
            var g2=new GraphPane();

            GC.MasterPane.Add(g2);

            GC.PointValueFormat = "0.0";
            GC.IsShowPointValues = true;

            g1.Rect = new RectangleF(0,0,GC.Width,GC.Height / 2);
            g2.Rect = new RectangleF(0,GC.Height / 2,GC.Width,GC.Height / 2);

            GC.IsEnableHPan = true;
            GC.IsEnableVPan = true;
            GC.IsEnableVZoom = false;

            g1.XAxis.IsVisible = true;
            g1.X2Axis.IsVisible = false;
            g1.Y2Axis.IsVisible = false;

            g2.XAxis.IsVisible = true;
            g2.X2Axis.IsVisible = false;
            g2.Y2Axis.IsVisible = false;

            g1.IsFontsScaled = false;
            g2.IsFontsScaled = false;




            SetXAxis(g1.XAxis);
            SetYAxis(g1.YAxis);
            SetYAxis(g1.Y2Axis);

            SetXAxis(g2.XAxis);
            SetYAxis(g2.YAxis);
            SetYAxis(g2.Y2Axis);

            g1.YAxis.Title.Text = "温度";
            g2.YAxis.Title.Text = "湿度";

            var yA=g1.YAxis;
            yA.Scale.Max = 50;
            yA.Scale.Min = 0;
            yA.Type = ZedGraph.AxisType.Linear;

            var y2A=g1.Y2Axis;
            y2A.Scale.Max = 50;
            y2A.Scale.Min = 0;
            y2A.Type = ZedGraph.AxisType.Linear;

            CurveItem c= g1.AddCurve("温度上",LTopTemp,Color.Blue,SymbolType.None);
            c = g1.AddCurve("温度下",LBMTTemp,Color.YellowGreen,SymbolType.None);
            c = g1.AddCurve("温度",new PointPairList(date,TempAVG),Color.DarkRed,SymbolType.None);

            c = g2.AddCurve("湿度上",LTopHR,Color.MediumVioletRed,SymbolType.None);

           // c.IsY2Axis = true;
            c = g2.AddCurve("湿度下",LBMTHR,Color.BlueViolet,SymbolType.None);
            c = g2.AddCurve("湿度",new PointPairList(date,HRAVG),Color.Blue,SymbolType.None);

            // c.IsY2Axis = true;

            g1.Title.IsVisible = false;
            g1.Legend.IsVisible = true;
            g1.Legend.FontSpec.Size = 10;

            g2.Title.IsVisible = false;
            g2.Legend.IsVisible = true;
            g2.Legend.FontSpec.Size = 10;


            SetScalFormat(g1.XAxis,g1);
            SetScalFormat(g2.XAxis,g2);

            SetGrid(g1);
            SetGrid(g2);
            
            GC.AxisChange();
            if (checkBox1.Checked) {
                GC.MasterPane[0].CurveList["温度"].IsVisible = true;
                GC.MasterPane[1].CurveList["湿度"].IsVisible = true;
            } else {
                GC.MasterPane[0].CurveList["温度"].IsVisible = false;
                GC.MasterPane[1].CurveList["湿度"].IsVisible = false;

            }
            GC.Refresh();

        }
        //void SetGraph() {

        //   // GC.Controls.Add(groupBox1);

        //    GC.IsEnableHPan = true;
        //    GC.IsEnableVPan = true;
        //    GC.IsEnableVZoom = false;

        //    g.XAxis.IsVisible = true;
        //    g.X2Axis.IsVisible = false;
        //    g.Y2Axis.IsVisible = true;


        //    SetXAxis(g.XAxis);
        //    SetYAxis(g.YAxis);
        //    SetYAxis(g.Y2Axis);

        //    g.YAxis.Title.Text = "温度";
        //    g.Y2Axis.Title.Text = "湿度";

        //    YAxis yA=g.YAxis;
        //    yA.Scale.Max = 50;
        //    yA.Scale.Min = 0;
        //    yA.Type = ZedGraph.AxisType.Linear;

        //    CurveItem c= g.AddCurve("温度上",LTopTemp,Color.Blue,SymbolType.None);
        //    c = g.AddCurve("温度下",LBMTTemp,Color.YellowGreen,SymbolType.None);

        //    c = g.AddCurve("湿度上",LTopHR,Color.MediumVioletRed,SymbolType.None);
        //    c.IsY2Axis = true;
        //    c = g.AddCurve("湿度下",LBMTHR,Color.BlueViolet,SymbolType.None);
        //    c.IsY2Axis = true;

        //    g.Title.IsVisible = false;
        //    g.Legend.IsVisible = true;
        //    g.Legend.FontSpec.Size = 8;

        //    SetScalFormat(g.XAxis);
        //    SetGrid(g);
        //    GC.AxisChange();
        //    GC.Refresh();

        //}
        private void MyOPC_ReadItemCompleted( object sender,EventArgs e ) {
            //try {
               
            //} catch (Exception ex) {
            //    MessageBox.Show(ex.Message);
            //}

        }
        private void 待机画面_Load( object sender,EventArgs e ) {
            try {
                myOPC.ReadCompleted += MyOPC_ReadItemCompleted;
                // myOPC.WriteCompleted += MyOPC_WriteCompleted;
                OPCAPI.PLC_IP = PLCIP;
                myOPC.InitOPC();

                InitPointList();
                SetGraph2();
                var p= splitContainer2.Panel1;
                if (EnableManual) button2.Visible = true;
                else button2.Visible = false;
            } catch {

            }
        }

        int count=0;

        private void button3_Click( object sender,EventArgs e ) {
            if (CK出库按键Click != null)
                CK出库按键Click();
        }

        private void button4_Click( object sender,EventArgs e ) {
            if (RK入库按键Click != null)
                RK入库按键Click();

        }

        private void button1_Click( object sender,EventArgs e ) {
            if (GL管理按键Click != null)
                GL管理按键Click();
        }

      
        public void Close待机画面() {
            if (myOPC != null) myOPC.Disconnect();
        }

        private void button_MouseEnter( object sender,EventArgs e ) {
            var bt=sender as Button;
            bt.BackgroundImage = Properties.Resources.按钮背景HOT;
        }

        private void button_MouseLeave( object sender,EventArgs e ) {
            var bt=sender as Button;
            bt.BackgroundImage = Properties.Resources.按钮背景;

        }

        private void button2_Click( object sender,EventArgs e ) {
            if (!EnableManual) {
                MessageBox.Show("系统已禁止手动操作!");
                return;
            }
            var f=new 手动操作();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.myOPC = myOPC;
            f.ShowDialog();
        }

        private void GC_ZoomEvent( ZedGraphControl sender,ZoomState oldState,ZoomState newState ) {
            var g1=GC.MasterPane[0];
            var g2=GC.MasterPane[1];
            DateTime d0=new XDate(g1.XAxis.Scale.Min);
            DateTime d1=new XDate(g1.XAxis.Scale.Max);
            DateTime d2=new XDate(g2.XAxis.Scale.Min);
            DateTime d3=new XDate(g2.XAxis.Scale.Max);

            var ts1=d1-d0;
            var ts2=d3-d2;
            if(ts1.TotalSeconds< ts2.TotalSeconds) {
                g2.XAxis.Scale.Min = g1.XAxis.Scale.Min;
                g2.XAxis.Scale.Max = g1.XAxis.Scale.Max;
                SetXStep(ts1.TotalSeconds,g1);
                SetXStep(ts1.TotalSeconds,g2);
            } else {
                g1.XAxis.Scale.Min = g2.XAxis.Scale.Min;
                g1.XAxis.Scale.Max = g2.XAxis.Scale.Max;
                SetXStep(ts2.TotalSeconds,g1);
                SetXStep(ts2.TotalSeconds,g2);

            }
           

        }

        void ChangRange() {

            var g1=GC.MasterPane[0];
            var g2=GC.MasterPane[1];

            g1.XAxis.Scale.Max = date[DisplayTimeSpan / timeGap - 1];
            g1.XAxis.Scale.Min = date[minIndex];

            g1.AxisChange();
            SetScalFormat(g1.XAxis,g1);

            g2.XAxis.Scale.Max = date[DisplayTimeSpan / timeGap - 1];
            g2.XAxis.Scale.Min = date[minIndex];

            g2.AxisChange();
            SetScalFormat(g2.XAxis,g2);

            GC.Refresh();
        }

        private void button5_Click( object sender,EventArgs e ) {
            minIndex = DisplayTimeSpan / timeGap - 360;

            ChangRange();
        }

        private void button6_Click( object sender,EventArgs e ) {
            minIndex = DisplayTimeSpan / timeGap - 360 * 2;
            ChangRange();

        }

        private void button7_Click( object sender,EventArgs e ) {
            minIndex = DisplayTimeSpan / timeGap - 360 * 5;
            ChangRange();

        }

        private void button8_Click( object sender,EventArgs e ) {
            minIndex = DisplayTimeSpan / timeGap - 360 * 12;
            ChangRange();

        }

        private void GC_Resize( object sender,EventArgs e ) {
            //groupBox1.Top = 0;
            //groupBox1.Left = GC.Width - groupBox1.Width - 2;
            //groupBox1.Height = 30;
            using (var g = GC.CreateGraphics()) {
                 
                GC.MasterPane.SetLayout(g,PaneLayout.SingleColumn);
               
            }
            if ((GC.Width < 300)||(GC.Height<300)) {
                for (var i= 0;i < GC.MasterPane.PaneList.Count;i++) {
                    GC.MasterPane[i].IsFontsScaled = true;
                }
              
            } else {
                for (var i = 0; i < GC.MasterPane.PaneList.Count; i++) {
                    GC.MasterPane[i].IsFontsScaled = false;
                }

            }

        }

        private string GC_PointValueEvent( ZedGraphControl sender,GraphPane pane,CurveItem curve,int iPt ) {
            var name=curve.Label.Text;
            DateTime d1= new XDate( curve.Points[iPt].X);
            var value=curve.Points[iPt].Y;
            return string.Format("{0}:\n时间:{1}\n{2}",name,d1.ToString("yyyy-MM-dd HH:mm:ss"),value.ToString("0.0"));
        }

        private void checkBox1_CheckedChanged( object sender,EventArgs e ) {
            if (checkBox1.Checked) {
                GC.MasterPane[0].CurveList["温度"].IsVisible = true;
                GC.MasterPane[1].CurveList["湿度"].IsVisible = true;
            } else {
                GC.MasterPane[0].CurveList["温度"].IsVisible = false;
                GC.MasterPane[1].CurveList["湿度"].IsVisible = false;

            }
            GC.Refresh();
        }

        private void toolStripButton5_Click( object sender,EventArgs e ) {
            minIndex = DisplayTimeSpan / timeGap - 360 * 24;
            ChangRange();
        }

     

        private void timer1_Tick( object sender,EventArgs e ) {
            try {
                RefreshView();
                count++;
                if (count >= timeGap) {
                    count = 0;
                    UpdatePointList();
                    rdo.SaveData();
                }
            } catch (Exception) {


            }
        }
    }
}
