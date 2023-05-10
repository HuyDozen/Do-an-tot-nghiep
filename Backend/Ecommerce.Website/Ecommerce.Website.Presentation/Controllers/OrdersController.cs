using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BasesController<Order>
    {
        private readonly IOrderService _orderService;
        public OrdersController (IOrderService orderService) : base(orderService)
        {
            _orderService = orderService;
        }
    }
}
