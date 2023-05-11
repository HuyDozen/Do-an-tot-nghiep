using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class ProductsReponse
    { 
        public int Count { get; set; }
        public string NameSearch { get; set; }
        public List<InforProduct> InforProducts { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
