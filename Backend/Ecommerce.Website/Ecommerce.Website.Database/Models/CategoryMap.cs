using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class CategoryMap
    {
        public CategoryMap(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Id)
                .HasColumnName("category_id")
                .IsRequired();

            entityBuilder.Property(t => t.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(255)")
                .IsRequired();

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
