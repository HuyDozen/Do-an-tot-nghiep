using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BasesController<Comment>
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService):base(commentService)
        {
            _commentService = commentService;
        }
    }
}
