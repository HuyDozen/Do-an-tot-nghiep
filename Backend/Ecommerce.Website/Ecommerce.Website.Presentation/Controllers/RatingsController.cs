using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : BasesController<Rating>
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService) : base(ratingService)
        {
            _ratingService = ratingService;
        }
    }

}
