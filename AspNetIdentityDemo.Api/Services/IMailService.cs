using SendGrid;
using SendGrid.Helpers.Mail;

namespace AspNetIdentityDemo.Api.Services{
    public interface IMailService{
        Task SendMailAsync(string toEmail, string subject, string content);
    }

    public class SendGridMailService : IMailService
    {
        private IConfiguration _configuration;
        public SendGridMailService(IConfiguration configuration){
            _configuration = configuration;
        }
        public async Task SendMailAsync(string toEmail, string subject, string content)
        {
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@authdemo.com", "JWT Auth Demo");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}