using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Models;


namespace Ecommerce.Website.Application.Services
{
    public class OrderDetailService : BaseService<OrderDetail>, IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository) : base(orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
    }
}
