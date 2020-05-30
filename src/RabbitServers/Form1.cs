using RabbitMQ.Client;
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

namespace RabbitServers
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Btn_Send.Click += Btn_Send_Click;
            Btn_Clear.Click += Btn_Clear_Click;
        }



        private bool Verification()
        {

            if (string.IsNullOrWhiteSpace(Txt_ServerUrl.Text.Trim())) return false;
            if (string.IsNullOrWhiteSpace(Txt_UserName.Text.Trim())) return false;
            if (string.IsNullOrWhiteSpace(Txt_Password.Text.Trim())) return false;
            if (string.IsNullOrWhiteSpace(Txt_Exchange.Text.Trim())) return false;
            if (string.IsNullOrWhiteSpace(Txt_Port.Text.Trim())) return false;
            if (string.IsNullOrWhiteSpace(Txt_RouttingKey.Text.Trim())) return false;
            if (string.IsNullOrWhiteSpace(Txt_QueueName.Text.Trim())) return false;
            if (string.IsNullOrWhiteSpace(Rtx_SendContext.Text.Trim())) return false;
            if (!int.TryParse(Txt_Port.Text.Trim(), out _)) return false;

            return true;
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                RabbitMQConnectionDTO connectionDTO = new RabbitMQConnectionDTO();
                string exchangeName, queueName, routtingKeyName;
                if (!Chk_IsEnableIni.Checked)
                {
                    if (!Verification())
                    {
                        MessageBox.Show($"请输入必要的值!");
                        return;
                    }
                    connectionDTO.HostName = Txt_ServerUrl.Text.Trim();
                    connectionDTO.Password = Txt_Password.Text.Trim();
                    connectionDTO.Port = int.Parse(Txt_Port.Text.Trim());
                    connectionDTO.UserName = Txt_UserName.Text.Trim();
                    exchangeName = Txt_Exchange.Text.Trim();
                    queueName = Txt_QueueName.Text.Trim();
                    routtingKeyName = Txt_RouttingKey.Text.Trim();
                }
                else
                {
                    string iniPath = Path.Combine(Application.StartupPath, "AppSetting.ini");
                    connectionDTO.HostName = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Connection", "HostName", "");
                    connectionDTO.Password = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Connection", "Password", "");
                    connectionDTO.UserName = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Connection", "UserName", "");
                    string portIniValue = IniHelper.INIGetStringValue(iniPath, "RabbitMQ_Connection", "Port", "");
                    if (string.IsNullOrWhiteSpace(Rtx_SendContext.Text.Trim()))
                    {
                        MessageBox.Show($"需要传输的内容为空!");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(connectionDTO.HostName))
                    {
                        MessageBox.Show($"AppSetting.ini配置文件--[RabbitMQ_Connection]section下的HostName节点为空!");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(connectionDTO.Password))
                    {
                        MessageBox.Show($"AppSetting.ini配置文件--[RabbitMQ_Connection]section下的Password节点为空!");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(connectionDTO.UserName))
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
                        connectionDTO.Port = port;
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
                }

                //// 使用 不安全方式发布消息(无法保证消息到达了队列里！)
                //SendMessage(connectionDTO, exchangeName, queueName, routtingKeyName, EnumRabbitExchangeType.topic, Rtx_SendContext.Text);
                ////采取AMQP事务方式保证消息到达队列
                //SendMessageByTransaction(connectionDTO, exchangeName, queueName, routtingKeyName, EnumRabbitExchangeType.topic, Rtx_SendContext.Text);

                // 采取ACK确认机制发送消息
                SendMessageByAck(connectionDTO, exchangeName, queueName, routtingKeyName, EnumRabbitExchangeType.topic, Rtx_SendContext.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Rtx_Receive.Clear();
            Rtx_SendContext.Clear();
        }



        // 采取确认机制方式传输消息
        private void SendMessageByAck(RabbitMQConnectionDTO mqConnection, string exchangeName, string queueName,
         string routingKey, EnumRabbitExchangeType exchangeType, string message)
        {
            try
            {
                ConnectionFactory rabbitMqFactory = new ConnectionFactory()
                {
                    HostName = mqConnection.HostName,
                    UserName = mqConnection.UserName,
                    Password = mqConnection.Password,
                    Port = mqConnection.Port
                };
                using (IConnection conn = rabbitMqFactory.CreateConnection())
                {
                    using (IModel channel = conn.CreateModel())
                    {
                        channel.ExchangeDeclare(exchangeName, exchangeType.ToString(), durable: false, autoDelete: false, arguments: null);
                        channel.QueueDeclare(queueName, durable: false, autoDelete: false, exclusive: false, arguments: null);
                        // 必须执行QueueBind 需要将routingKey与队列和交换机进行绑定 否则就算事务提交了队列也不会有数据~
                        channel.QueueBind(queueName, exchangeName, routingKey);
                        byte[] messagebuffer = Encoding.UTF8.GetBytes(message);
                        channel.ConfirmSelect(); // 启用服务器确认机制方式
                       
                        channel.BasicPublish(exchangeName, routingKey, null, messagebuffer);
                        if (channel.WaitForConfirms())
                        {
                            Rtx_Receive.Text = Rtx_Receive.Text + $"\r 消息发送成功！ 发送时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送消息失败!{ex.Message}");
            }
        }

        // 采取RabbitMQ事务方式传输消息
        private void SendMessageByTransaction(RabbitMQConnectionDTO mqConnection, string exchangeName, string queueName,
         string routingKey, EnumRabbitExchangeType exchangeType, string message)
        {
            try
            {
                ConnectionFactory rabbitMqFactory = new ConnectionFactory()
                {
                    HostName = mqConnection.HostName,
                    UserName = mqConnection.UserName,
                    Password = mqConnection.Password,
                    Port = mqConnection.Port
                };
                using (IConnection conn = rabbitMqFactory.CreateConnection())
                {
                    using (IModel channel = conn.CreateModel())
                    {
                        channel.ExchangeDeclare(exchangeName, exchangeType.ToString(), durable: true, autoDelete: false, arguments: null);
                        channel.QueueDeclare(queueName, durable: false, autoDelete: false, exclusive: false, arguments: null);
                        // 必须执行QueueBind 需要将routingKey与队列和交换机进行绑定 否则就算事务提交了队列也不会有数据~
                        channel.QueueBind(queueName, exchangeName, routingKey);
                        byte[] messagebuffer = Encoding.UTF8.GetBytes(message);
                        try
                        {
                            channel.TxSelect();
                            channel.BasicPublish(exchangeName, routingKey, null, messagebuffer);
                            //if (1 == 1) throw new Exception("没错！我是故意抛出异常的！看看最终队列是否写入了消息~");
                            channel.TxCommit();
                        }
                        catch (Exception ex)
                        {
                            Rtx_Receive.Text = Rtx_Receive.Text + $"\r 异常产生时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},异常信息:{ex.Message}";
                            channel.TxRollback();
                            // TODO 进行补发OR其他逻辑处理
                        }
                        Rtx_Receive.Text = Rtx_Receive.Text + $"\r 发送时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送消息失败!{ex.Message}");
            }
        }

        // 默认发送消息，不知道消息是否正确到达Broker代理服务器
        private void SendMessage(RabbitMQConnectionDTO mqConnection, string exchangeName, string queueName,
            string routingKey, EnumRabbitExchangeType exchangeType, string message)
        {
            try
            {
                ConnectionFactory rabbitMqFactory = new ConnectionFactory()
                {
                    HostName = mqConnection.HostName,
                    UserName = mqConnection.UserName,
                    Password = mqConnection.Password,
                    Port = mqConnection.Port
                };
                using (IConnection conn = rabbitMqFactory.CreateConnection())
                {
                    using (IModel channel = conn.CreateModel())
                    {
                        //channel.ExchangeDeclare(exchangeName, exchangeType.ToString(), durable: true, autoDelete: false, arguments: null);
                        //channel.QueueDeclare(queueName, durable: false, autoDelete: false, exclusive: false, arguments: null);
                        // 必须执行QueueBind 需要将routingKey与队列和交换机进行绑定
                        channel.QueueBind(queueName, exchangeName, routingKey);
                        var properties = channel.CreateBasicProperties();
                        properties.Persistent = false; // 设置消息持久化属性为true
               
                        byte[] messagebuffer = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(exchangeName, routingKey, properties, messagebuffer);
                        Rtx_Receive.Text = Rtx_Receive.Text + $"\r 发送时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送消息失败!{ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
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
        fanout = 3,

        Headers = 4
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
