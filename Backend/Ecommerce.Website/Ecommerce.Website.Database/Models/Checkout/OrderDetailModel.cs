using Ecommerce.Website.Database.Models.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class OrderDetailModel 
    {
        public int UserId { get; set; }
        public List<IncartModel> Products { get; set;}
    }
}
