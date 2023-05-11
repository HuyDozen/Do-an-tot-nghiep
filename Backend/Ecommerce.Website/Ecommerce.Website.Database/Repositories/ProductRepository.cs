using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly EcommerceContext _context;
        public static int Page_Size { get; set; } = 8;
        public ProductRepository(EcommerceContext context) : base(context)
        {
            _context = context;
        }
        /// <summary>
        /// API tìm kiếm sản phẩm theo tên
        /// </summary>
        /// <param name="nameProduct"></param>
        /// <returns></returns>
        public ProductsReponse GetProductsByName(string? nameProduct, int page = 1)
        {
            if (nameProduct != null)
            {
                //Dat so luong kq trang mac dinh
                var pageResults = 12f; //12 san pham tren mot trang

                var countProductsByName = _context.Products
                .Where(p => p.Title.ToLower().Contains(nameProduct.ToLower()))
                .Count();
                var pageCount = Math.Ceiling(countProductsByName / pageResults);

                var products = _context.Products
                    .Where(p => p.Title.ToLower().Contains(nameProduct.ToLower()))
                    .Skip((page - 1) * (int)pageResults)//bo qua so luong trang hien tai
                    .Take((int)pageResults)
                    .Select(ep => new InforProduct
                    {
                        Id = ep.Id,
                        Title = ep.Title,
                        CategoryName = ep.Title,
                        CategoryId = ep.CategoryId,
                        Description = ep.Description,
                        Image = ep.Image,
                        Images = ep.Images,
                        Price = ep.Price,
                        Quantity = ep.Quanity,
                        ShortDesc = ep.ShortDesc,
                    }).ToList();

                var response = new ProductsReponse
                {
                    Count = countProductsByName,
                    NameSearch = nameProduct,
                    InforProducts = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                };

                return response;
            }

            else
            {
                var allProducts = _context.Products
                    .Select(ep => new InforProduct
                    {
                        Id = ep.Id,
                        Title = ep.Title,
                        CategoryName = ep.Title,
                        CategoryId = ep.CategoryId,
                        Description = ep.Description,
                        Image = ep.Image,
                        Images = ep.Images,
                        Price = ep.Price,
                        Quantity = ep.Quanity,
                        ShortDesc = ep.ShortDesc,
                    }).Take(16)
                .ToList();

                var response = new ProductsReponse
                {
                    NameSearch = nameProduct,
                    InforProducts = allProducts,
                    CurrentPage = 0,
                    Pages = 0
                };

                return response;
            }




        }

        public InforProduct GetProductById(int id)
        {
            var entryPoint = (from ep in _context.Products
                              join e in _context.Categories on ep.CategoryId equals e.Id
                              where ep.Id == id
                              select new InforProduct
                              {
                                  Id = ep.Id,
                                  Title = ep.Title,
                                  CategoryName = e.Title,
                                  CategoryId = ep.CategoryId,
                                  Description = ep.Description,
                                  Image = ep.Image,
                                  Images = ep.Images,
                                  Price = ep.Price,
                                  Quantity = ep.Quanity,
                                  ShortDesc = ep.ShortDesc,
                              }).FirstOrDefault();
            return entryPoint;
        }

        /// <summary>
        /// API lay ban ghi co phan trang tim kiem (hien tai chua hoan thien)
        /// </summary>
        /// <param name="search"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="sortBy"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            var allProducts = _context.Products.AsQueryable();

            #region filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(
                hh => hh.Title.Contains(search));

            }
            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.Price >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.Price <= to);
            }
            #endregion

            #region Sorting
            //Mac dinh sort theo ten
            allProducts = allProducts.OrderBy(hh => hh.Title);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.Title);
                        break;
                    case "price_asc":
                        allProducts = allProducts.OrderBy(hh => hh.Price);
                        break;
                    case "price_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.Price);
                        break;

                }
            }
            #endregion

            #region Paging
            allProducts = allProducts.Skip((page - 1) * Page_Size).Take(Page_Size);
            #endregion

            var result = allProducts.Select(hh => new Product
            {
                Id = hh.Id,
                Title = hh.Title,
                Image = hh.Image,
                Images = hh.Images,
                Price = hh.Price,
                Quanity = hh.Quanity,
                ShortDesc = hh.ShortDesc,
                CategoryId = hh.CategoryId,
                Description = hh.Description

            });

            return result;


        }
        public ListProductResponse GetProductByCategory(int id, string? sortBy, int page = 1)
        {
            #region
            //Mac dinh sort theo ten
            var allProducts = _context.Products
                    .Where(s => s.CategoryId == id);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_asc":
                        allProducts = allProducts.OrderBy(hh => hh.Title);
                        break;
                    case "name_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.Title);
                        break;
                    case "price_asc":
                        allProducts = allProducts.OrderBy(hh => hh.Price);
                        break;
                    case "price_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.Price);
                        break;

                }
            }
            #endregion

            //Dat so luong kq trang mac dinh
            var pageResults = 15f; //10 san pham tren mot trang

            var countProductsByCategory = _context.Products.Where(s => s.CategoryId == id).Count();
            var pageCount = Math.Ceiling(countProductsByCategory / pageResults);

            var products = allProducts
                    .Skip((page - 1) * (int)pageResults)//bo qua so luong trang hien tai
                    .Take((int)pageResults)
                    .Select(ep => new InforProduct
                    {
                        Id = ep.Id,
                        Title = ep.Title,
                        CategoryId = ep.CategoryId,
                        Description = ep.Description,
                        Image = ep.Image,
                        Images = ep.Images,
                        Price = ep.Price,
                        Quantity = ep.Quanity,
                        ShortDesc = ep.ShortDesc,
                    }).ToList();

            string nameCate = _context.Categories
                .Where(s => s.Id == id)
                .Select(u => u.Title)
                .SingleOrDefault();

            var response = new ListProductResponse
            {
                CountProduct = countProductsByCategory,
                NameCate = nameCate,
                InforProducts = products,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return response;
        }
        public ProductsReponse GetAllProducts(int page = 1)
        {

            //Dat so luong kq trang mac dinh
            var pageResults = 8f; //12 san pham tren mot trang

            var allProducts = _context.Products.ToList();
            List<Product> list = new List<Product>();
            for (int i = allProducts.Count() - 1; i >= 0; i--)
            {
                list.Add(allProducts[i]);
            }

            var countProductsByName = allProducts.Count();

            var pageCount = Math.Ceiling(countProductsByName / pageResults);

            var products = list
                .Skip((page - 1) * (int)pageResults)//bo qua so luong trang hien tai
                .Take((int)pageResults)
                .Select(ep => new InforProduct
                {
                    Id = ep.Id,
                    Title = ep.Title,
                    CategoryName = ep.Title,
                    CategoryId = ep.CategoryId,
                    Description = ep.Description,
                    Image = ep.Image,
                    Images = ep.Images,
                    Price = ep.Price,
                    Quantity = ep.Quanity,
                    ShortDesc = ep.ShortDesc,
                }).ToList();

            var response = new ProductsReponse
            {
                Count = countProductsByName,
                InforProducts = products,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return response;
        }
        public InforReview CommentProduct(InforReview request)
        {
            var valueSaveInComment = new Comment
            {
                UserId = request.UserId,
                NameAssessor = request.Username,
                ProductId = request.ProductId,
                Email = request.Email,
                Content = request.Content,
                CreatedDate = DateTime.Now,
                CreatedBy = request.CreatedBy,
                IsDeleted = false,
                ModifiedBy = request.ModifiedBy,
                ModifiedDate = DateTime.Now,
            };
            _context.Comments.Add(valueSaveInComment);
            var valueSaveInRating = new Rating
            {
                RatingCount = request.RatingCount,
                UserId = request.UserId,
                NameAssessor = request.Username,
                ProductId = request.ProductId,
                Email = request.Email,
                CreatedDate = DateTime.Now,
                CreatedBy = request.CreatedBy,
                IsDeleted = false,
                ModifiedBy = request.ModifiedBy,
                ModifiedDate = DateTime.Now
            };
            _context.Ratings.Add(valueSaveInRating);
            var reponse = new InforReview
            {
                UserId = request.UserId,
                Username = request.Username,
                ProductId = request.ProductId,
                RatingCount = request.RatingCount,
                Email = request.Email,
                Content = request.Content,
                CreatedDate = DateTime.Now,
                CreatedBy = request.CreatedBy,
                IsDeleted = false,
                ModifiedBy = request.ModifiedBy,
                ModifiedDate = DateTime.Now,

            };
            _context.SaveChanges();
            return reponse;
        }
        public ReviewReponse GetCommentByIdProduct(int id)
        {
            var entryPoint = _context.Comments
                .Join(_context.Products, p => p.ProductId, c => c.Id, (p, c) => new
                {
                    p,
                    c
                })
                .Join(_context.Ratings, rc => rc.c.Id, r => r.ProductId, (rc, r) => new InforReview
                {

                    UserId = rc.p.UserId,
                    Username = rc.p.NameAssessor,
                    ProductId = rc.p.ProductId,
                    RatingCount = r.RatingCount,
                    Email = r.Email,
                    Content = rc.p.Content,
                    CreatedDate = rc.p.CreatedDate,
                    CreatedBy = rc.p.CreatedBy,
                    IsDeleted = rc.p.IsDeleted,
                    ModifiedBy = rc.p.ModifiedBy,
                    ModifiedDate = rc.p.ModifiedDate,
                })
                .Where(r => r.ProductId == id);
            if (entryPoint != null)
            {
                var response = new ReviewReponse
                {
                    Count = entryPoint.Count(),
                    inforReviews = entryPoint,
                };
                return response;
            }     
            return null; ;
        }

    }
}
