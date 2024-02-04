using Domain.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.EmailService
{
    public class SendEmailService
    {
        private readonly IConfiguration _configuration;

        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response> SendEmail()
        {
            var apiKey = "";

            var templateId = "d-48d99dea44d446579b58edd39b2da56e";

            var apiKey1 = _configuration.GetConnectionString(apiKey);

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("tumskruven@gmail.com");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("tobiiasa@hotmail.com");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var randomstring = "";

            Email emailObject = new Email();

            emailObject.Subject = "Haj hajen";

            emailObject.Body = "Detta är body";



            var test = MailHelper.CreateSingleTemplateEmail(from, to, templateId, emailObject);

            var response = await client.SendEmailAsync(test);

            return await Task.FromResult(response);
        }
    }
}
