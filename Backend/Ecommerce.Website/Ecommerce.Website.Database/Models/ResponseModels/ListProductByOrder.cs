using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class ListProductByOrder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public string Image { get; set; }
        public int? QuantityOfProduct { get; set; }
        
    }
}
