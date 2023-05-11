using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService) 
        {
            _emailService = emailService;
        }

        /// <summary>
        /// API gửi email cho người dùng với tiêu đề, người nhận và nội dung mail là trang html
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("send-mail")]
        public async Task<IActionResult> SendEmailAsync(EmailDto request)
        {
            try
            {  
                var result = _emailService.SendEmailAsync(request);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status200OK, result);

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Loi chua xac nhan");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }
    }
}
