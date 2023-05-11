using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class RatingMap
    {
        public RatingMap(EntityTypeBuilder<Rating> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Id)
                .HasColumnName("rating_id")
                .IsRequired();
            entityBuilder.Property(t => t.UserId)
                .HasColumnName(@"user_id");
            entityBuilder.Property(t => t.ProductId)
                .HasColumnName(@"product_id");
            entityBuilder.Property(t => t.NameAssessor)
                .HasColumnName("name_assessor")
                .HasColumnType("varchar(255)");
            entityBuilder.Property(t => t.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)");
            entityBuilder.Property(t => t.RatingCount)
                .HasColumnName("rating_count");
            entityBuilder.HasOne(e => e.User)
                .WithMany(e => e.Ratings)
                .HasForeignKey(e => e.UserId);
            entityBuilder.HasOne(e => e.Product)
                .WithMany(e => e.Ratings)
                .HasForeignKey(e => e.ProductId);
            //entityBuilder.HasOne(e => e.New)
            //    .WithMany(e => e.Ratings)
            //    .HasForeignKey(e => e.NewId);
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
