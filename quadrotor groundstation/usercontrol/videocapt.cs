using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.Util;
using System.Threading;

namespace quadrotor_groundstation.usercontrol
{
    public partial class videocapt : UserControl
    {
        public Capture _capture = null;
        VideoWriter vw;
        bool recordflag = false;
        Mat frame = new Mat();

        public videocapt()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
        }

        public void ProcessFrame(object sender, EventArgs arg)
        {
            try
            {
                if (_capture != null)
                {
                    _capture.Retrieve(frame, 0);//1检索frame
                    captureImageBox.Image = frame;
                }
                this.Invoke(new Action(() =>
                {
                    textBox1.Text = frame.Size.Height.ToString();
                    textBox2.Text = frame.Size.Width.ToString();
                    //textBox3.Text = frame.GetType().ToString();
                }));

                if (recordflag)
                    vw.Write(frame);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string picName = "C:\\Users\\Administrator\\Desktop" + "\\" + "pic" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bmp";
                if (File.Exists(picName))
                {
                    File.Delete(picName);
                }
                frame.Save(picName);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "录制")
            {
                if (MessageBox.Show("开始录制吗？", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    recordflag = true;
                    Size size = new Size(640, 480);
                    vw = new VideoWriter("E:\\1.avi", 10, size, true);
                    //  Application.Idle += new EventHandler(ProcessFrame);
                    button2.Text = "暂停";
                }
            }
            else
            {
                if (MessageBox.Show("停止录制吗？", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    recordflag = false;
                    //    Application.Idle -= new EventHandler(ProcessFrame);
                    vw.Dispose();
                    button2.Text = "录制";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _capture = new Capture();//连上摄像头
                _capture.ImageGrabbed += ProcessFrame;
                //Application.Idle += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
            _capture.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_capture != null)
                _capture.Dispose();
        }

        private void videocapt_Load(object sender, EventArgs e)
        {

        }
    }
}
