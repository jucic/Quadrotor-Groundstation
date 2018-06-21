using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quadrotor_groundstation.usercontrol;
using System.IO;

namespace quadrotor_groundstation.userclass
{
    class dataanalysis
    {
        static int i = 0;
        public bool writecsvflag=false;
        static short Rol = 0, Pit = 0, Yaw = 0, Hei = 0;
        public int TargetHeight=90;
        static short a_x, a_y, a_z, g_x, g_y, g_z, m_x, m_y, m_z;
        static short THR,YAW,ROL,PIT,AUX1,AUX2,AUX3,AUX4,AUX5,AUX6;//飞机接收到的控制数据

        //设置csv文件的完整路径 可以是绝对或相对路径    

        public delegate void showstatusdelegate(short Rol, short Pit, short Yaw );   //声明状态数据刷新委托
        public event showstatusdelegate statusshowEvent;        //声明状态数据刷新事件

        public delegate void showsensordelegate(int a_x, int a_y, int a_z, int g_x, int g_y, int g_z, int m_x, int m_y, int m_z);   //声明传感器数据刷新委托
        public event showsensordelegate showsensorshowEvent;        //声明传感器数据刷新事件

        public delegate void showheightdelegate(short Hei);   //声明状态数据刷新委托
        public event showheightdelegate heightshowEvent;        //声明状态数据刷新事件

        public delegate void showrecvdatadelegate(int THR, int YAW, int ROL, int PIT, int AUX1, int AUX2, int AUX3, int AUX4, int AUX5, int AUX6);   //声明传感器数据刷新委托
        public event showrecvdatadelegate showrecvdataEvent;        //声明传感器数据刷新事件

        public delegate void WaveAlldelegate(int rol, int pit, int yaw, int height, int RecvROL, int RecvPIT, int RecvYAW, int RecvTHR);   //声明波形数据刷新委托
        public event WaveAlldelegate WaveAllEvent;        //声明事件

        public delegate void WaveAlldelegate1(int rol, int pit, int yaw, int height, int RecvROL, int RecvPIT, int RecvYAW, int RecvTHR);   //声明波形数据刷新委托
        public event WaveAlldelegate1 WaveAllEvent1;        //声明事件

        public delegate void writecsvdelegate(string rol, string pit, string yaw, string height, string RCrol, string RCpit, string RCyaw, string RCthr, string TargetHeight);   //写入数据委托
        public event writecsvdelegate writecsvEvent;        //写入数据事件

        public  void DataAnalysis(byte[] data, int num)//从数据报中解析出有用信息
        {

            if (data[0] == 0xAA && data[1] == 0xAA)     //帧头
            {
                if (data[2] == 0X01)
                {
                    Rol = (short)(((0 ^ data[4]) << 8) ^ data[5]);  //将b1赋给s的低8位
                    Pit = (short)(((0 ^ data[6]) << 8) ^ data[7]);  //将b1赋给s的低8位
                    Yaw = (short)(((0 ^ data[8]) << 8) ^ data[9]);  //将b1赋给s的低8位
                    //WaverolpityawEvent((int)(Rol / 100), (int)(Pit / 100), (int)(Yaw / 100));
                }
                if (data[2] == 0X02)
                {
                    a_x = (short)(((0 ^ data[4]) << 8) ^ data[5]);
                    a_y = (short)(((0 ^ data[6]) << 8) ^ data[7]);
                    a_z = (short)(((0 ^ data[8]) << 8) ^ data[9]);
                    g_x = (short)(((0 ^ data[10]) << 8) ^ data[11]);
                    g_y = (short)(((0 ^ data[12]) << 8) ^ data[13]);
                    g_z = (short)(((0 ^ data[14]) << 8) ^ data[15]);
                    m_x = (short)(((0 ^ data[16]) << 8) ^ data[17]);
                    m_y = (short)(((0 ^ data[18]) << 8) ^ data[19]);
                    m_z = (short)(((0 ^ data[20]) << 8) ^ data[21]);
                }
                if (data[2] == 0X03)
                {
                    THR = (short)(((0 ^ data[4]) << 8) ^ data[5]);
                    YAW = (short)(((0 ^ data[6]) << 8) ^ data[7]);
                    ROL = (short)(((0 ^ data[8]) << 8) ^ data[9]);
                    PIT = (short)(((0 ^ data[10]) << 8) ^ data[11]);
                    AUX1 = (short)(((0 ^ data[12]) << 8) ^ data[13]);
                    AUX2 = (short)(((0 ^ data[14]) << 8) ^ data[15]);
                    AUX3 = (short)(((0 ^ data[16]) << 8) ^ data[17]);
                    AUX4 = (short)(((0 ^ data[18]) << 8) ^ data[19]);
                    AUX5 = (short)(((0 ^ data[20]) << 8) ^ data[21]);
                    AUX6 = (short)(((0 ^ data[22]) << 8) ^ data[23]);
                }
                if (data[2] == 0X07)
                {
                    Hei = (short)(((0 ^ data[8]) << 8) ^ data[9]);
                    //WaveheightEvent(Hei);
                }

                statusshowEvent(Rol, Pit, Yaw);
                showsensorshowEvent((int)a_x, (int)a_y, (int)a_z, (int)g_x, (int)g_y, (int)g_z, (int)m_x, (int)m_y, (int)m_z);
                heightshowEvent(Hei);
                showrecvdataEvent(THR, YAW, ROL, PIT, AUX1, AUX2, AUX3, AUX4, AUX5, AUX6);

                //WaveAllEvent((int)(Rol / 100), (int)(Pit / 100), (int)(Yaw / 100), Hei, (ROL-1500)/3, (PIT - 1500) / 3, (YAW - 1500) / 3, (THR - 1500) / 3);
                WaveAllEvent1((int)(Rol / 100), (int)(Pit / 100), (int)(Yaw / 100), Hei, (ROL - 1500) / 3, (PIT - 1500) / 3, (YAW - 1500) / 3, (THR - 1500) / 3);

                if (writecsvflag == true)
                {
                    i++;
                   // string fileName = "C:\\Users\\Administrator\\Desktop\\1.csv";   //指定文件保存在 当前项目文件夹中的bin/debug/文件夹中
                   //// if (!System.IO.File.Exists("C:\\Users\\Administrator\\Desktop\\1.csv"))
                   // StreamWriter sw = new StreamWriter(fileName, true, Encoding.Default);


                    if (i == 1)
                    {
                        ////向文件中输出一行记录  csv文件为逗号分隔符格式文件  同一行中单元格之间用逗号分开
                        //sw.WriteLine("高度,姓名,年龄");
                        if(writecsvEvent!=null)
                        writecsvEvent("Rol", "Pit", "Yaw", "Hei",  "RCrol", "RCpit", "RCyaw", "RCthr", "TargetHeight");
                    }
                //sw.WriteLine("{0},张三,20", Hei.ToString());
                if (writecsvEvent != null)
                    writecsvEvent(Rol.ToString(), Pit.ToString(), Yaw.ToString(), Hei.ToString(), ROL.ToString(), PIT.ToString(), YAW.ToString(), THR.ToString(), (TargetHeight/10).ToString());
                }

            }
        }

    }
}
