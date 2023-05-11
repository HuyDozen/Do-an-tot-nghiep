using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly EcommerceContext _context;
        public CategoryRepository(EcommerceContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductByOrderViewModel> GetProductsByCategory()
        {
            var joinedData = from ct in _context.Categories
                             join pr in _context.Products on ct.Id equals pr.CategoryId
                             orderby ct.Title descending
                             select new ProductByOrderViewModel
                             {
                                 CategoryName = ct.Title,
                                 Products = pr,
                             };

            var result = new List<ProductByOrderViewModel>();
            if (joinedData != null)
            {
               foreach(var items in joinedData)
                {
                    result.Add(items);
                }
                return result;
            }
            else
            {
                return null;
            }   
        }
    }
}
