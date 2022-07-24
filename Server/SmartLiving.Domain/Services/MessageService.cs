using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace SmartLiving.Domain.Services
{
    public interface IMessageService
    {
        void SendMessage<T> (T message);
    }

    public class MessageService : IMessageService
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "armadillo-01.rmq.cloudamqp.com",
                UserName = "spjjqgjt",
                Password = "vbghNiAdd41JNz3a4TbdrPlmeExrpT1y",
                VirtualHost = "spjjqgjt",
                DispatchConsumersAsync = true,
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("SeverDevice", exclusive:false, durable: true, autoDelete: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "SmartLiving", routingKey: "ServerMsgEvent", body: body);
        }
    }
}
