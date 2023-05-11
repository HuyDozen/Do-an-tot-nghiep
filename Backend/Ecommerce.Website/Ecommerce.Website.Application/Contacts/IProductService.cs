using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Contacts
{
    public interface IProductService : IBaseService<Product>
    {
        IEnumerable<Product> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1);
        InforProduct GetProductById(int id);
        ListProductResponse GetProductByCategory(int id,string? sortBy, int page);
        ProductsReponse GetProductsByName(string? nameProduct,int page);
        ProductsReponse GetAllProducts(int page = 1);
        InforReview CommentProduct(InforReview request);
        ReviewReponse GetCommentByIdProduct(int id);

    }
}
