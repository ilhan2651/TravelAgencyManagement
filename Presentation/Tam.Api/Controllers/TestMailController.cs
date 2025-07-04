using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tam.Application.Interfaces.Services;
using Tam.Infrastructure.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestMailController(IEmailService emailService) : ControllerBase
    {
        [HttpGet("test")]
        public async Task<IActionResult> SendTestEmail()
        {
            await emailService.SendEmailAsync(
                to: "ilhanrandakk@gmail.com",
                subject: "SmartAgent360 Test Maili",
                body: "<h2>Bu bir testtir</h2><p>Mail servisi çalışıyor 🔥</p>"
            );

            return Ok("Mail gönderildi");
        }
    }
}
