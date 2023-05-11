using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class ProductByOrderViewModel
    {
        public string CategoryName { get; set; }
        public Product Products { get; set;}
    }
}
