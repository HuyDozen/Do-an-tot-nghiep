using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly EcommerceContext _context;
        public OrderRepository(EcommerceContext context) : base(context)
        {
            _context = context;
        }
        public ListOrderDetailModel InsertOrder(OrderDetailModel detail)
        {

            if (detail.UserId != null && detail.UserId > 0)
            {
                int maxIdOrder = _context.Orders.Max(p => p.Id);
                var order = new Order()
                {
                    Id = maxIdOrder + 1,
                    UserId = detail.UserId,
                };
                _context.Add(order);
                foreach (var items in detail.Products)
                {

                    var quantityPR = _context.Products
                    .Where(u => u.Id == items.Id)
                    .Select(u => u.Quanity)
                    .SingleOrDefault();

                    if (quantityPR > 0)
                    {
                        quantityPR = quantityPR - items.Incart;
                        if (quantityPR < 0)
                        {
                            quantityPR = 0;
                        }
                    }

                    else
                    {
                        quantityPR = 0;
                    }

                    var orderDetail = new OrderDetail()
                    {
                        OrderId = order.Id,
                        ProductId = items.Id,
                        Quantity = items.Incart
                    };
                    _context.Add(orderDetail);
                    var result = _context.Products.SingleOrDefault(b => b.Id == items.Id);
                    if (result != null)
                    {
                        result.Quanity = quantityPR;
                    }
                    
                    _context.SaveChanges();
                }
                var res = new ListOrderDetailModel()
                {
                    OrderId = order.Id,
                    OrderDetailModels = detail,
                };

                return res;
                _context.SaveChanges();
            }

            else

                return null;
        }
    }
}
