using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quadrotor_groundstation.usercontrol
{
    public partial class waveerror : UserControl
    {
        public waveerror()
        {

            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);//开启双缓冲
            this.UpdateStyles();
        }


        private const int Unit_length = 20;//单位格大小

        //private int DrawStep = 1;//默认绘制单位10
        private float DrawStep = 0.25F;//默认绘制单位10

        private const int Y_Max = 367;//Y轴最大数值
        private const int MaxStep = 21;//绘制单位最大值
        private const int MinStep = 1;//绘制单位最小值
        private const int StartPrint = 32;//点坐标偏移量
        private List<int> DataListROL = new List<int>();//数据结构----线性链表
        private List<int> DataListPIT = new List<int>();
        private List<int> DataListYAW = new List<int>();
        private List<int> DataListheight = new List<int>();

        private List<int> DataListRecvROL = new List<int>();//数据结构----线性链表
        private List<int> DataListRecvPIT = new List<int>();
        private List<int> DataListRecvYAW = new List<int>();
        private List<int> DataListRecvTHR = new List<int>();

        //private Pen TablePen = new Pen(Color.FromArgb(0x90, 0xEE, 0x90));//轴线颜色
        private Pen TablePen = new Pen(Color.FromArgb(0x90, 0x90, 0x90));//轴线颜色

        private Pen LinesPenROL = new Pen(Color.FromArgb(0x98, 0x00, 0x00), 1);//波形颜色
        private Pen LinesPenPIT = new Pen(Color.FromArgb(0xff, 0x00, 0x00), 1);//波形颜色
        private Pen LinesPenYAW = new Pen(Color.FromArgb(0xff, 0x99, 0x00), 1);//波形颜色
        private Pen LinesPenheight = new Pen(Color.FromArgb(0x07, 0x37, 0x63), 2);//波形颜色

        private Pen LinesPenRecvROL = new Pen(Color.FromArgb(0x00, 0xff, 0x00), 1);//波形颜色
        private Pen LinesPenRecvPIT = new Pen(Color.FromArgb(0x00, 0xff, 0xff), 1);//波形颜色
        private Pen LinesPenRecvYAW = new Pen(Color.FromArgb(0x4a, 0x86, 0xe8), 1);//波形颜色
        private Pen LinesPenRecvTHR = new Pen(Color.FromArgb(0x00, 0x00, 0xff), 1);//波形颜色

        public void AddstatusData(int rol, int pit, int yaw, int height,int RecvROL, int RecvPIT, int RecvYAW, int RecvTHR)
        {
            DataListROL.Add(rol);//链表尾部添加数据
            DataListPIT.Add(pit);
            DataListYAW.Add(yaw);
            DataListheight.Add(height);

            DataListRecvROL.Add(RecvROL);//链表尾部添加数据
            DataListRecvPIT.Add(RecvPIT);
            DataListRecvYAW.Add(RecvYAW);
            DataListRecvTHR.Add(RecvTHR);
            Invalidate();//刷新显示
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            String Str = "";
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            e.Graphics.FillRectangle(Brushes.White, e.Graphics.ClipBounds);//背景色填充

            //Draw Y 纵向轴绘制
            for (int i = 0; i <= this.ClientRectangle.Width / Unit_length; i++)
            {
                if (i == 37)
                    break;
                e.Graphics.DrawLine(TablePen, StartPrint + i * Unit_length, 7, StartPrint + i * Unit_length, Y_Max);//画线

                gp.AddString((i * 2).ToString(), this.Font.FontFamily, (int)FontStyle.Regular, 12, new RectangleF(StartPrint + i * Unit_length - 10, 367, 400, 50), null);//添加文字
            }
            //Draw X 横向轴绘制
            for (int i = 0; i <= this.ClientRectangle.Height / Unit_length; i++)
            {
                if (i == 19)
                    break;
                e.Graphics.DrawLine(TablePen, StartPrint, i * Unit_length + 7, 752, i * Unit_length + 7);//画线
                Str = ((18 - 2 * i) * 10).ToString();
                if (i != 18)
                    gp.AddString(Str, this.Font.FontFamily, (int)FontStyle.Regular, 14, new RectangleF(0, i * Unit_length, 400, 50), null);//添加文字
            }
            e.Graphics.DrawPath(Pens.Black, gp);//写文字

            //if (DataListROL.Count > 720)//如果数据量大于可容纳的数据量，即删除最左数据
            //{
            //    DataListROL.RemoveRange(0, 1);
            //}
            //if (DataListPIT.Count > 720)//如果数据量大于可容纳的数据量，即删除最左数据
            //{
            //    DataListPIT.RemoveRange(0, 1);
            //}
            //if (DataListYAW.Count > 720)//如果数据量大于可容纳的数据量，即删除最左数据
            //{
            //    DataListYAW.RemoveRange(0, 1);
            //}
            //if (DataListheight.Count > 720)//如果数据量大于可容纳的数据量，即删除最左数据
            //{
            //    DataListheight.RemoveRange(0, 1);
            //}

            if (DataListROL.Count > 720 * (int)(1.0f / DrawStep))//如果数据量大于可容纳的数据量，即删除最左数据
            {
                DataListROL.RemoveRange(0, DataListROL.Count - 720 * (int)(1.0f / DrawStep));
            }
            if (DataListPIT.Count > 720 * (int)(1.0f / DrawStep))//如果数据量大于可容纳的数据量，即删除最左数据
            {
                DataListPIT.RemoveRange(0, DataListPIT.Count - 720 * (int)(1.0f / DrawStep));
            }
            if (DataListYAW.Count > 720 * (int)(1.0f / DrawStep))//如果数据量大于可容纳的数据量，即删除最左数据
            {
                DataListYAW.RemoveRange(0, DataListYAW.Count - 720 * (int)(1.0f / DrawStep));
            }
            if (DataListheight.Count > 720 * (int)(1.0f / DrawStep))//如果数据量大于可容纳的数据量，即删除最左数据
            {
                DataListheight.RemoveRange(0, DataListheight.Count - 720 * (int)(1.0f / DrawStep));
            }
            if (DataListRecvROL.Count > 720 * (int)(1.0f / DrawStep))//如果数据量大于可容纳的数据量，即删除最左数据
            {
                DataListRecvROL.RemoveRange(0, DataListRecvROL.Count - 720 * (int)(1.0f / DrawStep));
            }
            if (DataListRecvPIT.Count > 720 * (int)(1.0f / DrawStep))//如果数据量大于可容纳的数据量，即删除最左数据
            {
                DataListRecvPIT.RemoveRange(0, DataListRecvPIT.Count - 720 * (int)(1.0f / DrawStep));
            }
            if (DataListRecvYAW.Count > 720 * (int)(1.0f / DrawStep))//如果数据量大于可容纳的数据量，即删除最左数据
            {
                DataListRecvYAW.RemoveRange(0, DataListRecvYAW.Count - 720 * (int)(1.0f / DrawStep));
            }
            if (DataListRecvTHR.Count > 720 * (int)(1.0f / DrawStep))//如果数据量大于可容纳的数据量，即删除最左数据
            {
                DataListRecvTHR.RemoveRange(0, DataListRecvTHR.Count - 720 * (int)(1.0f / DrawStep));
            }

            for (int i = 0; i < DataListROL.Count - 1; i++)//绘制
            {
                if(checkBoxROL.Checked)
                    e.Graphics.DrawLine(LinesPenROL, StartPrint + i * DrawStep, 187 - DataListROL[i], StartPrint + (i + 1) * DrawStep, 187 - DataListROL[i + 1]);
                if (checkBoxPIT.Checked)
                    e.Graphics.DrawLine(LinesPenPIT, StartPrint + i * DrawStep, 187 - DataListPIT[i], StartPrint + (i + 1) * DrawStep, 187 - DataListPIT[i + 1]);
                if (checkBoxYAW.Checked)
                    e.Graphics.DrawLine(LinesPenYAW, StartPrint + i * DrawStep, 187 - DataListYAW[i], StartPrint + (i + 1) * DrawStep, 187 - DataListYAW[i + 1]);
                if (checkBoxheight.Checked)
                    e.Graphics.DrawLine(LinesPenheight, StartPrint + i * DrawStep, 187 - DataListheight[i], StartPrint + (i + 1) * DrawStep, 187 - DataListheight[i + 1]);
                if (checkBoxrcrol.Checked)
                    e.Graphics.DrawLine(LinesPenRecvROL, StartPrint + i * DrawStep, 187 - DataListRecvROL[i], StartPrint + (i + 1) * DrawStep, 187 - DataListRecvROL[i + 1]);
                if (checkBoxrcpit.Checked)
                    e.Graphics.DrawLine(LinesPenRecvPIT, StartPrint + i * DrawStep, 187 - DataListRecvPIT[i], StartPrint + (i + 1) * DrawStep, 187 - DataListRecvPIT[i + 1]);
                if (checkBoxrcyaw.Checked)
                    e.Graphics.DrawLine(LinesPenRecvYAW, StartPrint + i * DrawStep, 187 - DataListRecvYAW[i], StartPrint + (i + 1) * DrawStep, 187 - DataListRecvYAW[i + 1]);
                if (checkBoxrcthr.Checked)
                    e.Graphics.DrawLine(LinesPenRecvTHR, StartPrint + i * DrawStep, 187 - DataListRecvTHR[i], StartPrint + (i + 1) * DrawStep, 187 - DataListRecvTHR[i + 1]);
            }
        }

        private void checkBoxheight_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
