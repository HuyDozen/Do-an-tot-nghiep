using Ecommerce.Website.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Website.Database.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) {}
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        //public DbSet<New> News { get; set; }
        //public DbSet<NewDetail> NewDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new RefreshTokenMap(modelBuilder.Entity<RefreshToken>());
            new AddressMap(modelBuilder.Entity<Address>());
            new CategoryMap(modelBuilder.Entity<Category>());
            new OrderDetailMap(modelBuilder.Entity<OrderDetail>());
            new OrderMap(modelBuilder.Entity<Order>());
            new ProductMap(modelBuilder.Entity<Product>());
            new UserMap(modelBuilder.Entity<User>());
            new CommentMap(modelBuilder.Entity<Comment>());
            new RatingMap(modelBuilder.Entity<Rating>());
            //new NewMap(modelBuilder.Entity<New>());
            //new NewDetailMap(modelBuilder.Entity<NewDetail>());
        }
    }
}
