using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Id)
                 .HasColumnName("product_id")
                 .IsRequired();
            entityBuilder.Property(t => t.Title)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasColumnName("title");

            entityBuilder.Property(t => t.Image)
                 .HasColumnName("image")
                 .HasColumnType("varchar(255)")
                .IsRequired();
            entityBuilder.Property(t => t.Images)
                 .HasColumnName("images")
                 .HasColumnType("varchar(255)")
                .IsRequired();
            entityBuilder.Property(t => t.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(255)")
                .IsRequired();
            entityBuilder.Property(t => t.Price)
                 .HasColumnName("price")
                 .HasColumnType("decimal(18,4)")
                .IsRequired()
                .HasPrecision(18, 4);
            entityBuilder.Property(t => t.Quanity)
                .HasColumnName("quanity");
            entityBuilder.Property(t => t.ShortDesc)
                .HasColumnType("varchar(100)")
                .HasColumnName("short_desc");
            entityBuilder.Property(t => t.CategoryId)
                .HasColumnName(@"category_id");
            entityBuilder.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);
            entityBuilder.Property(t => t.ModifiedBy)
                .HasColumnName("modified_by")
                .HasColumnType("varchar(255)");
            entityBuilder.Property(t => t.ModifiedDate)
                .HasColumnName("modified_date");
            entityBuilder.Property(t => t.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("varchar(255)");
            entityBuilder.Property(t => t.CreatedDate)
                .HasColumnName("created_date");
            entityBuilder.Property(t => t.IsDeleted)
                .HasColumnName("is_deleted");
        }
    }
}
