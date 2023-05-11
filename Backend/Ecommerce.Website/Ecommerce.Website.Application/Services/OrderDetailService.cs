using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;

namespace Ecommerce.Website.Application.Services
{
    public class OrderDetailService : BaseService<OrderDetail>, IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository) : base(orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public List<ListProductByOrder> GetListProductsByOrder(int id)
        {
            return _orderDetailRepository.GetListProductsByOrder(id);
        }
        public List<DetailOrderResponse> GetDetailOrder()
        {
            return _orderDetailRepository.GetDetailOrder();
        }
    }
}
