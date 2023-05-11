using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Contacts
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        List<ListProductByOrder> GetListProductsByOrder(int id);
        List<DetailOrderResponse> GetDetailOrder();
    }
}
