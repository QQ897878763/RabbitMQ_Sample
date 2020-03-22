namespace RabbitServers
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Send = new System.Windows.Forms.Button();
            this.Rtx_SendContext = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_ServerUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_RouttingKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Rtx_Receive = new System.Windows.Forms.RichTextBox();
            this.Txt_Port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_UserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Txt_Exchange = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Txt_QueueName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Chk_IsEnableIni = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Btn_Send
            // 
            this.Btn_Send.Location = new System.Drawing.Point(796, 17);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(88, 23);
            this.Btn_Send.TabIndex = 0;
            this.Btn_Send.Text = "Send";
            this.Btn_Send.UseVisualStyleBackColor = true;
            // 
            // Rtx_SendContext
            // 
            this.Rtx_SendContext.Location = new System.Drawing.Point(66, 75);
            this.Rtx_SendContext.Name = "Rtx_SendContext";
            this.Rtx_SendContext.Size = new System.Drawing.Size(894, 337);
            this.Rtx_SendContext.TabIndex = 1;
            this.Rtx_SendContext.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "服务器地址";
            // 
            // Txt_ServerUrl
            // 
            this.Txt_ServerUrl.Location = new System.Drawing.Point(86, 19);
            this.Txt_ServerUrl.Name = "Txt_ServerUrl";
            this.Txt_ServerUrl.Size = new System.Drawing.Size(184, 21);
            this.Txt_ServerUrl.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "RoutingKey";
            // 
            // Txt_RouttingKey
            // 
            this.Txt_RouttingKey.Location = new System.Drawing.Point(521, 46);
            this.Txt_RouttingKey.Name = "Txt_RouttingKey";
            this.Txt_RouttingKey.Size = new System.Drawing.Size(104, 21);
            this.Txt_RouttingKey.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "发送内容";
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(903, 17);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(87, 23);
            this.Btn_Clear.TabIndex = 7;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 432);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "发送结果";
            // 
            // Rtx_Receive
            // 
            this.Rtx_Receive.Location = new System.Drawing.Point(66, 429);
            this.Rtx_Receive.Name = "Rtx_Receive";
            this.Rtx_Receive.Size = new System.Drawing.Size(894, 144);
            this.Rtx_Receive.TabIndex = 9;
            this.Rtx_Receive.Text = "";
            // 
            // Txt_Port
            // 
            this.Txt_Port.Location = new System.Drawing.Point(326, 19);
            this.Txt_Port.Name = "Txt_Port";
            this.Txt_Port.Size = new System.Drawing.Size(59, 21);
            this.Txt_Port.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "端口号";
            // 
            // Txt_UserName
            // 
            this.Txt_UserName.Location = new System.Drawing.Point(448, 19);
            this.Txt_UserName.Name = "Txt_UserName";
            this.Txt_UserName.Size = new System.Drawing.Size(126, 21);
            this.Txt_UserName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "用户名";
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(615, 19);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.Size = new System.Drawing.Size(148, 21);
            this.Txt_Password.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(580, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "密码";
            // 
            // Txt_Exchange
            // 
            this.Txt_Exchange.Location = new System.Drawing.Point(325, 48);
            this.Txt_Exchange.Name = "Txt_Exchange";
            this.Txt_Exchange.Size = new System.Drawing.Size(117, 21);
            this.Txt_Exchange.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "交换器";
            // 
            // Txt_QueueName
            // 
            this.Txt_QueueName.Location = new System.Drawing.Point(86, 46);
            this.Txt_QueueName.Name = "Txt_QueueName";
            this.Txt_QueueName.Size = new System.Drawing.Size(184, 21);
            this.Txt_QueueName.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "队列名称";
            // 
            // Chk_IsEnableIni
            // 
            this.Chk_IsEnableIni.AutoSize = true;
            this.Chk_IsEnableIni.Location = new System.Drawing.Point(643, 51);
            this.Chk_IsEnableIni.Name = "Chk_IsEnableIni";
            this.Chk_IsEnableIni.Size = new System.Drawing.Size(120, 16);
            this.Chk_IsEnableIni.TabIndex = 20;
            this.Chk_IsEnableIni.Text = "使用配置文件参数";
            this.Chk_IsEnableIni.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 622);
            this.Controls.Add(this.Chk_IsEnableIni);
            this.Controls.Add(this.Txt_QueueName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Txt_Exchange);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Txt_UserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Txt_Port);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Rtx_Receive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_RouttingKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_ServerUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rtx_SendContext);
            this.Controls.Add(this.Btn_Send);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RabbitMQ消息发布";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Send;
        private System.Windows.Forms.RichTextBox Rtx_SendContext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_ServerUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_RouttingKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox Rtx_Receive;
        private System.Windows.Forms.TextBox Txt_Port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txt_UserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Txt_Exchange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txt_QueueName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox Chk_IsEnableIni;
    }
}

