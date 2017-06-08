using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JFMonitor {
    public partial class 设置: Form {

        public  List<double> setData;
        public 设置() {
            InitializeComponent();
        }

        private void label1_Click( object sender,EventArgs e ) {

        }

        private void toolStripButton4_Click( object sender,EventArgs e ) {
            try
            {
                var x1=double.Parse( textBox1.Text);
                var x2=double.Parse( textBox2.Text);
                var x3=double.Parse( textBox3.Text);
                var x4=double.Parse( textBox4.Text);
                var x5=double.Parse( textBox5.Text);
                if (setData == null) setData = new List<double>();
                else setData.Clear();
                setData.Add(x1);
                setData.Add(x2);
                setData.Add(x3);
                setData.Add(x4);
                setData.Add(x5);
                DialogResult = DialogResult.OK;
            } catch 
            {
                MessageBox.Show("设置数据不对!");  
            }
        }
        void tBox_KeyPress( object sender,KeyPressEventArgs e ) {
            var tb = sender as TextBox;

            if (e.KeyChar == 0x20) e.KeyChar = (char) 0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox) sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20) {
                try {
                    if (sender is TextBox)
                        double.Parse(((TextBox) sender).Text + e.KeyChar.ToString());
                    else if (sender is DataGridViewTextBoxEditingControl) {
                        double.Parse(((DataGridViewTextBoxEditingControl) sender).Text + e.KeyChar.ToString());
                    }
                } catch {
                    e.KeyChar = (char) 0;   //处理非法字符  
                }

            }
        }
        private void 设置_Load( object sender,EventArgs e ) {
            if (setData == null) return;
            textBox1.Text = setData[0].ToString("0.0");
            textBox2.Text = setData[1].ToString("0.0");
            textBox3.Text = setData[2].ToString("0.0");
            textBox4.Text = setData[3].ToString("0.0");
            textBox5.Text = setData[4].ToString("0");
            textBox1.KeyPress += tBox_KeyPress;
            textBox2.KeyPress += tBox_KeyPress;
            textBox3.KeyPress += tBox_KeyPress;
            textBox4.KeyPress += tBox_KeyPress;
            textBox5.KeyPress += tBox_KeyPress;
        }

        private void toolStripButton10_Click( object sender,EventArgs e ) {
            DialogResult = DialogResult.Abort;
        }
    }
}
