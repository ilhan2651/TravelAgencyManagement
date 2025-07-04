using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Services;
using Tam.Application.Messages;
using Tam.Infrastructure.Services;

namespace Tam.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestMailController : ControllerBase
    {
        private readonly IRabbitMqPublisher _publisher;

        public TestMailController(IRabbitMqPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpPost]
        public async Task<IActionResult> SendTestEmail()
        {
            var message = new SendEmailMessage
            {
                To = "ilhanrandakk@gmail.com",
                Subject = "Test Mail",
                Body = "RabbitMQ üzerinden gelen test mailidir."
            };

            await _publisher.PublishAsync("email_queue", message);
            return Ok("Mail kuyruğa gönderildi.");
        }
    }

}
