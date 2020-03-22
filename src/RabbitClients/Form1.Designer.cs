namespace RabbitClients
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
            this.Rtx_SendContext = new System.Windows.Forms.RichTextBox();
            this.Btn_Begin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Key = new System.Windows.Forms.TextBox();
            this.Txt_KeyNoReturn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Rtx_SendContext
            // 
            this.Rtx_SendContext.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Rtx_SendContext.Location = new System.Drawing.Point(0, 95);
            this.Rtx_SendContext.Name = "Rtx_SendContext";
            this.Rtx_SendContext.Size = new System.Drawing.Size(1066, 471);
            this.Rtx_SendContext.TabIndex = 2;
            this.Rtx_SendContext.Text = "";
            // 
            // Btn_Begin
            // 
            this.Btn_Begin.Location = new System.Drawing.Point(731, 57);
            this.Btn_Begin.Name = "Btn_Begin";
            this.Btn_Begin.Size = new System.Drawing.Size(75, 23);
            this.Btn_Begin.TabIndex = 3;
            this.Btn_Begin.Text = "开始消费";
            this.Btn_Begin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "不处理且返回队列的消息关键字";
            // 
            // Txt_Key
            // 
            this.Txt_Key.Location = new System.Drawing.Point(212, 27);
            this.Txt_Key.Name = "Txt_Key";
            this.Txt_Key.Size = new System.Drawing.Size(201, 21);
            this.Txt_Key.TabIndex = 5;
            // 
            // Txt_KeyNoReturn
            // 
            this.Txt_KeyNoReturn.Location = new System.Drawing.Point(623, 28);
            this.Txt_KeyNoReturn.Name = "Txt_KeyNoReturn";
            this.Txt_KeyNoReturn.Size = new System.Drawing.Size(201, 21);
            this.Txt_KeyNoReturn.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "不处理不返回队列的消息关键字";
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(926, 57);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.Btn_Clear.TabIndex = 8;
            this.Btn_Clear.Text = "清除消息";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Location = new System.Drawing.Point(831, 57);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.Btn_Stop.TabIndex = 9;
            this.Btn_Stop.Text = "停止消费";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 566);
            this.Controls.Add(this.Btn_Stop);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Txt_KeyNoReturn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Key);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Begin);
            this.Controls.Add(this.Rtx_SendContext);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RabbitMQ消息接收";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Rtx_SendContext;
        private System.Windows.Forms.Button Btn_Begin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Key;
        private System.Windows.Forms.TextBox Txt_KeyNoReturn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button Btn_Stop;
    }
}

