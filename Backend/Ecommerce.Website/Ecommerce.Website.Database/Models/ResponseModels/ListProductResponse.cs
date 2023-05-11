using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class ListProductResponse
    {
        public int CountProduct { get; set; }
        public string NameCate { get; set; }
        public List<InforProduct> InforProducts { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
