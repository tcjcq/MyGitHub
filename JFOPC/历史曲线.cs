using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using CYQ.Data;
using CYQ.Data.Table;
//using DataJFSJK;

namespace JFMonitor {
    public partial class 历史曲线:Form {

        PointPairList LTopTemp ;
        PointPairList LBMTTemp;
        PointPairList LTopHR;
        PointPairList LBMTHR;
        public string ConnectionString;

        const double TempMax=100;
        const double TempMin=-10;
        const double HrMax=100;
        const double HrMin=0;

        const int Data_MinCount=1000;



        public 历史曲线()
        {
            InitializeComponent();
        }


        MDataTable GetData( DateTime st,DateTime ed )
        {
            using (var action = new MAction(TableNames.DAUData,ConnectionString)) {
                var wh=string.Format("Time>='{0}' AND Time <='{1}' order by Time asc ",
                                    st.ToString("yyyy-MM-dd HH:mm:ss"),
                                    ed.ToString("yyyy-MM-dd HH:mm:ss"));
                var i= action.GetCount(wh);
                if (i < Data_MinCount) {
                    if (i == 0) {
                        // MessageBox.Show("无当天数据,将显示最后保存的数据");
                    }
                    wh = string.Format(@"SELECT * from (SELECT TOP {0} *
                    FROM [DAUData] Where Time <='{1}' order by [Time] desc ) a order by [Time]",Data_MinCount,st);
                    using (var proc = new MProc(wh,ConnectionString)) {
                        return proc.ExeMDataTable();
                    }


                }

                return action.Select(wh);
            }
        }
        bool LoadData( DateTime st,DateTime ed )
        {

            var dt=GetData(st,ed);
            if (dt.Rows.Count == 0) return false;
            var a=new double[dt.Rows.Count];
            var b=new double[dt.Rows.Count];
            var c=new double[dt.Rows.Count];
            var d=new double[dt.Rows.Count];
            var date=new double[dt.Rows.Count];
            var i=0;
            foreach (var r in dt.Rows) {
                a[i] = r.Get<int>(DAUData.Temp1) / 100f;
                b[i] = r.Get<int>(DAUData.Temp2) / 100f;
                c[i] = r.Get<int>(DAUData.HR1) / 100f;
                d[i] = r.Get<int>(DAUData.HR2) / 100f;
                date[i] = new XDate(r.Get<DateTime>(DAUData.Time));
                i++;
            }

            LTopTemp = new PointPairList(date,a);
            LBMTTemp = new PointPairList(date,b);
            LTopHR = new PointPairList(date,c);
            LBMTHR = new PointPairList(date,d);
            return true;

        }
        double GetMajorStep( TimeSpan x,out DateUnit du,out string format )
        {
            if (x.TotalMinutes < 1) {
                du = DateUnit.Second;
                format = "HH:mm:ss";
                return 1;
            } else if (x.TotalMinutes < 2) {
                du = DateUnit.Second;
                format = "HH:mm:ss";
                return 10;
            } else if (x.TotalMinutes < 5) {
                du = DateUnit.Second;
                format = "HH:mm:ss";
                return 30;
            } else if (x.TotalMinutes < 10) {
                du = DateUnit.Minute;
                format = "HH:mm";
                return 2;
            } else if (x.TotalMinutes < 30) {
                du = DateUnit.Minute;
                format = "HH:mm";
                return 5;
            } else if (x.TotalMinutes < 60) {
                du = DateUnit.Minute;
                format = "HH:mm";
                return 10;
            } else if (x.TotalHours < 2) {
                du = DateUnit.Minute;
                format = "HH:mm";
                return 10;
            } else if (x.TotalHours < 5) {
                du = DateUnit.Hour;
                format = "HH:mm";
                return 0.5;
            } else if (x.TotalHours < 10) {
                du = DateUnit.Hour;
                format = "MM-dd HH:mm";
                return 1.0;
            } else if (x.TotalHours < 24) {
                du = DateUnit.Hour;
                format = "MM-dd HH:mm";
                return 2;
            } else if (x.TotalDays < 5) {
                du = DateUnit.Day;
                format = "MM-dd HH:mm";
                return 0.25;
            } else if (x.TotalDays < 10) {
                du = DateUnit.Day;
                format = "MM-dd HH:mm";
                return 2;
            } else if (x.TotalDays < 30) {
                du = DateUnit.Day;
                format = "MM-dd HH:mm";
                return 5;
            } else if (x.TotalDays < 100) {
                du = DateUnit.Month;
                format = "MM-dd HH:mm";
                return 1;
            } else {
                du = DateUnit.Month;
                format = "MM-dd HH:mm";
                return 2;
            }
        }
        void SetScalFormat( XAxis xA )
        {
            DateTime d1 = new XDate( xA.Scale.Max);
            DateTime d2 = new XDate(xA.Scale.Min);
            var x=d1-d2;
            xA.Scale.MajorStepAuto = false;
            xA.Scale.MinorStepAuto = false;

            DateUnit a;
            string s;
            xA.Scale.MajorStep = GetMajorStep(x,out a,out s);
            xA.Scale.MinorStep = xA.Scale.MajorStep / 6;

            xA.Scale.MajorUnit = a;
            xA.Scale.MinorUnit = a;
            xA.Scale.Format = s;
        }
        void SetScalFormat( Axis xA )
        {
            var d1 = xA.Scale.Max;
            var d2 =xA.Scale.Min;
            var x=d1-d2;
            xA.Scale.MajorStepAuto = false;
            xA.Scale.MinorStepAuto = false;
            xA.Scale.Format = "f1";
            if (x < 1) {
                xA.Scale.MajorStep = 0.1;
                xA.Scale.MinorStep = 0.02;
            } else if (x < 5) {
                xA.Scale.MajorStep = 0.5;
                xA.Scale.MinorStep = 0.1;
            } else if (x < 10) {
                xA.Scale.MajorStep = 1;
                xA.Scale.MinorStep = 0.2;
            } else if (x < 20) {
                xA.Scale.MajorStep = 5;
                xA.Scale.MinorStep = 1;
            } else if (x < 50) {
                xA.Scale.MajorStep = 5;
                xA.Scale.MinorStep = 1;
            }else {
                xA.Scale.MajorStep = 10;
                xA.Scale.MinorStep = 2;
            }
            
        }
        void SetXAxis( XAxis Ax )
        {

            Ax.Title.IsVisible = false;
            Ax.Scale.MinAuto = false;
            Ax.Scale.MaxAuto = false;

            Ax.Scale.Max = new XDate(LTopHR[LTopHR.Count - 1].X);
            Ax.Scale.Min = new XDate(LTopHR[0].X);

            Ax.Type = ZedGraph.AxisType.Date;

            Ax.Scale.Format = "yyyy-MM-dd HH:mm:ss";
            Ax.Scale.FontSpec.Size = 8;
            Ax.Scale.MajorStepAuto = true;
            Ax.Scale.MinorStepAuto = true;



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
        void SetYAxis( Axis Ax )
        {
            Ax.IsVisible = true;
            Ax.Type = ZedGraph.AxisType.Linear;
            Ax.IsAxisSegmentVisible = false;

            //  Ax.Title.IsVisible = false;
            if(Ax.GetType()==typeof(Y2Axis))
                Ax.Title.FontSpec.Angle = 270;
            else Ax.Title.FontSpec.Angle = 90;
            Ax.Title.FontSpec.Size =10;
           
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

        void initGC()
        {
            GC.IsEnableHPan = true;
            GC.IsEnableVPan = true;
            GC.IsEnableVZoom = false;

            GC.GraphPane.XAxis.IsVisible = true;
            GC.GraphPane.X2Axis.IsVisible = false;
            GC.GraphPane.Y2Axis.IsVisible = true;



            SetXAxis(GC.GraphPane.XAxis);
            SetYAxis(GC.GraphPane.YAxis);
            SetYAxis(GC.GraphPane.Y2Axis);

            GC.GraphPane.YAxis.Title.Text = "温度";
            GC.GraphPane.Y2Axis.Title.Text = "湿度";


            var yA=GC.GraphPane.YAxis;
            yA.Scale.Max = 50;
            yA.Scale.Min = 0;
            yA.Type = ZedGraph.AxisType.Linear;


            CurveItem c= GC.GraphPane.AddCurve("T1",LTopTemp,Color.Blue,SymbolType.None);
            c = GC.GraphPane.AddCurve("T2",LBMTTemp,Color.YellowGreen,SymbolType.None);

            c = GC.GraphPane.AddCurve("H1",LTopHR,Color.MediumVioletRed,SymbolType.None);
            c.IsY2Axis = true;
            c = GC.GraphPane.AddCurve("H2",LBMTHR,Color.BlueViolet,SymbolType.None);
            c.IsY2Axis = true;

            GC.GraphPane.Title.IsVisible = false;
            GC.GraphPane.Legend.IsVisible = true;
            GC.GraphPane.Legend.FontSpec.Size = 8;
            GC.AxisChange();
            GC.Refresh();



        }
        private void 历史曲线_Load( object sender,EventArgs e )
        {
            var ed= DateTime.Now;
            var st= ed.AddDays(-1);
            LoadData(st,ed);
            initGC();
        }

        private void toolStripButton2_Click( object sender,EventArgs e )
        {
            try {
                var  b= sender as ToolStripButton;
                b.Enabled = false;
                var st=DateTime.Parse( new XDate( GC.GraphPane.XAxis.Scale.Min).ToString("yyyy-MM-dd"));
                if (!SetData(st.AddDays(-1),st.AddDays(1))) {
                    MessageBox.Show("已无数据!");
                    return;
                }
                //              double x=GC.GraphPane.XAxis.Scale.Max-GC.GraphPane.XAxis.Scale.Min;

                GC.GraphPane.XAxis.Scale.Max = GC.GraphPane.XAxis.Scale.Min;
                GC.GraphPane.XAxis.Scale.Min = GC.GraphPane.XAxis.Scale.Max - 1;
                if (GC.GraphPane.XAxis.Scale.Min < LTopTemp[0].X) {
                    GC.GraphPane.XAxis.Scale.Min = LTopTemp[0].X;
                    GC.GraphPane.XAxis.Scale.Max = GC.GraphPane.XAxis.Scale.Min + 1;
                }
                SetScalFormat(GC.GraphPane.XAxis);

                GC.GraphPane.AxisChange();
                
                GC.Refresh();
                b.Enabled = true;
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton5_Click( object sender,EventArgs e )
        {
            try {

                var b= sender as ToolStripButton;
                b.Enabled = false;
                var x=GC.GraphPane.XAxis.Scale.Max-GC.GraphPane.XAxis.Scale.Min;
                x *= 1.1;
                GC.GraphPane.XAxis.Scale.Max = GC.GraphPane.XAxis.Scale.Min + x;
                if (GC.GraphPane.XAxis.Scale.Max > LTopTemp[LTopTemp.Count - 1].X) {
                    GC.GraphPane.XAxis.Scale.Max = LTopTemp[LTopTemp.Count - 1].X;
                    GC.GraphPane.XAxis.Scale.Min = GC.GraphPane.XAxis.Scale.Max - x;

                }
                if (GC.GraphPane.XAxis.Scale.Min < LTopTemp[0].X) {
                    GC.GraphPane.XAxis.Scale.Min = LTopTemp[0].X;
                }

                GC.IsAutoScrollRange = false;
                GC.IsEnableVZoom = false;
                // GC.IsEnableHPan = false;
                //GC.ZoomPane(GC.GraphPane,1.1,new PointF(GC.GraphPane.Rect.Width/2,0),false);
                //GC.GraphPane.XAxis.Scale.Min = LTopTemp[0].X;

                SetScalFormat(GC.GraphPane.XAxis);
                var a=GC.GraphPane.XAxis.Scale.MajorUnit;
                // GC.AxisChange();
                GC.GraphPane.XAxis.Scale.MajorUnit = a;
                GC.GraphPane.XAxis.Scale.MinorUnit = a;
                GC.Refresh();
                b.Enabled = true;
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton9_Click( object sender,EventArgs e )
        {
            try {

                var b= sender as ToolStripButton;
                b.Enabled = false;
                var x=GC.GraphPane.XAxis.Scale.Max-GC.GraphPane.XAxis.Scale.Min;
                x *= 0.9;
                DateTime d1= new XDate(GC.GraphPane.XAxis.Scale.Min);
                DateTime d2= new XDate(GC.GraphPane.XAxis.Scale.Min+x);

                if ((d2 - d1).TotalMinutes < 1) {
                    XDate x1= d1.AddMinutes(1);
                    x = x1 - (new XDate(d1)).XLDate;
                }
                GC.GraphPane.XAxis.Scale.Max = GC.GraphPane.XAxis.Scale.Min + x;
                //GC.IsEnableVZoom = false;
                //GC.IsEnableHPan = false;
                //GC.ZoomPane(GC.GraphPane,0.9,new PointF(GC.GraphPane.Rect.Width / 2,0),false);
                //GC.GraphPane.XAxis.Scale.Min = LTopTemp[0].X;
                SetScalFormat(GC.GraphPane.XAxis);
                // GC.AxisChange();
                GC.Refresh();
                b.Enabled = true;
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton1_Click( object sender,EventArgs e )
        {
            try {
                var b= sender as ToolStripButton;
                b.Enabled = false;
                var x=GC.GraphPane.XAxis.Scale.Max-GC.GraphPane.XAxis.Scale.Min;
                GC.GraphPane.XAxis.Scale.Max += x*0.1;

                GC.GraphPane.XAxis.Scale.Min = GC.GraphPane.XAxis.Scale.Max - x;
                if (GC.GraphPane.XAxis.Scale.Max > LTopTemp[LTopTemp.Count - 1].X) {
                    DateTime st=new XDate(GC.GraphPane.XAxis.Scale.Min+x/2);
                    SetData(st.AddDays(-1),st.AddDays(1));
                }
                GC.GraphPane.XAxis.Scale.Min = GC.GraphPane.XAxis.Scale.Max - x;
              //  GC.AxisChange();
                GC.Refresh();
                b.Enabled = true;

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton6_Click( object sender,EventArgs e )
        {
            try {
                var b= sender as ToolStripButton;
                b.Enabled = false;
                var x=GC.GraphPane.XAxis.Scale.Max-GC.GraphPane.XAxis.Scale.Min;

                GC.GraphPane.XAxis.Scale.Min -= x*0.1; 
                if (GC.GraphPane.XAxis.Scale.Min < LTopTemp[0].X) {
                    DateTime st=new XDate(GC.GraphPane.XAxis.Scale.Min+x/2);
                    SetData(st.AddDays(-1),st.AddDays(1));
                }
                GC.GraphPane.XAxis.Scale.Max = GC.GraphPane.XAxis.Scale.Min + x;
               // GC.AxisChange();
                GC.Refresh();
                b.Enabled = true;

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton7_Click( object sender,EventArgs e )
        {
            try {
                var b= sender as ToolStripButton;
                b.Enabled = false;
                var a=GC.GraphPane.YAxis.Scale;
                var max=TempMax;
                // double min=TempMin;
                if (SelectY2) {
                    a = GC.GraphPane.Y2Axis.Scale;
                    max = HrMax;
                    // min = HrMin;
                }
                var y=a.Max-a.Min;
                a.Min += y * 0.1;
                a.Max = a.Min + y;
                if (a.Max > max) {
                    a.Max = max;
                    a.Min = a.Max - y;

                }
              //  GC.AxisChange();
                GC.Refresh();
                b.Enabled = true;

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }
        bool SelectY2=false;
        private void toolStripButton2_Click_1( object sender,EventArgs e )
        {
            try {
                var b= sender as ToolStripButton;
                b.Enabled = false;
                var a=GC.GraphPane.YAxis.Scale;
                var min=TempMin;
                if (SelectY2) {
                    a = GC.GraphPane.Y2Axis.Scale;
                    min = HrMin;
                }
                if (SelectY2) a = GC.GraphPane.Y2Axis.Scale;
                var y=a.Max-a.Min;
                a.Min -= y * 0.1;
                a.Max = a.Min + y;
                if (a.Min < min) {
                    a.Min = min;
                    a.Max = a.Min + y;

                }
               // GC.AxisChange();
                GC.Refresh();
                b.Enabled = true;

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }


        private void checkBox1_CheckedChanged( object sender,EventArgs e )
        {
            GC.GraphPane.CurveList["T1"].IsVisible = checkBox1.Checked;
            GC.GraphPane.CurveList["T2"].IsVisible = checkBox2.Checked;
            GC.GraphPane.CurveList["H1"].IsVisible = checkBox3.Checked;
            GC.GraphPane.CurveList["H2"].IsVisible = checkBox4.Checked;
            GC.Refresh();

            if ((checkBox1.Checked == false) && (checkBox2.Checked == false)) {
                Button温度放大.Enabled = false;
                Button温度缩小.Enabled = false;
            } else {
                Button温度放大.Enabled = true;
                Button温度缩小.Enabled = true;

            }
            if ((checkBox3.Checked == false) && (checkBox4.Checked == false)) {
                Button湿度放大.Enabled = false;
                Button湿度缩小.Enabled = false;
            } else {
                Button湿度放大.Enabled = true;
                Button湿度缩小.Enabled = true;

            }
        }


        private void Button温度放大_Click( object sender,EventArgs e )
        {
            try {
                var b= sender as ToolStripButton;
                b.Enabled = false;
                var y=GC.GraphPane.YAxis.Scale.Max-GC.GraphPane.YAxis.Scale.Min;
                y *= 0.9;
                GC.GraphPane.YAxis.Scale.Max = GC.GraphPane.YAxis.Scale.Min + y;
                if (GC.GraphPane.YAxis.Scale.Max > TempMax) {
                    GC.GraphPane.YAxis.Scale.Max = TempMax;
                }
                // GC.AxisChange();
                SetScalFormat(GC.GraphPane.YAxis);
                GC.Refresh();
                SelectY2 = false;
                b.Enabled = true;

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button温度缩小_Click( object sender,EventArgs e )
        {
            try {
                var b= sender as ToolStripButton;
                b.Enabled = false;
                var y=GC.GraphPane.YAxis.Scale.Max-GC.GraphPane.YAxis.Scale.Min;
                y *= 1.1;
                GC.GraphPane.YAxis.Scale.Max = GC.GraphPane.YAxis.Scale.Min + y;
                if (GC.GraphPane.YAxis.Scale.Max > TempMax) {
                    GC.GraphPane.YAxis.Scale.Max = TempMax;
                }
                // GC.AxisChange();
                SetScalFormat(GC.GraphPane.YAxis);
                GC.Refresh();
                SelectY2 = false;
                b.Enabled = true;

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonY湿度放大_Click( object sender,EventArgs e )
        {
            try {

                var b= sender as ToolStripButton;
                b.Enabled = false;
                var y=GC.GraphPane.Y2Axis.Scale.Max-GC.GraphPane.Y2Axis.Scale.Min;
                y *= 0.9;
                GC.GraphPane.Y2Axis.Scale.Max = GC.GraphPane.Y2Axis.Scale.Min + y;
                if (GC.GraphPane.Y2Axis.Scale.Max > HrMax) {
                    GC.GraphPane.Y2Axis.Scale.Max = HrMax;
                }
                // GC.AxisChange();
                SetScalFormat(GC.GraphPane.Y2Axis);

                GC.Refresh();
                SelectY2 = true;
                b.Enabled = true;
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button湿度缩小_Click( object sender,EventArgs e )
        {
            try {

                var b= sender as ToolStripButton;
                b.Enabled = false;
                var y=GC.GraphPane.Y2Axis.Scale.Max-GC.GraphPane.Y2Axis.Scale.Min;
                y *= 1.1;
                GC.GraphPane.Y2Axis.Scale.Max = GC.GraphPane.Y2Axis.Scale.Min + y;
                if (GC.GraphPane.Y2Axis.Scale.Max > HrMax) {
                    GC.GraphPane.Y2Axis.Scale.Max = HrMax;
                }
                // GC.AxisChange();
                SetScalFormat(GC.GraphPane.Y2Axis);

                GC.Refresh();
                SelectY2 = true;
                b.Enabled = true;
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }

        private void GC_Click( object sender,EventArgs e )
        {

        }

        private void GC_MouseClick( object sender,MouseEventArgs e )
        {

            if (e.Button == MouseButtons.Left) {
                if (e.X < GC.Left + GC.Width / 2) {
                    SelectY2 = false;
                } else SelectY2 = true;
            }
        }

        private string GC_PointValueEvent( ZedGraphControl sender,GraphPane pane,CurveItem curve,int iPt )
        {
            var s=string.Format("{0}\n{1:yyyy-MM-dd HH:mm:ss}\n 数值:{2}",
                  curve.Label.Text,new XDate(curve[iPt].X).DateTime,curve[iPt].Y);
            return s;
        }

        private void GC_ContextMenuBuilder( ZedGraphControl sender,ContextMenuStrip menuStrip,Point mousePt,ZedGraphControl.ContextMenuObjectState objState )
        {

            foreach (ToolStripMenuItem item in menuStrip.Items) {
                if ((string) item.Tag == "set_default")// “恢复默认大小”菜单项
                {
                    // menuStrip.Items.Remove(item); 
                    item.Visible = false;
                }
                if ((string) item.Tag == "show_val") {
                    //  menuStrip.Items.Remove(item); 
                    item.Visible = false;
                }
            }
        }

        CurveItem LastCurve;
        int LastPoint;
        private void GC_MouseMove( object sender,MouseEventArgs e )
        {
            CurveItem a;
            int i;
            if (e.Button == MouseButtons.None)
                if (GC.GraphPane.FindNearestPoint(e.Location,out a,out i)) {
                    if ((a == LastCurve) && (LastPoint == i)) return;
                    var s=string.Format("曲线: {0}\n 时刻: {1:yyyy-MM-dd HH:mm:ss}\n 数值:{2}",
                  a.Label.Text,new XDate(a[i].X).DateTime,a[i].Y);
                    // toolTip1.SetToolTip(GC,s);
                    // toolTip1.AutomaticDelay = 100;
                    toolTip1.Show(s,GC,e.Location,5000);
                    LastCurve = a;
                    LastPoint = i;
                } else {
                    toolTip1.Hide(GC);
                } else if (e.Button == MouseButtons.Left) {
                GC.PanButtons = MouseButtons.Left;
            }

        }
        bool SetData( DateTime st,DateTime ed )
        {
            if (!LoadData(st,ed)) return false;
            GC.GraphPane.CurveList.Clear();
            CurveItem c= GC.GraphPane.AddCurve("T1",LTopTemp,Color.Blue,SymbolType.None);
            c = GC.GraphPane.AddCurve("T2",LBMTTemp,Color.YellowGreen,SymbolType.None);

            c = GC.GraphPane.AddCurve("H1",LTopHR,Color.MediumVioletRed,SymbolType.None);
            c.IsY2Axis = true;
            c = GC.GraphPane.AddCurve("H2",LBMTHR,Color.BlueViolet,SymbolType.None);
            c.IsY2Axis = true;
            //double x=GC.GraphPane.XAxis.Scale.Max-GC.GraphPane.XAxis.Scale.Min;
            //GC.GraphPane.XAxis.Scale.Min = LTopTemp[0].X;
            // GC.GraphPane.XAxis.Scale.Max = LTopTemp[0].X+x;
            //GC.GraphPane.XAxis.Scale.Max = LTopTemp[LTopTemp.Count - 1].X;
            //  GC.GraphPane.AxisChange();
            //GC.Refresh();
            return true;

        }
        private void GC_ZoomEvent( ZedGraphControl sender,ZoomState oldState,ZoomState newState )
        {
            if (newState.Type == ZoomState.StateType.Pan) {
                if (GC.GraphPane.XAxis.Scale.Min < LTopTemp[0].X) {
                    var st=new XDate(GC.GraphPane.XAxis.Scale.Max).DateTime;
                    SetData(st.AddDays(-1),st.AddDays(1));

                } else {
                    if (GC.GraphPane.XAxis.Scale.Max > LTopTemp[LTopTemp.Count - 1].X) {
                        var st=new XDate(GC.GraphPane.XAxis.Scale.Min).DateTime;
                        SetData(st.AddDays(-1),st.AddDays(1));
                    }
                }
            }
            SetScalFormat(GC.GraphPane.XAxis);
            SetScalFormat(GC.GraphPane.YAxis);
            SetScalFormat(GC.GraphPane.Y2Axis);

        }

        private void Button当天_Click( object sender,EventArgs e )
        {
            try {

                var b= sender as ToolStripButton;
                b.Enabled = false;
                var st=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

                if (!SetData(st.AddDays(-1),st.AddDays(1))) {
                    MessageBox.Show("无当天数据,将显示最后保存的数据");
                    return;
                }
                GC.GraphPane.XAxis.Scale.Min = LTopTemp[0].X;
                GC.GraphPane.XAxis.Scale.Max = LTopTemp[0].X + 1;
                GC.GraphPane.AxisChange();
                SetScalFormat(GC.GraphPane.XAxis);
                GC.Refresh();
                b.Enabled = true;
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button后一天_Click( object sender,EventArgs e )
        {
            try {
                var b= sender as ToolStripButton;
                b.Enabled = false;
                var st=DateTime.Parse( new XDate( GC.GraphPane.XAxis.Scale.Max).ToString("yyyy-MM-dd"));
                if (!SetData(st.AddDays(-1),st.AddDays(1))) {
                    MessageBox.Show("已无数据!");
                    return;
                }
                GC.GraphPane.XAxis.Scale.Min = GC.GraphPane.XAxis.Scale.Max;
                GC.GraphPane.XAxis.Scale.Max = GC.GraphPane.XAxis.Scale.Min + 1;
                st = DateTime.Parse(new XDate(LTopTemp[LTopTemp.Count - 1].X).ToString("yyyy-MM-dd"));

                if (GC.GraphPane.XAxis.Scale.Max > LTopTemp[LTopTemp.Count - 1].X) {
                    MessageBox.Show("已无数据!");

                }
                GC.GraphPane.AxisChange();
                SetScalFormat(GC.GraphPane.XAxis);
                GC.Refresh();
                b.Enabled = true;
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
