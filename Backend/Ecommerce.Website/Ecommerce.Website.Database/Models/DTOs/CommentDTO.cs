using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.DTOs
{
    public class CommentDTO : BaseEntity
    {
        public string Content { get; set; }
        public string? NameAssessor { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        
    }
}
