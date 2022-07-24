using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;

namespace SmartLiving.DeviceMVC.BusinessLogics.Services
{
    public class MessageService : IHostedService, IDisposable
    {
        private readonly ILogger<MessageService> _logger;
        private Timer _timer;
        private int executionCount = 0;
        private readonly IConnection _connection;
        private readonly IServiceProvider _serviceProvider;

        public MessageService(ILogger<MessageService> logger,IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            var factory = new ConnectionFactory()
            {
                HostName = "armadillo-01.rmq.cloudamqp.com",
                UserName = "spjjqgjt",
                Password = "vbghNiAdd41JNz3a4TbdrPlmeExrpT1y",
                VirtualHost = "spjjqgjt",
                DispatchConsumersAsync = false,
            };
            _connection = factory.CreateConnection();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;

        }

        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "MessageListener is working. Count: {Count}", count);

            // using (var connection = factory.CreateConnection())
            // using (var channel = connection.CreateModel())
            // {
            var channel = _connection.CreateModel();

            channel.QueueDeclare("SeverDevice", exclusive: false, durable: true, autoDelete: false);
            channel.QueueBind(queue: "SeverDevice", exchange: "SmartLiving", routingKey: "ServerMsgEvent");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                _logger.LogInformation($"consume {message}");
                HandleMessage(message);
            };
            channel.BasicConsume(queue: "SeverDevice", autoAck: false, consumer: consumer);
            // }
        }

        private void HandleMessage(string content)
        {
            using var scope = _serviceProvider.CreateScope();
            var deviceRepository = scope.ServiceProvider.GetService<IDeviceRepository>();

            var value = JObject.Parse(content);
            var title = value["Title"];
            var msg = value["Msg"];

            if (title != null && title.ToString() == "switch")
            {
                Console.WriteLine("Switching");
                deviceRepository.Switch(Convert.ToInt32(msg));
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("MessageListener is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Close _connection
            _timer?.Dispose();
        }
    }
}
