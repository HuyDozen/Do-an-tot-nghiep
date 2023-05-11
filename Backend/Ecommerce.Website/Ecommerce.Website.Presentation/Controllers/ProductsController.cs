using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BasesController<Product>
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService) : base(productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("search-by-name")]
        public IActionResult GetProductsByName(string? nameProduct, int page = 1)
        {
            try
            {
                var records = _productService.GetProductsByName(nameProduct,page);

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="sortBy"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Products/SeachPr")]
        public IActionResult GetAllProducts(
            string? search,
            double? from,
            double? to,
            string? sortBy,
            int page = 1)
        {
            try
            {
                var records = _productService.GetAll(search, from, to, sortBy, page);

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        [HttpGet]
        [Route("Products/{id}")]
        public IActionResult GetAllProducts([FromRoute] int id)
        {
            try
            {
                var records = _productService.GetProductById(id);

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        [HttpGet]
        [Route("productByCategoryId/{categoryId}")]
        public IActionResult GetProductsByCategory([FromRoute] int categoryId,string? orderBy, int page = 1)
        {
            try
            {
                var records = _productService.GetProductByCategory(categoryId,orderBy,page);

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetProducts(
            
            int page = 1)
        {
            try
            {
                var records = _productService.GetAllProducts( page);

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        [HttpPost]
        [Route("comment")]
        public IActionResult CommentProduct(InforReview request)
        {
            try
            {
                var records = _productService.CommentProduct(request);

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }
        [HttpGet]
        [Route("get-comment/{id}")]
        public IActionResult GetCommentByProductId (int id)
        {
            try
            {
                var records = _productService.GetCommentByIdProduct(id);

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
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
