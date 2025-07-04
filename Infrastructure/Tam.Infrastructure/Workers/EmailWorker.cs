using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text.Json;
using Tam.Infrastructure.Configuration;
using Tam.Application.Messages;
using Tam.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.Text;
using Tam.Application.Interfaces.Services;

namespace Tam.Infrastructure.Workers
{
    public class EmailWorker : BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly string _queueName = "email_queue";
        private readonly IServiceProvider _serviceProvider;

        public EmailWorker(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            Console.WriteLine("[Worker] Constructor çalıştı.");  // ⬅ Deneme satırı

            var settings = configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>();
            _factory = new ConnectionFactory
            {
                HostName = settings.Host,
                Port = settings.Port,
                UserName = settings.Username,
                Password = settings.Password
            };

            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("[Worker] ExecuteAsync başladı...");

            var connection = await _factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            Console.WriteLine("[Worker] Bağlantı ve kanal açıldı...");

            await channel.QueueDeclareAsync(
                queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );
            Console.WriteLine("[Worker] Kuyruk deklarasyonu yapıldı.");

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                Console.WriteLine("[Worker] Mesaj alındı kuyuktan");

                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[Worker] JSON içeriği: {json}");

                try
                {
                    
                    var email = JsonSerializer.Deserialize<SendEmailMessage>(json);

                    // Scoped servisleri bu şekilde kullan
                    using var scope = _serviceProvider.CreateScope();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                    if (email != null)
                    {
                        await emailService.SendEmailAsync(email.To, email.Subject, email.Body);
                        Console.WriteLine($" Email gönderildi: {email.To}");
                    }

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                    Console.WriteLine("[Worker] Mesaj işleme tamamlandı ve ACK gönderildi.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Email gönderimi başarısız: {ex.Message}");
                }
            };

            await channel.BasicConsumeAsync(
                queue: _queueName,
                autoAck: false,
                consumer: consumer
            );
        }
    }

}
