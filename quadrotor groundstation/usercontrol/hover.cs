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
using System.Diagnostics;

namespace quadrotor_groundstation.usercontrol
{
    public partial class hover : UserControl
    {
        public Capture _capture = null;
        Mat frame = new Mat();
        MCvScalar pixel;
        Thread FrameProcessThread;

        public delegate void controldatasenddelegate(byte[] DATA);   //声明状态数据刷新委托
        public event controldatasenddelegate controldatasendEvent;        //声明状态数据刷新事件

        public hover()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
        }

        //public void ProcessFramethread(object sender, EventArgs arg)//图像处理函数 object sender, EventArgs arg
        //{
        //    FrameProcessThread = new Thread(new ThreadStart(ProcessFrame));//创建监听线程  
        //    FrameProcessThread.IsBackground = true;//设为后台线程  
        //    FrameProcessThread.Start();//启动监听线程
        
        //}

        public void ProcessFrame(object sender, EventArgs arg)
        {
            try
            {
                //  Mat frame = new Mat();
                _capture.Retrieve(frame, 0);//1检索frame
                //captureImageBox.Image = frame;

                //for (int i = 0; i < frame.Size.Height; i++)//提取红色
                //{
                //    for (int j = 0; j < frame.Size.Width; j++)
                //    {
                //        pixel = CvInvoke.cvGet2D(frame, i, j); // 获得像素值
                //        if (pixel.V0 < 50 && pixel.V1 < 50 && pixel.V2 > 200)//注意这里的012对应的是bgr，范围的意思是防止光线的明暗影响，可以适当放宽，另外你也可以选择其他的颜色空间，可以直接取消明暗影响，比如HSV
                //        {
                //            pixel.V0 = 0;
                //            pixel.V1 = 0;
                //            pixel.V2 = 255;
                //        }  //如果满足条件就设置为红色
                //        else
                //        {
                //            pixel.V0 = 0;
                //            pixel.V1 = 0;
                //            pixel.V2 = 0;
                //        } //如果不满足就设置为黑色
                //        CvInvoke.cvSet2D(frame, i, j, pixel);   //设置像素
                //    }
                //}
                //captureImageBox.Image = frame;

                UMat uimage = new UMat();
                CvInvoke.CvtColor(frame, uimage, ColorConversion.Bgr2Gray);//灰度化

                UMat pyrDown = new UMat();
                UMat smoothedGrayFrame = new UMat();
                CvInvoke.PyrDown(uimage, pyrDown);//滤波金字塔缩小？？
                CvInvoke.PyrUp(pyrDown, smoothedGrayFrame);//金字塔放大？

                #region 圆
                #region circle detection
                using (smoothedGrayFrame)
                {
                    double cannyThreshold = 130;//180越小要求越低
                    double circleAccumulatorThreshold = 120;//120越小要求越低
                    CircleF[] circles = CvInvoke.HoughCircles(smoothedGrayFrame, HoughType.Gradient, 2.0, 20.0, cannyThreshold, circleAccumulatorThreshold, 0, 0);
                    #endregion

                    #region draw circles
                    //Mat circleImage = new Mat(frame.Size, DepthType.Cv8U, 3);
                    //circleImage.SetTo(new MCvScalar(100));
                    int circlecount = 0;
                    foreach (CircleF circle in circles)
                    {
                        circlecount++;
                        if (circlecount == 1)
                        {
                            CvInvoke.Circle(frame, Point.Round(circle.Center), (int)circle.Radius, new Bgr(Color.Brown).MCvScalar, 2);

                            #region 处理
                            double kp_rol, ki_rol, kd_rol, current_x_offset = 0, last_x_offset = 0, sum_x_offset = 0;
                            int rol, rol_max = 150, rol_min = -150;
                            kp_rol = 0.5; ki_rol = 0; kd_rol = 0;//0.3,0.03,0.1
                            current_x_offset = Point.Round(circle.Center).X - 320;
                            sum_x_offset += current_x_offset;
                            if (sum_x_offset > 500) sum_x_offset = 500;//积分限福防饱和
                            rol = (int)(kp_rol * current_x_offset + ki_rol * sum_x_offset + kd_rol * (current_x_offset - last_x_offset));
                            if (rol > rol_max)
                                rol = rol_max;
                            if (rol < rol_min)
                                rol = rol_min;
                            last_x_offset = current_x_offset;

                            double kp_pit, ki_pit, kd_pit, current_y_offset = 0, last_y_offset = 0, sum_y_offset = 0;
                            int pit, pit_max = 150, pit_min = -150;
                            kp_pit = 0.5; ki_pit = 0; kd_pit = 0; //0.3,0.03,0.1
                            current_y_offset = 240 - Point.Round(circle.Center).Y;
                            sum_y_offset += current_y_offset;
                            if (sum_y_offset > 500) sum_y_offset = 500;//积分限福防饱和
                            pit = (int)(kp_pit * current_y_offset + ki_pit * sum_y_offset + kd_pit * (current_y_offset - last_y_offset));
                            if (pit > pit_max)
                                pit = pit_max;
                            if (pit < pit_min)
                                pit = pit_min;
                            last_y_offset = current_y_offset;

                            byte[] rolbyte = BitConverter.GetBytes(rol);
                            byte[] pitbyte = BitConverter.GetBytes(pit);
                            byte[] pitrolbyteData = new byte[65]; //new byte[64];
                            pitrolbyteData[0] = 0X00; pitrolbyteData[1] = 0X0C; pitrolbyteData[2] = 0XAA; pitrolbyteData[3] = 0XAF; pitrolbyteData[4] = 0X04; pitrolbyteData[5] = 0X08;
                            // pitrolbyteData[6] = 0XFC;//功能字
                            pitrolbyteData[6] = rolbyte[0]; pitrolbyteData[7] = rolbyte[1]; pitrolbyteData[8] = rolbyte[2]; pitrolbyteData[9] = rolbyte[3];
                            pitrolbyteData[10] = pitbyte[0]; pitrolbyteData[11] = pitbyte[1]; pitrolbyteData[12] = pitbyte[2]; pitrolbyteData[13] = pitbyte[3];
                            // pitrolbyteData[10] = 0; pitrolbyteData[11] = 0; pitrolbyteData[12] = 0; pitrolbyteData[13] = 0;

                            if (checkBox1.Checked)
                            {
                                controldatasendEvent(pitrolbyteData);
                            }

                            int Rolsend = 0, pitsend = 0;
                            Rolsend = (int)((((((Rolsend ^ rolbyte[3]) << 8) ^ rolbyte[2]) << 8) ^ rolbyte[1]) << 8) ^ rolbyte[0];
                            pitsend = (int)((((((pitsend ^ pitbyte[3]) << 8) ^ pitbyte[2]) << 8) ^ pitbyte[1]) << 8) ^ pitbyte[0];
                            #endregion

                            this.Invoke(new Action(() =>
                            {
                                textBox3.Text = Point.Round(circle.Center).X.ToString();
                                textBox4.Text = Point.Round(circle.Center).Y.ToString();
                                textBox1.Text = current_x_offset.ToString();
                                textBox2.Text = current_y_offset.ToString();
                                textBox5.Text = rol.ToString();
                                textBox6.Text = pit.ToString();
                            }));

                        }
                    }
                    captureImageBox.Image = frame;
                }
                #endregion
                #endregion

                #region 线
                //#region Canny and edge detection
                //double cannyThreshold = 180.0;
                //double cannyThresholdLinking = 120.0;
                //UMat cannyEdges = new UMat();
                //CvInvoke.Canny(smoothedGrayFrame, cannyEdges, cannyThreshold, cannyThresholdLinking);
                //LineSegment2D[] lines = CvInvoke.HoughLinesP(
                //   cannyEdges,
                //   1, //Distance resolution in pixel-related units
                //   Math.PI / 45.0, //Angle resolution measured in radians.
                //   20, //threshold
                //   30, //min Line width
                //   10); //gap between lines
                //#endregion

                //#region draw lines
                ////Mat lineImage = new Mat(frame.Size, DepthType.Cv8U, 3);
                ////lineImage.SetTo(new MCvScalar(0));
                //foreach (LineSegment2D line in lines)
                //CvInvoke.Line(frame, line.P1, line.P2, new Bgr(Color.Green).MCvScalar, 2);
                //captureImageBox.Image = frame;
                //#endregion 
                #endregion

                #region 三角形四边形
                //#region Find triangles and rectangles
                //List<Triangle2DF> triangleList = new List<Triangle2DF>();
                //List<RotatedRect> boxList = new List<RotatedRect>(); //a box is a rotated rectangle

                //using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                //{
                //    CvInvoke.FindContours(smoothedGrayFrame, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                //    int count = contours.Size;
                //    for (int i = 0; i < count; i++)
                //    {
                //        using (VectorOfPoint contour = contours[i])
                //        using (VectorOfPoint approxContour = new VectorOfPoint())
                //        {
                //            CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                //            if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                //            {
                //                if (approxContour.Size == 3) //The contour has 3 vertices, it is a triangle
                //                {
                //                    Point[] pts = approxContour.ToArray();
                //                    triangleList.Add(new Triangle2DF(pts[0], pts[1], pts[2]));
                //                }
                //                else if (approxContour.Size == 4) //The contour has 4 vertices.
                //                {
                //                    #region determine if all the angles in the contour are within [80, 100] degree
                //                    bool isRectangle = true;
                //                    Point[] pts = approxContour.ToArray();
                //                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                //                    for (int j = 0; j < edges.Length; j++)
                //                    {
                //                        double angle = Math.Abs(edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                //                        if (angle < 80 || angle > 100)
                //                        {
                //                            isRectangle = false;
                //                            break;
                //                        }
                //                    }
                //                    #endregion

                //                    if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                //                }
                //            }
                //        }
                //    }
                //}
                //#endregion

                //#region draw triangles and rectangles
                ////Mat triangleRectangleImage = new Mat(frame.Size, DepthType.Cv8U, 3);
                ////triangleRectangleImage.SetTo(new MCvScalar(0));
                //foreach (Triangle2DF triangle in triangleList)
                //{
                //    CvInvoke.Polylines(frame, Array.ConvertAll(triangle.GetVertices(), Point.Round), true, new Bgr(Color.DarkBlue).MCvScalar, 2);
                //}
                //foreach (RotatedRect box in boxList)
                //{
                //    CvInvoke.Polylines(frame, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.DarkOrange).MCvScalar, 2);
                //}
                //captureImageBox.Image = frame;
                //#endregion 
                #endregion

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _capture = new Capture(0);//连上摄像头
                _capture.ImageGrabbed += ProcessFrame;
                //Application.Idle += ProcessFrame1;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
            _capture.Start();
        }

        Stopwatch hs = new Stopwatch();

        private void ProcessFrame1(object sender, EventArgs arg)
        {
            try
            {
                hs.Restart();
                Mat src = new Mat();
                Mat dst = new Mat();
                src = _capture.QueryFrame();
                CvInvoke.CvtColor(src, dst, ColorConversion.Bgr2Gray);//灰度化

                double cannyThreshold = 130;//180越小要求越低
                double circleAccumulatorThreshold = 120;//120越小要求越低
                CircleF[] circles = CvInvoke.HoughCircles(dst, HoughType.Gradient, 2.0, 20.0, cannyThreshold, circleAccumulatorThreshold, 0, 0); //换算法

                int circlecount = 0;
                foreach (CircleF circle in circles)
                {
                    circlecount++;
                    if (circlecount == 1)
                    {
                        CvInvoke.Circle(dst, Point.Round(circle.Center), (int)circle.Radius, new Bgr(Color.Brown).MCvScalar, 2);
                    }
                }

                //Random rd = new Random();
                //Rectangle rect = new Rectangle();
                //for (int i = 0; i < 50; i++)
                //{                   
                //    rect = new Rectangle(rd.Next(0, dst.Width), rd.Next(0, dst.Height), rd.Next(0, dst.Width), rd.Next(0, dst.Height));
                //    CvInvoke.Rectangle(dst, rect, new MCvScalar(0, 0, 255), 5);
                //}
              

                hs.Stop();
               // Console.WriteLine(hs.ElapsedMilliseconds.ToString());
                captureImageBox.Image = dst;
                //circles = null;
            }
            catch (Exception) { }
            finally { GC.Collect(); }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (_capture != null)
                _capture.Dispose();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
