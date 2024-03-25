
using SendGrid.Helpers.Mail;
using SendGrid;

namespace Hangfire.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {

            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("from@example.com", "Example User");
            var subject = "www.mysite.com Bilgilendirme";
            var to = new EmailAddress("to@example.com", "Example User");


            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
