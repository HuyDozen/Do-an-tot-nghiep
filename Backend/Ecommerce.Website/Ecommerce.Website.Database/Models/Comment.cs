using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public string? NameAssessor { get; set; }
        public string? Email { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        //public int NewId { get; set; }
        //public virtual New New { get; set; }

    }
}
