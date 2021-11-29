using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Usuarios.Application.Sengrid
{
    public interface IMailService
    {
        Task sendEmailAsync(string toEmail);
    }

    public class SendGridEmailService : IMailService
    {
        private IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        string keyTemplate = "d-b7a51b57888045fb9ac647059fd75d08";

        public async Task sendEmailAsync(string toEmail)
        {
            string key =  Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var sendGridClient = new SendGridClient(key);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("welcome.ong@hotmail.com", "Borboteca");
            sendGridMessage.AddTo(toEmail);
            
            sendGridMessage.SetTemplateId(keyTemplate);
            
            sendGridMessage.SetTemplateData(new
            {
                name = "Borbotca",
                url = "https://dotnetthoughts.net"
            });

            var response = await sendGridClient.SendEmailAsync(sendGridMessage);

        }
    }
}
