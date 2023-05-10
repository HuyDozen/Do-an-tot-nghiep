using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Id)
                .HasColumnName("user_id")
                .IsRequired();
            entityBuilder.Property(t => t.FullName)
                .HasColumnName("full_name")
                .HasColumnType("varchar(255)")
                .IsRequired();
            entityBuilder.Property(t => t.Username)
                .HasColumnName("user_name")
                .HasColumnType("varchar(100)")
                .IsRequired();
            entityBuilder.Property(t => t.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(255)")
                .IsRequired();
            entityBuilder.Property(t => t.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(100)")
                .IsRequired();
            entityBuilder.Property(t => t.Age)
                .HasColumnName("age")
                .IsRequired();
            entityBuilder.Property(t => t.Role)
                .HasColumnName("role")
                .HasColumnType("varchar(50)")
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
