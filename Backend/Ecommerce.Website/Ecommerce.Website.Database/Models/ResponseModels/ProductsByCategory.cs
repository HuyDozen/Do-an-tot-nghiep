using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class ProductsByCategory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> ListProducts { get; set; }
    }
}
