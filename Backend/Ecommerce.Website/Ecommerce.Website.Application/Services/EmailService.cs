using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Models;

namespace Ecommerce.Website.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository) 
        {
            _emailRepository = emailRepository;
        }

        public Task SendEmailAsync(EmailDto request)
        {
            return _emailRepository.SendEmailAsync(request);
        }
    }
}
