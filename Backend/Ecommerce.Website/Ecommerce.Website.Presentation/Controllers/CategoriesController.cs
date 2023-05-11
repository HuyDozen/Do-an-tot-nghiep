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
        [HttpGet]
        [Route("/get-products")]
        public IActionResult Index()
        {
            try
            {
                 var result = _categoryService.GetProductsByCategory();

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

               
                    return StatusCode(StatusCodes.Status200OK, result);
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }
    }
}
