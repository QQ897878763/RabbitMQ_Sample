using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitClients
{
    public partial class FrmDlx : Form
    {
        private IModel _channel;
        public FrmDlx()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UseDefaultBasicConsumerType();
        }

        private void UseDefaultBasicConsumerType()
        {

            var factory = new ConnectionFactory
            {
                HostName = "127.0.0.1",
                UserName = "admin",
                Password = "123456",
                Port = 5672,
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            //这三个都为正常的队列、交换器、路由key
            string queueName = "dlx_bus_queue";
         
            MessageReceiver messageReceiver = new MessageReceiver(_channel, (string msg, ulong deliveryTag) =>
              {
                  bool isExecFlag = false;
                  _channel.BasicAck(deliveryTag, multiple: false); //确认已处理消息 multiple表示是否确认多条
                  isExecFlag = true;

                  BeginInvoke(new Action(() => { Rtx_SendContext.Text = Rtx_SendContext.Text + "\r" + $"处理标识{isExecFlag.ToString()} " + string.Format("***接收时间:{0}，消息内容：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg); }));
              });
            _channel.BasicConsume(queueName, false, messageReceiver); //不开启自动确认回执

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory
            {
                HostName = "127.0.0.1",
                UserName = "admin",
                Password = "123456",
                Port = 5672,
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            string queueNameDlx = "dlx_queue";
            MessageReceiver messageDlxReceiver = new MessageReceiver(_channel, (string msg, ulong deliveryTag) =>
            {
                bool isExecFlag = false;
                _channel.BasicAck(deliveryTag, multiple: false); //确认已处理消息 multiple表示是否确认多条
                isExecFlag = true;

                BeginInvoke(new Action(() => { richTextl_Dlx.Text = richTextl_Dlx.Text + "\r" + $"处理标识{isExecFlag.ToString()} " + string.Format("***接收时间:{0}，消息内容：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg); }));
            });
            _channel.BasicConsume(queueNameDlx, false, messageDlxReceiver); //不开启自动确认回执
        }
    }
}
