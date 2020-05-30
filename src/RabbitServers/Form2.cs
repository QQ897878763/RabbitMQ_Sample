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

namespace RabbitServers
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = Rtx_SendContext.Text;
            try
            {
                ConnectionFactory rabbitMqFactory = new ConnectionFactory()
                {
                    HostName = "127.0.0.1",
                    UserName = "admin",
                    Password = "123456",
                    Port = 5672
                };

                //这三个都为正常的队列、交换器、路由key
                string queueName = "dlx_bus_queue";
                string exchangeName = "dlx_bus_exchange";
                string routingKey = "dlx_bus_routing";

                // 这三个都为死信队列、死信队列交换器、死信队列路由key
                string queueNameDlx = "dlx_queue";
                string exchangeNameDlx = "dlx_exchange";
                string routingKeyDlx = "#";

                /*思路:
                 1、定义死信队列、交换器
                 2、定义正常队列
                 */

                using (IConnection conn = rabbitMqFactory.CreateConnection())
                {
                    using (IModel channel = conn.CreateModel())
                    {
                        // 交换器定义
                        channel.ExchangeDeclare(exchangeName, "topic", durable: true, autoDelete: false, arguments: null);
                        // 设置队列的死信队列交换器为dlx_exchange(可以理解为该队列的消息过期则通过dlx_exchange交换器再进行分发)
                        Dictionary<string, object> arguments = new Dictionary<string, object>();
                        arguments.Add("x-dead-letter-exchange", exchangeNameDlx);
                        channel.QueueDeclare(queueName, durable: true, autoDelete: false, exclusive: false, arguments: arguments);
                        // 必须执行QueueBind 需要将routingKey与队列和交换机进行绑定 否则就算事务提交了队列也不会有数据~
                        channel.QueueBind(queueName, exchangeName, routingKey);
                        byte[] messagebuffer = Encoding.UTF8.GetBytes(message);
                        channel.ConfirmSelect(); // 启用服务器确认机制方式

                        // 创建死信交换器
                        channel.ExchangeDeclare(exchangeNameDlx, "topic", true, false, null);
                        channel.QueueDeclare(queueNameDlx, true, false, false, null);
                        channel.QueueBind(queueNameDlx, exchangeNameDlx, routingKeyDlx);

                        IBasicProperties props = channel.CreateBasicProperties();
                        props.ContentEncoding = "UTF-8";
                        props.Expiration = "3000";
                        channel.BasicPublish(exchangeName, routingKey, props, messagebuffer);
                        if (channel.WaitForConfirms())
                        {
                            richTextBox1.Text = richTextBox1.Text + $"\r 消息发送成功！ 发送时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送消息失败!{ex.Message}");
            }
        }
    }
}
