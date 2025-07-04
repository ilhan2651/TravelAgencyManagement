using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Newtonsoft.Json;
using Tam.Infrastructure.Configuration;
using Tam.Application.Messages;
using Tam.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tam.Infrastructure.Workers
{
    public class EmailWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly RabbitMqSettings _settings;
        private IConnection? _connection;
        private IModel? _channel;

        public EmailWorker(IServiceProvider serviceProvider, IOptions<RabbitMqSettings> options)
        {
            _serviceProvider = serviceProvider;
            _settings = options.Value;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = _settings.Host,
                Port = _settings.Port,
                UserName = _settings.Username,
                Password = _settings.Password
            };

            // *** SENKRON bağlantı ***
            _connection = factory.CreateConnection("RabbitMqPublisher");
            _channel = _connection.CreateModel();

            // Kuyruğu tanımla
            _channel.QueueDeclare(
                queue: _settings.EmailQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            // Consumer ayarla
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var json = Encoding.UTF8.GetString(body);
                    var message = JsonConvert.DeserializeObject<SendEmailMessage>(json);
                    if (message == null) return;

                    using var scope = _serviceProvider.CreateScope();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                    // Async metodu senkron olarak tetikliyoruz
                    emailService
                        .SendEmailAsync(message.To, message.Subject, message.Body)
                        .GetAwaiter()
                        .GetResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[EmailWorker ERROR]: {ex.Message}");
                }
            };

            _channel.BasicConsume(
                queue: _settings.EmailQueue,
                autoAck: true,
                consumer: consumer);

            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // İş zaten StartAsync'te başlıyor, burayı boş bırakabilirsin
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _channel?.Close();
            _connection?.Close();
            return base.StopAsync(cancellationToken);
        }
    }
}
