namespace quadrotor_groundstation.usercontrol
{
    partial class videocapt
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.captureImageBox = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(675, 400);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 42);
            this.button4.TabIndex = 36;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(675, 331);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 42);
            this.button3.TabIndex = 35;
            this.button3.Text = "Begin";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "Heigth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(665, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "Width";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(708, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(81, 21);
            this.textBox2.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(708, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(81, 21);
            this.textBox1.TabIndex = 25;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(675, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 42);
            this.button2.TabIndex = 21;
            this.button2.Text = "Record";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 42);
            this.button1.TabIndex = 20;
            this.button1.Text = "Take Photos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // captureImageBox
            // 
            this.captureImageBox.Location = new System.Drawing.Point(3, 3);
            this.captureImageBox.Name = "captureImageBox";
            this.captureImageBox.Size = new System.Drawing.Size(640, 480);
            this.captureImageBox.TabIndex = 19;
            this.captureImageBox.TabStop = false;
            // 
            // videocapt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.captureImageBox);
            this.Name = "videocapt";
            this.Size = new System.Drawing.Size(824, 489);
            this.Load += new System.EventHandler(this.videocapt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Emgu.CV.UI.ImageBox captureImageBox;
    }
}
