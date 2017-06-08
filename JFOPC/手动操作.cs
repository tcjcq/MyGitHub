using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JFMonitor {
    public partial class 手动操作:Form {

        public OPCAPI  myOPC=new OPCAPI();
        public string ConnectionString;
        public string PLCIP;
        public 手动操作()
        {
            InitializeComponent();
        }

        private void button正转_Click( object sender,EventArgs e )
        {
            if (myOPC == null) return;
            myOPC.TurnUp();
            button正转.SelectNextControl(button正转,true,true,true,true);
            //Button bt=sender as Button;
            //bt.BackgroundImage = Properties.Resources.按钮背景;
        }

        private void button反转_Click( object sender,EventArgs e )
        {
            if (myOPC == null) return;
            myOPC.TurnDown();
        }

        private void buttonOpen_Click( object sender,EventArgs e )
        {
            if (myOPC != null)
                myOPC.OpenDoor();
        }

        private void buttonClose_Click( object sender,EventArgs e )
        {
            if(myOPC!=null)
            myOPC.CloseDoor();
        }

        private void buttonStart1_Click( object sender,EventArgs e )
        {
            if (myOPC != null)
                myOPC.OpenCompressor(1);
        }

        private void buttonStart2_Click( object sender,EventArgs e )
        {
            if (myOPC != null)
                myOPC.OpenCompressor(2);
        }

        private void buttonStop1_Click( object sender,EventArgs e )
        {
            if (myOPC != null)
                myOPC.CloseCompressor(1);
        }

        private void buttonStop2_Click( object sender,EventArgs e )
        {
            if (myOPC != null)
                myOPC.CloseCompressor(2);
        }

        private void buttonClear_Click( object sender,EventArgs e )
        {
            if (myOPC != null)
                myOPC.ClearAlerm();
        }
        private void buttonAlert_Click( object sender,EventArgs e )
        {
            if (myOPC != null)
                myOPC.Alert();
        }
        private void button_MouseEnter( object sender,EventArgs e )
        {
            var bt=sender as Button;
            bt.BackgroundImage = Properties.Resources.按钮背景HOT;
        }

        private void button_MouseLeave( object sender,EventArgs e )
        {
            var bt=sender as Button;
            bt.BackgroundImage = Properties.Resources.按钮背景;

        }
       
        private void button1_Click( object sender,EventArgs e ) {
            var f=new 设置();
            var setdata=new List<double>();
            setdata.Add(Convert.ToDouble(myOPC.Items[PLCTagName.TempSET1.ToString()].Value));
            setdata.Add(Convert.ToDouble(myOPC.Items[PLCTagName.TempSET2.ToString()].Value));
            setdata.Add(Convert.ToDouble(myOPC.Items[PLCTagName.HRSET1.ToString()].Value));
            setdata.Add(Convert.ToDouble(myOPC.Items[PLCTagName.HRSET2.ToString()].Value));
            setdata.Add(Convert.ToDouble(myOPC.Items[PLCTagName.CPSwapTime.ToString()].Value));
            f.setData = setdata;
            f.StartPosition = FormStartPosition.CenterScreen;
            if (f.ShowDialog() == DialogResult.OK) {
                myOPC.SetItemValue(PLCTagName.TempSET1, setdata[0]);
                myOPC.SetItemValue(PLCTagName.TempSET2, setdata[1]);
                myOPC.SetItemValue(PLCTagName.HRSET1, setdata[2]);
                myOPC.SetItemValue(PLCTagName.HRSET2, setdata[3]);
                myOPC.SetItemValue(PLCTagName.CPSwapTime,setdata[4]);
                string[] s= {PLCTagName.TempSET1.ToString(),
                    PLCTagName.TempSET2.ToString(),
                    PLCTagName.HRSET1.ToString(),
                    PLCTagName.HRSET2.ToString(),
                    PLCTagName.CPSwapTime.ToString(),
                };
                myOPC.Write(s);
            }
        }

        private void button2_Click( object sender,EventArgs e ) {
            if (button2.Text.Contains("手动")) {
                button2.Text = "切换到自动";
                myOPC.SetItemValue(PLCTagName.AMStat,true);
                string[] s= {PLCTagName.AMStat.ToString()
                };
                myOPC.Write(s);
            } else {
                button2.Text = "切换到手动";
                myOPC.SetItemValue(PLCTagName.AMStat,false);
                string[] s= {PLCTagName.AMStat.ToString()
                };
                myOPC.Write(s);
            }
        }

        private void 手动操作_Load( object sender,EventArgs e ) {
            var c=(bool)myOPC.Items[PLCTagName.AMStat.ToString()].Value;
            if (c == false) {
                button2.Text = "切换到手动";
            } else {
                button2.Text = "切换到自动";
            }
        }
    }
}
