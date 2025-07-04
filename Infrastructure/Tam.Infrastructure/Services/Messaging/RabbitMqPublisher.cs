using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using Tam.Application.Messages;
using Tam.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace Tam.Infrastructure.Messaging
{
    public class RabbitMqPublisher
    {
        private readonly RabbitMqSettings _settings;

        public RabbitMqPublisher(IOptions<RabbitMqSettings> options)
        {
            _settings = options.Value;
        }

        public async Task PublishAsync(SendEmailMessage message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _settings.Host,
                Port = _settings.Port,
                UserName = _settings.Username,
                Password = _settings.Password
            };

            RabbitMQ.Client.IConnection connection = await factory.CreateConnectionAsync("EmailPublisher");
            using var channel = connection.CreateModel(); // ❗ Artık hata vermeyecek

            // ✨ Queue tanımı
            channel.QueueDeclare(
                queue: _settings.EmailQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            // ✉️ Mesajı JSON olarak dönüştür ve byte'a çevir
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            // 🚀 Mesajı gönder
            channel.BasicPublish(
                exchange: "",
                routingKey: _settings.EmailQueue,
                basicProperties: null,
                body: body
            );
        }
    }
}

