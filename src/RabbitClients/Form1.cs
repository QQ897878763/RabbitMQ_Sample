using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitClients
{
    public partial class Form1 : Form
    {
        private RabbitMQConnectionDTO _connectionDTO;
        private IModel _channel;
        public Form1()
        {
            InitializeComponent();
            Btn_Begin.Click += Btn_Begin_Click;
            Btn_Clear.Click += Btn_Clear_Click;
            Btn_Stop.Click += Btn_Stop_Click;
            FormClosed += Form1_FormClosed;
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            _channel.Abort();
            Btn_Begin.Enabled = true;
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Rtx_SendContext.Clear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {            
            System.Environment.Exit(0);
        }

        private void Btn_Begin_Click(object sender, EventArgs e)
        {
            Rtx_SendContext.Text = $"开始监听MQ!";
            Btn_Begin.Enabled = false;

            _connectionDTO = new RabbitMQConnectionDTO();
            string exchangeName, queueName, routtingKeyName;
            string iniPath = Path.Combine(Application.StartupPath, "AppSetting.ini");
            _connectionDTO.HostName = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Connection", "HostName", "");
            _connectionDTO.Password = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Connection", "Password", "");
            _connectionDTO.UserName = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Connection", "UserName", "");
            string portIniValue = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Connection", "Port", "");


            if (string.IsNullOrWhiteSpace(_connectionDTO.HostName))
            {
                MessageBox.Show($"AppSetting.ini配置文件--[RabbitMQ_Connection]section下的HostName节点为空!");
                return;
            }
            if (string.IsNullOrWhiteSpace(_connectionDTO.Password))
            {
                MessageBox.Show($"AppSetting.ini配置文件--[RabbitMQ_Connection]section下的Password节点为空!");
                return;
            }
            if (string.IsNullOrWhiteSpace(_connectionDTO.UserName))
            {
                MessageBox.Show($"AppSetting.ini配置文件--[RabbitMQ_Connection]section下的UserName节点为空!");
                return;
            }
            int port;
            if (!int.TryParse(portIniValue, out port))
            {
                MessageBox.Show($"AppSetting.ini配置文件--[RabbitMQ_Connection]section下的Port节点为空或格式有误!");
                return;
            }
            else
            {
                _connectionDTO.Port = port;
            }
            exchangeName = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Queue", "ExchangeName", "");
            queueName = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Queue", "QueueName", "");
            routtingKeyName = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Queue", "RoutingKeyName", "");
            if (string.IsNullOrWhiteSpace(exchangeName))
            {
                MessageBox.Show($"AppSetting.ini配置文件--[RabbitMQ_Queue]section下的ExchangeName节点为空!");
                return;
            }
            if (string.IsNullOrWhiteSpace(queueName))
            {
                MessageBox.Show($"AppSetting.ini配置文件--[RabbitMQ_Queue]section下的QueueName节点为空!");
                return;
            }
            if (string.IsNullOrWhiteSpace(routtingKeyName))
            {
                MessageBox.Show($"AppSetting.ini配置文件--[RabbitMQ_Queue]section下的RoutingKeyName节点为空!");
                return;
            }
            ReceiveMessage(_connectionDTO, exchangeName, queueName, routtingKeyName);
        }

        private void ReceiveMessage(RabbitMQConnectionDTO connectionDTO, string exchangeName, string queueName, string routtingKey)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = connectionDTO.HostName,
                    Password = connectionDTO.Password,
                    UserName = connectionDTO.UserName,
                    Port = connectionDTO.Port,
                };

                UseDefaultBasicConsumerType(factory, queueName);
                //DirectAcceptExchangeEvent(factory, exchangeName, queueName, routtingKey);
            }
            catch (Exception ex)
            {
                Rtx_SendContext.Text = $"出现异常:{ex.Message}";
            }
        }

        private void UseDefaultBasicConsumerType(ConnectionFactory factory, string queueName)
        {
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            // accept only one unack-ed message at a time
            // uint prefetchSize, ushort prefetchCount, bool global
            _channel.BasicQos(0, 1, false);

            //定义一个继承了DefaultBasicConsumer类的消费类(DefaultBasicConsumer是继承了IBasicConsumer接口的一个基类,里面存在许多可重写的方法)
            MessageReceiver messageReceiver = new MessageReceiver(_channel, (string msg, ulong deliveryTag) =>
            {
                string key = Txt_Key.Text.Trim();
                string keyNoReturn = Txt_KeyNoReturn.Text.Trim();
                bool isExecFlag = false;
                if (!string.IsNullOrWhiteSpace(key) && msg.StartsWith(key)) // 这里要小心 如果只有当前1个消费者那你懂的~~~~~~
                    _channel.BasicReject(deliveryTag, requeue: true); //requeue表示消息被拒绝后是否重新放回queue中
                else if (!string.IsNullOrWhiteSpace(keyNoReturn) && msg.StartsWith(keyNoReturn))
                    _channel.BasicReject(deliveryTag, requeue: false); //requeue表示消息被拒绝后是否重新放回queue中
                else
                {
                    _channel.BasicAck(deliveryTag, multiple: false); //确认已处理消息 multiple表示是否确认多条
                    isExecFlag = true;
                }
                BeginInvoke(new Action(() => { Rtx_SendContext.Text = Rtx_SendContext.Text + "\r" + $"处理标识{isExecFlag.ToString()} " + string.Format("***接收时间:{0}，消息内容：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg); }));
            });
            _channel.BasicConsume(queueName, false, messageReceiver); //不开启自动确认回执
        }



        private void DirectAcceptExchangeEvent(ConnectionFactory rabbitMqFactory, string exchangeName, string queueName, string routtingKey)
        {
            IConnection conn = rabbitMqFactory.CreateConnection();
            _channel = conn.CreateModel();

            //channel.ExchangeDeclare(ExchangeName, "direct", durable: true, autoDelete: false, arguments: null);
            _channel.QueueDeclare(queueName, durable: false, autoDelete: false, exclusive: false, arguments: null);
            _channel.QueueBind(queueName, exchangeName, routingKey: routtingKey);
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {

                var msgBody = Encoding.UTF8.GetString(ea.Body);
                BeginInvoke(new Action(() => { Rtx_SendContext.Text = "\r" + string.Format("***接收时间:{0}，消息内容：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msgBody); }));
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            // 回复
            string tag = _channel.BasicConsume(queueName, autoAck: false, consumer: consumer);

            //已过时用EventingBasicConsumer代替
            //var consumer2 = new QueueingBasicConsumer(channel);
            //channel.BasicConsume(QueueName, noAck: true, consumer: consumer);
            //var msgResponse = consumer2.Queue.Dequeue(); //blocking
            //var msgBody2 = Encoding.UTF8.GetString(msgResponse.Body);
        }

        private void LoopGetMessage(ConnectionFactory factory, string exchangeName, string queueName, string routtingKey)
        {
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(exchangeName, EnumRabbitExchangeType.topic.ToString(), durable: true, autoDelete: false, arguments: null);
            _channel.QueueDeclare(queueName, durable: true, autoDelete: false, exclusive: false, arguments: null);
            _channel.QueueBind(queueName, exchangeName, routingKey: routtingKey);
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    BasicGetResult msgResponse = _channel.BasicGet(queueName, autoAck: true);
                    if (msgResponse != null)
                    {
                        var msgBody = Encoding.UTF8.GetString(msgResponse.Body);
                        BeginInvoke(new Action(() => { Rtx_SendContext.Text = "\r" + string.Format("***接收时间:{0}，消息内容：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msgBody); }));
                    }

                    //BasicGetResult msgResponse2 = channel.BasicGet(QueueName, noAck: false);

                    ////process message ...

                    //channel.BasicAck(msgResponse2.DeliveryTag, multiple: false);
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDlx frm = new FrmDlx();
            frm.ShowDialog();
        }
    }


    /// <summary>
    /// RabbitMQ交换机类型枚举
    /// </summary>
    public enum EnumRabbitExchangeType : int
    {
        /// <summary>
        /// 直连交换机
        /// </summary>
        direct = 1,
        /// <summary>
        /// 主题路由匹配交换机
        /// </summary> 
        topic = 2,
        /// <summary>
        /// 无路由交换机
        /// </summary>
        fanout = 3
    }

    public class RabbitMQConnectionDTO
    {
        /// <summary>
        /// RabbitMQ服务器地址
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
