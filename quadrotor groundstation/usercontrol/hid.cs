using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace quadrotor_groundstation.usercontrol
{
    public partial class hid : UserControl
    {
        USBHID usbHID = null;
        public string receivedStr;//保存接收的数据字符的临时变量  
        public byte[] receiveddata;

        private Thread hidDATAProcessThread;//UDP监听线程  

        public delegate bool DataCheckdelegate(byte[] data, int num);
        public event DataCheckdelegate DataCheckEvent;        //声明和校验事件

        public delegate void Dataanalysisdelegate(byte[] data, int num);
        public event Dataanalysisdelegate DataanalysisEvent;        //声明数据解析事件

        public hid()
        {
            InitializeComponent();
            
            usbHID = new USBHID();

            foreach (string device in usbHID.GetDeviceList())
                list_UsbHID.Items.Add(device);

            usbHID.DataReceived += usbHID_DataReceived;
            usbHID.DeviceRemoved += usbHID_DeviceRemoved;
        }

        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }


        void usbHID_DeviceRemoved(object sender, EventArgs e)
        {
            report myRP = (report)e;
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usbHID_DeviceRemoved), new object[] { sender, e });
            }
            else
            {
                tb_information.Text = "设备连接";
            }
        }

        void hidDATAProcess()
        {
            if (DataCheckEvent != null)//事件调用
            { //如果有对象注册
              //if (DataCheckEvent(receiveddata, receiveddata.Length))//和校验通过
              //{
                DataanalysisEvent(receiveddata, receiveddata.Length);//数据解析
                                                                     //}
            }
        }

        void usbHID_DataReceived(object sender, EventArgs e)
        {
            report myRP = (report)e;
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usbHID_DataReceived), new object[] { sender, e });
            }
            else
            {
                receivedStr = USBHID.ByteToHexString(myRP.reportBuff).Substring(2, 100);
                //tb_information.Text += "\r\n" + receivedStr;

                receiveddata = HexStringToByteArray(receivedStr);

                //hidDATAProcessThread = new Thread(new ThreadStart(hidDATAProcess));//创建监听线程  
                //hidDATAProcessThread.IsBackground = true;//设为后台线程  
                //hidDATAProcessThread.Start();//启动监听线程

                if (DataCheckEvent != null)//事件调用
                { //如果有对象注册
                    //if (DataCheckEvent(receiveddata, receiveddata.Length))//和校验通过
                    //{
                        DataanalysisEvent(receiveddata, receiveddata.Length);//数据解析
                    //}
                }
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (list_UsbHID.SelectedItem == null)
            {
                tb_information.Text += "\r\n vendorID和productID不能为空";
                return;
            }

            if (usbHID.OpenUSBHid(list_UsbHID.SelectedItem.ToString()))
                tb_information.Text += "\r\n open success";
            else
                tb_information.Text += "\r\n open fail";
        }


        public void senddata(byte[] dgram)
        {
            usbHID.Write(dgram);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_information.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list_UsbHID.Items.Clear ();
            usbHID = new USBHID();
            foreach (string device in usbHID.GetDeviceList())
            list_UsbHID.Items.Add(device);
        }

        private void hid_Load(object sender, EventArgs e)
        {

        }
    }
}
