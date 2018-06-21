namespace quadrotor_groundstation
{
    partial class udpserver
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
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxRemoteIp = new System.Windows.Forms.TextBox();
            this.buttonListen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHostIp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPortNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRemotePort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(67, 126);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 16;
            this.buttonRefresh.Text = "IP refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textBoxRemoteIp
            // 
            this.textBoxRemoteIp.Location = new System.Drawing.Point(42, 194);
            this.textBoxRemoteIp.Name = "textBoxRemoteIp";
            this.textBoxRemoteIp.Size = new System.Drawing.Size(100, 21);
            this.textBoxRemoteIp.TabIndex = 11;
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(176, 126);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(75, 23);
            this.buttonListen.TabIndex = 15;
            this.buttonListen.Text = "Open server";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Local IP";
            // 
            // comboBoxHostIp
            // 
            this.comboBoxHostIp.FormattingEnabled = true;
            this.comboBoxHostIp.Location = new System.Drawing.Point(42, 83);
            this.comboBoxHostIp.Name = "comboBoxHostIp";
            this.comboBoxHostIp.Size = new System.Drawing.Size(124, 20);
            this.comboBoxHostIp.TabIndex = 14;
            this.comboBoxHostIp.Text = "192.168.1.102";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Local Port";
            // 
            // textBoxPortNumber
            // 
            this.textBoxPortNumber.Location = new System.Drawing.Point(176, 82);
            this.textBoxPortNumber.Name = "textBoxPortNumber";
            this.textBoxPortNumber.Size = new System.Drawing.Size(100, 21);
            this.textBoxPortNumber.TabIndex = 12;
            this.textBoxPortNumber.Text = "8080";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Remote IP";
            // 
            // textBoxRemotePort
            // 
            this.textBoxRemotePort.Location = new System.Drawing.Point(176, 194);
            this.textBoxRemotePort.Name = "textBoxRemotePort";
            this.textBoxRemotePort.Size = new System.Drawing.Size(100, 21);
            this.textBoxRemotePort.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Remote Port";
            // 
            // udpserver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.textBoxRemoteIp);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxHostIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPortNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRemotePort);
            this.Controls.Add(this.label4);
            this.Name = "udpserver";
            this.Size = new System.Drawing.Size(316, 288);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBoxRemoteIp;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxHostIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPortNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRemotePort;
        private System.Windows.Forms.Label label4;
    }
}
