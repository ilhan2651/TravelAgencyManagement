using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Infrastructure.Configuration;

namespace Tam.Infrastructure.Messaging;

public class RabbitMqPublisher : IRabbitMqPublisher
{
    private readonly RabbitMqSettings _settings;
    private readonly ConnectionFactory _factory;

    public RabbitMqPublisher(IOptions<RabbitMqSettings> options)
    {
        _settings = options.Value;
        _factory = new ConnectionFactory
        {
            HostName = _settings.Host,
            Port = _settings.Port,
            UserName = _settings.Username,
            Password = _settings.Password
        };
    }

    public async Task PublishAsync<T>(string queueName, T message)
    {
        using var connection = await _factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);
        Console.WriteLine($"[Publisher] Mesaj kuyruğa gönderiliyor: {json}");


        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: queueName,
            body: body
        );
        Console.WriteLine($"[Publisher] Mesaj başarıyla gönderildi.");

    }
}
