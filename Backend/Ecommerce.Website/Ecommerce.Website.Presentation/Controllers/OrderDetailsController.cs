using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : BasesController<OrderDetail>
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService) : base(orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        [Route("/get/{orderId}")]
        public IActionResult GetListProductsByOrder([FromRoute] int orderId)
        {
            try
            {
                var result = _orderDetailService.GetListProductsByOrder(orderId);
                return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        [HttpGet]
        [Route("/get-detailorder")]

        public IActionResult GetDetailOrder()
        {
            try
            {
                var result = _orderDetailService.GetDetailOrder();
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
