using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
