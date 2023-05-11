using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class DetailOrderResponse
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public string FullNamme { get; set; }
        public string Role { get; set; }
    }
}
