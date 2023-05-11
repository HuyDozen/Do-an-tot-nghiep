using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Repositories
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        private readonly EcommerceContext _ecommerceContext;

        public RatingRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }
    }
}
