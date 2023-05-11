using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class Product : BaseEntity
    {
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Images { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Quanity { get; set; }
        public string? ShortDesc { get; set; }


        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        //public virtual ICollection<NewDetail>? NewDetails { get; set; }
        public virtual ICollection<OrderDetail>? orderDetails { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }

    }
    
}
