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
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly EcommerceContext _context;
        public OrderDetailRepository(EcommerceContext context) : base(context)
        {
            _context = context;
        }
        public List<ListProductByOrder> GetListProductsByOrder(int id)
        {
            var result = _context
              .OrderDetails
              .Where(u => u.OrderId == id)
              .Select(u => u.ProductId)
              .ToList();
            var reList = new List<ListProductByOrder>();
            foreach (int items in result)
            {
                var product = _context.Products.Where(s => s.Id == items)
                        .FirstOrDefault();
                ListProductByOrder? listProduct = new ListProductByOrder()
                {
                    Id = _context
                    .Orders
                    .Where(u => u.Id == id)
                    .Select(u => u.Id)
                    .FirstOrDefault(),

                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    Image = product.Image,     
                    QuantityOfProduct = product.Quanity,
            };

                reList.Add(listProduct);
            }
            //var result = new Enumerable;
            return reList;
        }

        public List<DetailOrderResponse> GetDetailOrder()
        {
            var entryPoint = (from ep in _context.OrderDetails
                              join e in _context.Orders on ep.OrderId equals e.Id
                              join t in _context.Users on e.UserId equals t.Id
                              select new DetailOrderResponse
                              {
                                  OrderId = ep.OrderId,
                                  Email = t.Email,
                                  Quantity = ep.Quantity,
                                  FullNamme = t.Username,
                                  Role = t.Role,
                              }).ToList();
            return entryPoint;
           
        }
    }
}
