using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.EmailService
{
    public class SendEmailService
    {
        public async Task<Response> SendEmail()
        {
            var apiKey = "HÄR SKA VARA EN API NYCKEL :)";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("HÄR SKA VARA EN VERIFIERAD EPOST ADRESS", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return await Task.FromResult(response);
        }
    }
}
