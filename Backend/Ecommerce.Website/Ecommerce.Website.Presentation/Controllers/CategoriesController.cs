using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : BasesController<Category>
    {
        private readonly ICategoryService _categoryService;    
        public CategoriesController(ICategoryService categoryService) : base(categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
