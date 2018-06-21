using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quadrotor_groundstation.userclass;

namespace quadrotor_groundstation.usercontrol
{
    public partial class textboxview : UserControl
    {
        //public float Rol = 0, Pit = 0, Yaw = 0;
        public textboxview()
        {
            InitializeComponent();
        }
        public void  ShowStatus(short rol,short pit,short yaw)
        {
            this.Invoke(new Action(() =>
            {
                this.textBox_Rol.Text = ((float)rol / 100).ToString();
                this.textBox_Pit.Text = ((float)pit / 100).ToString();
                this.textBox_Yaw.Text = ((float)yaw / 100).ToString();
            }));
        }
        public void ShowHeight(short hei)
        {
            this.Invoke(new Action(() =>
            {
                //this.textBox_Hei.Text = ((float)hei / 100).ToString();
                label24.Text= ((float)hei / 100).ToString();
                if (hei>109)
                {
                    this.trackBar1.Value = 100;
                }
                else if (hei<8)
                {
                    this.trackBar1.Value = 0;
                }
                else 
                this.trackBar1.Value = ((int)hei)-8;
            }));
        }
        public void ShowSensor(int a_x, int a_y, int a_z, int g_x, int g_y, int g_z, int m_x, int m_y, int m_z)
        {
            this.Invoke(new Action(() =>
            {
                this.textBoxACCX .Text = a_x.ToString();
                this.textBoxACCY.Text = a_y.ToString();
                this.textBoxACCZ.Text = a_z.ToString();
                this.textBoxGYROX.Text = g_x.ToString();
                this.textBoxGYROY.Text = g_y.ToString();
                this.textBoxGYROZ.Text = g_z.ToString();
                this.textBoxMAGX.Text = m_x.ToString();
                this.textBoxMAGY.Text = m_y.ToString();
                this.textBoxMAGZ.Text = m_z.ToString();
            }));
        }
        public void ShowRecevData(int THR, int YAW, int ROL, int PIT, int AUX1, int AUX2, int AUX3, int AUX4, int AUX5, int AUX6)
        {
            this.Invoke(new Action(() =>
            {
                this.textBox4.Text = THR.ToString();
                this.textBox3.Text = YAW.ToString();
                this.textBox1.Text = ROL.ToString();
                this.textBox2.Text = PIT.ToString();
                this.textBox5.Text = AUX1.ToString();
                this.textBox6.Text = AUX2.ToString();
                this.textBox7.Text = AUX3.ToString();
                this.textBox8.Text = AUX4.ToString();
                this.textBox9.Text = AUX5.ToString();
                this.textBox10.Text = AUX6.ToString();
                
            }));
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Hei_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
