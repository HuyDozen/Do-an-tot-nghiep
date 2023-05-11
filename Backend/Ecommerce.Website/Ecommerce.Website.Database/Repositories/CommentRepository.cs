
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
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly EcommerceContext _ecommerceContext;

        public CommentRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }
    }
}
