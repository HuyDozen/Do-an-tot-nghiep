using Ecommerce.Website.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AddressMap(modelBuilder.Entity<Address>());
            new CategoryMap(modelBuilder.Entity<Category>());
            new OrderDetailMap(modelBuilder.Entity<OrderDetail>());
            new OrderMap(modelBuilder.Entity<Order>());
            new ProductMap(modelBuilder.Entity<Product>());
            new UserMap(modelBuilder.Entity<User>());
            

        }
    }
}
