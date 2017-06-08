using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JFMonitor {
    public partial class Monitor:Form {

        const int Led_radius=8;
        const int Led_Count=20;


        public  Dictionary<string,CItemID> ItemIDs;

        OPCAPI myOPC;
        public Monitor()
        {
            InitializeComponent();
        }

        void DrawLed( int Stause )
        {
            float x0,y0;
            int r=Led_radius;

            uint LedStause =(uint) Stause;

            uint a2= (LedStause&0xff00)<<8;
            uint a3= (LedStause&0xff0000)>>8;
            uint a4= (LedStause&0xff000000)>>24;
            LedStause = (a2 | a3 | a4);
            panelLed.Dock = DockStyle.None;
            panelLed.Width = 2 * Led_radius * Led_Count;
            panelLed.Height = 2 * Led_radius;
            float w= panelLed.Width/(Led_Count+1);
            float h= panelLed.Height;
            for (int i = 1; i <= Led_Count; i++) {
                x0 = w * i + w / 2 - r;
                y0 = (h - 2 * r) / 2;
                PictureBox p=panelLed.Controls["pic"+i] as PictureBox;
                if (p == null) {
                    p = new PictureBox();
                    p.Name = "pic" + i;
                    p.Visible = true;
                    p.BorderStyle = BorderStyle.None;
                    panelLed.Controls.Add(p);
                }

                toolTip1.SetToolTip(p,string.Format("{0}",i));
                p.Location = new Point((int) x0,(int) y0);
                p.Width = (int) w;
                p.Height = (int) w;

                Bitmap bp=  new Bitmap(imageList1.Images[2]);
                if ((LedStause >> (i - 1) & 1) == 0) {
                    bp = new Bitmap(imageList1.Images[3]);
                }

                Graphics g= Graphics.FromImage(bp);
                SizeF size= g.MeasureString(i.ToString(),panelLed.Font);
                float x1=(bp.Width-size.Width)/2;
                float y1=(bp.Height-size.Height)/2;
                // g.DrawString(i.ToString(),panelLed.Font,Brushes.Blue,x1,y1);
                p.Image = bp;
                p.SizeMode = PictureBoxSizeMode.Zoom;
                // panelLed.Refresh();

                //if ((LedStause >> i & 1) == 1) {
                //   // g.FillEllipse(Brushes.Red,new RectangleF(x0,y0,2 * r,2 * r));
                //    g.DrawImage(imageList1.Images[0],new RectangleF(x0,y0,2 * r,2 * r));
                //} else {
                //    //g.FillEllipse(Brushes.DarkGray,new RectangleF(x0,y0,2 * r,2 * r));
                //    g.DrawImage(imageList1.Images[1],new RectangleF(x0,y0,2 * r,2 * r));

                //}
                // g.DrawEllipse(Pens.Red,new RectangleF(x0,y0,2 * r,2 * r));

            }
        }

        private void button1_Click( object sender,EventArgs e )
        {
            myOPC.SetItemValue(PLCTagName.HPNum,HPNum.Value);
            myOPC.SetItemValue(PLCTagName.LedStat,OPCAPI.GetLedValue((int) LEDStart.Value,(int)LightNum.Value));
            string[] s= { PLCTagName.HPNum.ToString(),PLCTagName.LedStat.ToString() };
            myOPC.Write(s);
        }

        private void timer1_Tick( object sender,EventArgs e )
        {

        }

        private void Monitor_Load( object sender,EventArgs e )
        {
            myOPC = new OPCAPI();
            myOPC.UpdateRate = 1000;
            myOPC.ReadCompleted += MyOPC_ReadCompleted;
            if (ItemIDs != null) myOPC.SetItemIDs(ItemIDs);
            try {
                myOPC.InitOPC();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            DrawLed(0);
            Panel.CheckForIllegalCrossThreadCalls = false;
            NumericUpDown.CheckForIllegalCrossThreadCalls = false;
            button1.Select();
        }
        delegate void SetTextCallBack( Label label,string value );
        delegate void SetNumberCallBack( NumericUpDown num,int value );
        private void SetNumber( NumericUpDown num,int value )
        {
            if (num.InvokeRequired) {
                SetNumberCallBack stcb = new SetNumberCallBack(SetNumber);
                this.Invoke(stcb,new object[] { num,value });
            } else {
                num.Value = value;
            }
        }
        private void SetText( Label label,string value )
        {
            if (label.InvokeRequired) {
                SetTextCallBack stcb = new SetTextCallBack(SetText);
                this.Invoke(stcb,new object[] { label,value });
            } else {
                label.Text = value;
            }
        }
        void SetNumberUPDown()
        {
            int a1= int.Parse(myOPC.Items[PLCTagName.HPNum.ToString()].Value.ToString());
            if (a1 < 1) a1 = 1;
            if (a1 > 20) a1 = 20;
            SetNumber(HPNum,a1);
            uint a=(uint) int.Parse( myOPC.Items[PLCTagName.LedStat.ToString()].Value.ToString());
            uint a2= (a&0xff00)<<8;
            uint a3= (a&0xff0000)>>8;
            uint a4= (a&0xff000000)>>24;
            a = (a2 | a3 | a4);
            for (int i = 0; i < 20; i++) {
                if ((a & (1 << i)) != 0) {
                    LEDStart.Value = i + 1;
                    break;
                }
            }
            int j=0;
            for (int i = 0; i < 20; i++) {
                if ((a & (1 << i)) != 0) {
                    j++;
                }
            }
            SetNumber(LightNum,j);
        }
        private void MyOPC_ReadCompleted( object sender,EventArgs e )
        {
            if (myOPC.Items[PLCTagName.BTMHR.ToString()].Quality == (int) Quality.GOOD)
                SetText(labelBmtHR,string.Format("{0,6}{1:0.0}%","底部湿度:",myOPC.Items[PLCTagName.BTMHR.ToString()].Value));
            if (myOPC.Items[PLCTagName.TopHR.ToString()].Quality == (int) Quality.GOOD)
                SetText(labelTopHR,string.Format("{0,6}{1:0.0}%","顶部湿度:",myOPC.Items[PLCTagName.TopHR.ToString()].Value));
            if (myOPC.Items[PLCTagName.TopTemp.ToString()].Quality == (int) Quality.GOOD)
                SetText(labelTopT,string.Format("{0,6}{1:0.0}℃","顶部温度:",myOPC.Items[PLCTagName.TopTemp.ToString()].Value));
            if (myOPC.Items[PLCTagName.BTMTemp.ToString()].Quality == (int) Quality.GOOD)
                SetText(labelBmtT,string.Format("{0,6}{1:0.0}℃","底部温度:",myOPC.Items[PLCTagName.BTMTemp.ToString()].Value));
            if (myOPC.Items[PLCTagName.DoorStat.ToString()].Quality == (int) Quality.GOOD) {
                int a=Convert.ToByte(myOPC.Items[PLCTagName.DoorStat.ToString()].Value);
                if (a == 0)
                    SetText(labelDoor,string.Format("{0,6} {1}","仓门状态:","关闭"));
                else if (a == 1) {
                    SetText(labelDoor,string.Format("{0,6} {1}","仓门状态:","开启"));
                } else {
                    SetText(labelDoor,string.Format("{0,6} {1}","仓门状态:","正在运行"));
                }
            }
            if (myOPC.Items[PLCTagName.RunStat.ToString()].Quality == (int) Quality.GOOD) {

                bool b=Convert.ToBoolean(myOPC.Items[PLCTagName.RunStat.ToString()].Value);
                if (b) {
                    SetText(labelRunStat,string.Format("{0,6} {1}","运行状态:","正在转动"));
                } else
                    SetText(labelRunStat,string.Format("{0,6} {1}","运行状态:","转动到位"));
            }
            if (myOPC.Items[PLCTagName.AMStat.ToString()].Quality == (int) Quality.GOOD) {

                SetText(labelHPCurr,string.Format("{0}",myOPC.Items[PLCTagName.HPCurNum.ToString()].Value));
                labelHPCurr.Left = (labelHPCurr.Parent.Width - labelHPCurr.Width) / 2;
                bool b = Convert.ToBoolean(myOPC.Items[PLCTagName.AMStat.ToString()].Value);
                if (b) {
                    SetText(labelAMStat,string.Format("{0,6} {1}","操作状态:","手动"));
                } else {
                    SetText(labelAMStat,string.Format("{0,6} {1}","操作状态:","自动"));
                }
            }
            if (myOPC.Items[PLCTagName.ErrCode.ToString()].Quality == (int) Quality.GOOD) {

               byte a = Convert.ToByte(myOPC.Items[PLCTagName.ErrCode.ToString()].Value);
                if (a == 0)
                    SetText(labelErrCode,string.Format("{0,6} {1}","设备状态:","正常"));
                else {
                    SetText(labelErrCode,string.Format("{0,6} {1}","设备状态:","故障码:" + a));
                }
            }
            if (myOPC.Items[PLCTagName.LedStat.ToString()].Quality == (int) Quality.GOOD)  
                DrawLed(int.Parse(myOPC.Items[PLCTagName.LedStat.ToString()].Value.ToString()));
            if (myOPC.Items[PLCTagName.HPNum.ToString()].Quality == (int) Quality.GOOD)
                SetNumberUPDown();
        }

        private void Monitor_FormClosed( object sender,FormClosedEventArgs e )
        {
            myOPC.Disconnect();
        }

        private void labelBmtHR_Click( object sender,EventArgs e )
        {

        }

    }
}
