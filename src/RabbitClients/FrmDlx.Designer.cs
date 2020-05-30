namespace RabbitClients
{
    partial class FrmDlx
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Rtx_SendContext = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextl_Dlx = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Rtx_SendContext
            // 
            this.Rtx_SendContext.Location = new System.Drawing.Point(83, 93);
            this.Rtx_SendContext.Name = "Rtx_SendContext";
            this.Rtx_SendContext.Size = new System.Drawing.Size(471, 304);
            this.Rtx_SendContext.TabIndex = 3;
            this.Rtx_SendContext.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(763, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "开始监听非死信路由";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "非死信路由";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(571, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "死信路由";
            // 
            // richTextl_Dlx
            // 
            this.richTextl_Dlx.Location = new System.Drawing.Point(630, 93);
            this.richTextl_Dlx.Name = "richTextl_Dlx";
            this.richTextl_Dlx.Size = new System.Drawing.Size(471, 304);
            this.richTextl_Dlx.TabIndex = 7;
            this.richTextl_Dlx.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(929, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 43);
            this.button2.TabIndex = 8;
            this.button2.Text = "监听死信路由";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmDlx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 540);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextl_Dlx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Rtx_SendContext);
            this.Name = "FrmDlx";
            this.Text = "死信队列测试";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Rtx_SendContext;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextl_Dlx;
        private System.Windows.Forms.Button button2;
    }
}