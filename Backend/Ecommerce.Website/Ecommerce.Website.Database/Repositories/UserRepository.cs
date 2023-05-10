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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly EcommerceContext context;
        public UserRepository(EcommerceContext context) : base(context)
        {
            this.context = context;
        }
    }
}
