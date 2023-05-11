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
        public OrdersController(IOrderService orderService) : base(orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        [Route("/new-order")]
        public IActionResult InsertOrder([FromBody] OrderDetailModel detail)
        {
            try
            {
                var result = _orderService.InsertOrder(detail);
                return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "{message: 'New order failed', success: false}");
            }
        }
        [HttpPost]
        [Route("/payment")]
        public IActionResult UpdateToPayment()
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, true);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

    }
}
