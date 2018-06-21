namespace quadrotor_groundstation.usercontrol
{
    partial class waveerror
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxROL = new System.Windows.Forms.CheckBox();
            this.checkBoxPIT = new System.Windows.Forms.CheckBox();
            this.checkBoxYAW = new System.Windows.Forms.CheckBox();
            this.checkBoxrcrol = new System.Windows.Forms.CheckBox();
            this.checkBoxrcpit = new System.Windows.Forms.CheckBox();
            this.checkBoxrcyaw = new System.Windows.Forms.CheckBox();
            this.checkBoxrcthr = new System.Windows.Forms.CheckBox();
            this.checkBoxheight = new System.Windows.Forms.CheckBox();
            this.Status = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Status.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(790, 386);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // checkBoxROL
            // 
            this.checkBoxROL.AutoSize = true;
            this.checkBoxROL.Location = new System.Drawing.Point(24, 20);
            this.checkBoxROL.Name = "checkBoxROL";
            this.checkBoxROL.Size = new System.Drawing.Size(42, 16);
            this.checkBoxROL.TabIndex = 1;
            this.checkBoxROL.Text = "ROL";
            this.checkBoxROL.UseVisualStyleBackColor = true;
            // 
            // checkBoxPIT
            // 
            this.checkBoxPIT.AutoSize = true;
            this.checkBoxPIT.Location = new System.Drawing.Point(125, 20);
            this.checkBoxPIT.Name = "checkBoxPIT";
            this.checkBoxPIT.Size = new System.Drawing.Size(42, 16);
            this.checkBoxPIT.TabIndex = 1;
            this.checkBoxPIT.Text = "PIT";
            this.checkBoxPIT.UseVisualStyleBackColor = true;
            // 
            // checkBoxYAW
            // 
            this.checkBoxYAW.AutoSize = true;
            this.checkBoxYAW.Location = new System.Drawing.Point(226, 20);
            this.checkBoxYAW.Name = "checkBoxYAW";
            this.checkBoxYAW.Size = new System.Drawing.Size(42, 16);
            this.checkBoxYAW.TabIndex = 1;
            this.checkBoxYAW.Text = "YAW";
            this.checkBoxYAW.UseVisualStyleBackColor = true;
            // 
            // checkBoxrcrol
            // 
            this.checkBoxrcrol.AutoSize = true;
            this.checkBoxrcrol.Location = new System.Drawing.Point(24, 20);
            this.checkBoxrcrol.Name = "checkBoxrcrol";
            this.checkBoxrcrol.Size = new System.Drawing.Size(54, 16);
            this.checkBoxrcrol.TabIndex = 1;
            this.checkBoxrcrol.Text = "Rcrol";
            this.checkBoxrcrol.UseVisualStyleBackColor = true;
            // 
            // checkBoxrcpit
            // 
            this.checkBoxrcpit.AutoSize = true;
            this.checkBoxrcpit.Location = new System.Drawing.Point(126, 20);
            this.checkBoxrcpit.Name = "checkBoxrcpit";
            this.checkBoxrcpit.Size = new System.Drawing.Size(54, 16);
            this.checkBoxrcpit.TabIndex = 1;
            this.checkBoxrcpit.Text = "Rcpit";
            this.checkBoxrcpit.UseVisualStyleBackColor = true;
            // 
            // checkBoxrcyaw
            // 
            this.checkBoxrcyaw.AutoSize = true;
            this.checkBoxrcyaw.Location = new System.Drawing.Point(228, 20);
            this.checkBoxrcyaw.Name = "checkBoxrcyaw";
            this.checkBoxrcyaw.Size = new System.Drawing.Size(54, 16);
            this.checkBoxrcyaw.TabIndex = 1;
            this.checkBoxrcyaw.Text = "Rcyaw";
            this.checkBoxrcyaw.UseVisualStyleBackColor = true;
            // 
            // checkBoxrcthr
            // 
            this.checkBoxrcthr.AutoSize = true;
            this.checkBoxrcthr.Location = new System.Drawing.Point(330, 20);
            this.checkBoxrcthr.Name = "checkBoxrcthr";
            this.checkBoxrcthr.Size = new System.Drawing.Size(54, 16);
            this.checkBoxrcthr.TabIndex = 1;
            this.checkBoxrcthr.Text = "Rcthr";
            this.checkBoxrcthr.UseVisualStyleBackColor = true;
            // 
            // checkBoxheight
            // 
            this.checkBoxheight.AutoSize = true;
            this.checkBoxheight.Location = new System.Drawing.Point(327, 20);
            this.checkBoxheight.Name = "checkBoxheight";
            this.checkBoxheight.Size = new System.Drawing.Size(60, 16);
            this.checkBoxheight.TabIndex = 1;
            this.checkBoxheight.Text = "Height";
            this.checkBoxheight.UseVisualStyleBackColor = true;
            this.checkBoxheight.CheckedChanged += new System.EventHandler(this.checkBoxheight_CheckedChanged);
            // 
            // Status
            // 
            this.Status.Controls.Add(this.checkBoxROL);
            this.Status.Controls.Add(this.checkBoxPIT);
            this.Status.Controls.Add(this.checkBoxheight);
            this.Status.Controls.Add(this.checkBoxYAW);
            this.Status.Location = new System.Drawing.Point(3, 395);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(394, 48);
            this.Status.TabIndex = 2;
            this.Status.TabStop = false;
            this.Status.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxrcrol);
            this.groupBox1.Controls.Add(this.checkBoxrcpit);
            this.groupBox1.Controls.Add(this.checkBoxrcyaw);
            this.groupBox1.Controls.Add(this.checkBoxrcthr);
            this.groupBox1.Location = new System.Drawing.Point(403, 395);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rcdata";
            // 
            // waveerror
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.pictureBox1);
            this.Name = "waveerror";
            this.Size = new System.Drawing.Size(923, 452);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxROL;
        private System.Windows.Forms.CheckBox checkBoxPIT;
        private System.Windows.Forms.CheckBox checkBoxYAW;
        private System.Windows.Forms.CheckBox checkBoxrcrol;
        private System.Windows.Forms.CheckBox checkBoxrcpit;
        private System.Windows.Forms.CheckBox checkBoxrcyaw;
        private System.Windows.Forms.CheckBox checkBoxrcthr;
        private System.Windows.Forms.CheckBox checkBoxheight;
        private System.Windows.Forms.GroupBox Status;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
