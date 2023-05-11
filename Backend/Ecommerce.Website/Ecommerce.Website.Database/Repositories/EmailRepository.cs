using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _config;
        public EmailRepository(EcommerceContext context, IConfiguration config) 
        {
            _config = config;

        }
        public Task SendEmailAsync(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailConfiguration:From").Value));
            email.To.Add(MailboxAddress.Parse(request.Receiver));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Body,
            };
            //Thiết lập SMTP client để gửi mails (pure.net)
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailConfiguration:SmtpServer").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailConfiguration:Username").Value, _config.GetSection("EmailConfiguration:Password").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

            return null;


        }
    }

}
