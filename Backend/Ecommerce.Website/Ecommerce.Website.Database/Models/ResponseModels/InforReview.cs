using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class InforReview
    {
        public int? UserId { get; set; }
        public int ProductId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int RatingCount { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
