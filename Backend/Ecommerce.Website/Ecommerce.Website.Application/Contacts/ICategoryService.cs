using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Contacts
{
    public interface ICategoryService : IBaseService<Category>
    {
        List<ProductByOrderViewModel> GetProductsByCategory();

    }
}
