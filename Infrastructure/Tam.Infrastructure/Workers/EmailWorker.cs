using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using System.Text;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Services;
using Tam.Application.Messages;
using Tam.Application.Dtos.Email;
using Tam.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Tam.Application.Dtos.EmailDtos;

namespace Tam.Infrastructure.Workers
{
    public class EmailWorker : BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly IServiceProvider _serviceProvider;

        public EmailWorker(IConfiguration configuration, IServiceProvider serviceProvider)
        {
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
            var connection = await _factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            // 1️⃣ Genel e-posta kuyruğu: email_queue
            await channel.QueueDeclareAsync(
                queue: "email_queue",
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                try
                {
                    var email = JsonSerializer.Deserialize<SendEmailMessage>(json);

                    using var scope = _serviceProvider.CreateScope();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                    if (email != null)
                        await emailService.SendEmailAsync(email.To, email.Subject, email.Body);

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Worker] Genel e-posta gönderim hatası: {ex.Message}");
                }
            };

            await channel.BasicConsumeAsync("email_queue", autoAck: false, consumer);


            await channel.QueueDeclareAsync(
                queue: "reservation-email",
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            var reservationConsumer = new AsyncEventingBasicConsumer(channel);
            reservationConsumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                try
                {
                    var reservationMessage = JsonSerializer.Deserialize<HotelReservationEmailMessage>(json);

                    if (reservationMessage is not null)
                    {
                        using var scope = _serviceProvider.CreateScope();
                        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                        var subject = "Otel Rezervasyon Onayı";
                        var bodyText = $"Merhaba {reservationMessage.CustomerName},\n\n" +
                                       $"{reservationMessage.ReservationDate:dd.MM.yyyy} tarihinde {reservationMessage.HotelName} otelinde {reservationMessage.NumberOfPeople} kişi için check-in tarihi {reservationMessage.CheckIn} olan rezervasyonunuz oluşturuldu.\n" 
                                       ;

                        await emailService.SendEmailAsync(reservationMessage.CustomerEmail, subject, bodyText);
                        Console.WriteLine($"[Worker] Rezervasyon e-postası gönderildi → {reservationMessage.CustomerEmail}");
                    }

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Worker] Rezervasyon e-postası gönderim hatası: {ex.Message}");
                }
            };

            await channel.BasicConsumeAsync("reservation-email", autoAck: false, reservationConsumer);


            await channel.QueueDeclareAsync(
                queue: "transfer-reservation-email",
                durable: true,
                exclusive: false,
                autoDelete: false
            );
            var transferConsumer = new AsyncEventingBasicConsumer(channel);
            transferConsumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                try
                {
                    var transferMessage = JsonSerializer.Deserialize<TransferReservationEmailMessage>(json);

                    if (transferMessage is not null)
                    {
                        using var scope = _serviceProvider.CreateScope();
                        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                        var subject = "Transfer Rezervasyon Onayı";
                        var bodyText = $"Merhaba {transferMessage.CustomerName},\n\n" +
                                       $"{transferMessage.ReservationDate:dd.MM.yyyy} tarihinde {transferMessage.TransferName} transferi için {transferMessage.NumberOfPeople} kişi olarak rezervasyonunuz oluşturuldu.\n" +
                                       $"Alış noktası: {transferMessage.PickUpPoint}";

                        await emailService.SendEmailAsync(transferMessage.CustomerEmail, subject, bodyText);
                        Console.WriteLine($"[Worker] Transfer rezervasyon e-postası gönderildi → {transferMessage.CustomerEmail}");
                    }

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Worker] Transfer rezervasyon e-postası gönderim hatası: {ex.Message}");
                }
            };
        }
    }
}
