using Ecommerce.Website.Database.Models.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class ListOrderDetailModel
    {
        public int OrderId { get; set; }
        public OrderDetailModel OrderDetailModels { get; set; }
    }
}
