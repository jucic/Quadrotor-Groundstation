namespace quadrotor_groundstation.usercontrol
{
    partial class hid
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
            this.label3 = new System.Windows.Forms.Label();
            this.list_UsbHID = new System.Windows.Forms.ListBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_information = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "USBHIDList：:";
            // 
            // list_UsbHID
            // 
            this.list_UsbHID.FormattingEnabled = true;
            this.list_UsbHID.ItemHeight = 12;
            this.list_UsbHID.Location = new System.Drawing.Point(5, 30);
            this.list_UsbHID.Name = "list_UsbHID";
            this.list_UsbHID.Size = new System.Drawing.Size(328, 64);
            this.list_UsbHID.TabIndex = 22;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(257, 327);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 36);
            this.btn_clear.TabIndex = 21;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(3, 327);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 36);
            this.btn_connect.TabIndex = 19;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "Information:";
            // 
            // tb_information
            // 
            this.tb_information.AllowDrop = true;
            this.tb_information.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_information.Location = new System.Drawing.Point(3, 112);
            this.tb_information.Multiline = true;
            this.tb_information.Name = "tb_information";
            this.tb_information.Size = new System.Drawing.Size(330, 195);
            this.tb_information.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 36);
            this.button1.TabIndex = 24;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.list_UsbHID);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_information);
            this.Name = "hid";
            this.Size = new System.Drawing.Size(336, 383);
            this.Load += new System.EventHandler(this.hid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox list_UsbHID;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_information;
        private System.Windows.Forms.Button button1;
    }
}
