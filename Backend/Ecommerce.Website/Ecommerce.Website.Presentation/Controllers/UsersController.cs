using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Application.Contacts;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Website.Database.Models.Authetication.Login;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.Website.Presentation.Models;
using Ecommerce.Website.Database.Models.Authetication;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BasesController<User>
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("login-user")]
        public  IActionResult Validate(Login model)
        {
            try
            {
                var check = _userService.Validate(model);
                if (check != null)
                {
                    return StatusCode(StatusCodes.Status200OK, check);

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Sai tài khoản hoặc mật khẩu");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        [HttpPost("renew-token")]
        public  IActionResult RenewToken(TokenModel model)
        {
            try
            {
                var check = _userService.RenewToken(model);
                if (check != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse
                    {
                        Auth = true,
                        Message = "Authenticate success",
                        Data = check
                    });

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse
                    {
                        Auth = false,
                        Message = "Invalid username/password",

                    });
                }
            }
            catch (Exception ex)
             {
                  Console.WriteLine(ex.Message);
                 return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        [HttpPost("sign-up")]
        public IActionResult SignUpUser(User user)
        {
            try
            {
                var check = _userService.SignUpUser(user);
                if (check != null)
                {
                    return StatusCode(StatusCodes.Status200OK, user);

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse
                    {
                        Auth = false,
                        Message = "Invalid username/password",

                    });
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
