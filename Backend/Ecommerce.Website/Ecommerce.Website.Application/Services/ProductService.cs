using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            return _productRepository.GetAll(search,from,to,sortBy,page);
        }

        public InforProduct GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public ListProductResponse GetProductByCategory(int id,string? sortBy,int page)
        {
            return _productRepository.GetProductByCategory(id,sortBy, page);
        }

        public ProductsReponse GetProductsByName(string? nameProduct,int page)
        {
            return _productRepository.GetProductsByName(nameProduct,page);
        }
        public ProductsReponse GetAllProducts(int page = 1)
        {
            return _productRepository.GetAllProducts(page);
        }
        public InforReview CommentProduct(InforReview request)
        {
            return _productRepository.CommentProduct(request);
        }
        public ReviewReponse GetCommentByIdProduct(int id)
        {
            return _productRepository.GetCommentByIdProduct(id);
        }
    }
}
