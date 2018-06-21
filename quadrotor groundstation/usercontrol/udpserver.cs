using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using quadrotor_groundstation.userclass;

namespace quadrotor_groundstation
{
    public partial class udpserver : UserControl
    {
        private UdpClient UDPServer;//UDP服务器  
        private Thread udpListenThread;//UDP监听线程  
        private IPEndPoint remoteIpAndPort;//远程IP地址和端口  
        private delegate void displayMessageDelegate();//刷新端口显示委托 
        bool islisten = false;
        public  string receivedStr;//保存接收的数据字符的临时变量  
        public byte[] receiveddata;

        public delegate bool DataCheckdelegate(byte[] data, int num);
        public event DataCheckdelegate DataCheckEvent;        //声明和校验事件

        public delegate void Dataanalysisdelegate(byte[] data, int num);
        public event Dataanalysisdelegate DataanalysisEvent;        //声明数据解析事件



        public udpserver()//构造函数
        {
            InitializeComponent();//先初始化组件，否则会报错

            for (int i = 0; i < Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length; i++)
            {
                if (Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].AddressFamily.ToString().Equals("InterNetwork"))
                {
                    this.comboBoxHostIp.Items.Add(Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString());
                    comboBoxHostIp.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString();
                }
            }

        }

        private void udpListen()//监听，线程的实际代码  
        {

            #region 建立服务器
            int i = 1;
            while (true)//循环，端口不可用自动加1  
            {
                try
                {
                    this.Invoke(new Action(() =>//从子线程中访问主界面控件值
                    {
                        IPEndPoint LocalIPEndPoint = new IPEndPoint(IPAddress.Parse(comboBoxHostIp.Text), int.Parse(textBoxPortNumber.Text));
                        //udpserver = new UdpClient(int.Parse(this.textBoxPortNumber.Text));//创建UDP服务器，绑定要监听的端口  
                        UDPServer = new UdpClient(LocalIPEndPoint);//创建UDP服务器，绑定要监听的端口
                    }));
                    break;

                }
                catch (Exception ex)
                {
                    //端口不可用就将预设的端口号加1  
                    MessageBox.Show(ex.Message, "错误,该端口号不能使用，点击确定按钮自动加一尝试重新开启", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Invoke(new Action(() =>
                    {
                        this.textBoxPortNumber.Text = (int.Parse(this.textBoxPortNumber.Text) + i++).ToString();
                    }));
                }
            } 
            #endregion

            remoteIpAndPort = new IPEndPoint(IPAddress.Any, 0);//定义IPENDPOINT，装载远程IP地址和端口                      

            while (true)
            {
                try
                {
                    //将udpserver接受到指定的远程主机的数据包分别转换成字符串和数组形式保存在临时变量  
                    receivedStr = System.Text.Encoding.UTF8.GetString(UDPServer.Receive(ref remoteIpAndPort));
                    receiveddata = UDPServer.Receive(ref remoteIpAndPort);

                    if (DataCheckEvent != null)//事件调用
                    { //如果有对象注册
                        if (DataCheckEvent(receiveddata, receiveddata.Length))//和校验通过
                        {
                            DataanalysisEvent(receiveddata, receiveddata.Length);//数据解析
                        }
                    }

                    //定义匿名委托,分号结尾,用于刷新显示远程端口
                    displayMessageDelegate dis = delegate ()
                    {
                        this.textBoxRemoteIp.Text = remoteIpAndPort.Address.ToString();//远程主机的IP显示到窗体  
                        this.textBoxRemotePort.Text = remoteIpAndPort.Port.ToString();//远程主机的端口号显示到窗体                                      
                    };
                    this.Invoke(dis);//执行委托  

                }

                catch(Exception e)
                {
                    MessageBox.Show(e.ToString(),"cuowu");
                    //break;
                }

            }
        }

        private void udpClose()
        {
            udpListenThread.Abort();//kill线程
            UDPServer.Close();//释放UDP连接  
            this.islisten = false;
            //Application.Exit();
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            if (this.islisten == false)
            {//监听已停止
                udpListenThread = new Thread(new ThreadStart(udpListen));//创建监听线程  
                udpListenThread.IsBackground = true;//设为后台线程  
                udpListenThread.Start();//启动监听线程
                this.islisten = true;
            }
            else
            {//监听已开启
                udpClose();
            }
            comboBoxHostIp.Enabled = !this.islisten;
            textBoxPortNumber.Enabled = !this.islisten;
            buttonRefresh .Enabled =!this.islisten;
            if (this.islisten)
            {
                this.Invoke(new Action(() =>
                {
                    buttonListen.Text = "关闭服务器";
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    buttonListen.Text = "开启服务器";
                }));
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            comboBoxHostIp.Items.Clear();
            for (int i = 0; i < Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length; i++)
            {
                if (Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].AddressFamily.ToString().Equals("InterNetwork"))
                {
                    this.comboBoxHostIp.Items.Add(Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString());
                    comboBoxHostIp.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString();
                }
            }
        }

        public void senddata(byte[] dgram)
        {
            this.UDPServer.Send(dgram, dgram.Length, remoteIpAndPort);
        }
    }
}
