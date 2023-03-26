using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Application.Contacts;
using Microsoft.AspNetCore.Mvc;

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
    }
}
