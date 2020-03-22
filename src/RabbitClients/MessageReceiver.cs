using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace RabbitClients
{
    public class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        private readonly Logger _logger;
        private readonly Action<string, ulong> _action;
        public MessageReceiver(IModel channel, Action<string, ulong> action)
        {
            _action = action;
            _channel = channel;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            string msg = Encoding.UTF8.GetString(body);
            _logger.Debug($"***************************Consuming Topic Message  时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}*********************************");
            _logger.Debug(string.Concat("Message received from the exchange ", exchange));
            _logger.Debug(string.Concat("Consumer tag: ", consumerTag));
            _logger.Debug(string.Concat("Delivery tag: ", deliveryTag));
            _logger.Debug(string.Concat("Routing tag: ", routingKey));
            _logger.Debug(string.Concat("Message: ", msg));
            _action?.Invoke(msg, deliveryTag);
        }

        /// <summary>
        /// 捕获通道连接的关闭事件
        /// </summary>
        /// <param name="model"></param>
        /// <param name="reason"></param>
        public override void HandleModelShutdown(object model, ShutdownEventArgs reason)
        {
            _logger.Debug($"进入MessageReceiver.HandleModelShutdown方法");
            base.HandleModelShutdown(model, reason);
        }

        public override void HandleBasicConsumeOk(string consumerTag)
        {
            _logger.Debug($"进入MessageReceiver.HandleBasicConsumeOk方法 consumerTag:{consumerTag}");
            base.HandleBasicConsumeOk(consumerTag);
        }

        /// <summary>
        ///  删除队列 会进入
        /// </summary>
        /// <param name="consumerTag"></param>
        public override void HandleBasicCancel(string consumerTag)
        {
            _logger.Debug($"进入MessageReceiver.HandleBasicCancel方法 consumerTag:{consumerTag}");
            base.HandleBasicCancel(consumerTag);
        }
    }
}
