using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class ReviewReponse
    {
        public int Count { get; set; }
        public IQueryable<InforReview> inforReviews { get; set; }
    }
}
