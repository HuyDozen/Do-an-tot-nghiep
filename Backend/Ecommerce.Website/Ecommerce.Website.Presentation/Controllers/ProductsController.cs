using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
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
    }
}
