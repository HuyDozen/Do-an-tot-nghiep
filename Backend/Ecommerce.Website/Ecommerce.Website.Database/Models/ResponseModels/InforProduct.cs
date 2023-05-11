using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class InforProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public string Image { get; set; }
        public string Images { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string ShortDesc { get; set; }
        
        
    }
}
