using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class RefreshTokenMap
    {
        public RefreshTokenMap(EntityTypeBuilder<RefreshToken> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Id)
                 .HasColumnName("product_id")
                 .IsRequired();
            entityBuilder.Property(t => t.Token)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("token");

            entityBuilder.Property(t => t.JwtId)
                     .HasColumnName("jwt_id")
                     .HasColumnType("varchar(255)")
                    .IsRequired();
            entityBuilder.Property(t => t.IsUsed)
                     .HasColumnName("is_used")
                     .HasColumnType("varchar(255)")
                    .IsRequired();
            entityBuilder.Property(t => t.IsRevoked)
                    .HasColumnName("is_revoked")
                    .HasColumnType("varchar(255)")
                    .IsRequired();
            entityBuilder.Property(t => t.ExpiredAt)
                    .HasColumnName("expired_at")
                    .IsRequired();
            entityBuilder.Property(t => t.UserId)
                    .HasColumnName(@"user_id");
            entityBuilder.HasOne(e => e.User)
                    .WithMany(e => e.RefreshTokens)
                    .HasForeignKey(e => e.UserId);
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
