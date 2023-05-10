using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class AddressMap
    {
        public AddressMap(EntityTypeBuilder<Address> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("address_id");
            entityBuilder.Property(t => t.LineFirst)
                .HasColumnName("line_first")
                .HasColumnType("varchar(255)")
                .IsRequired();
            entityBuilder.Property(t => t.LineSecond)
                .HasColumnName("line_second")
                .HasColumnType("varchar(255)")
                .IsRequired();
            entityBuilder.Property(t => t.City)
                .HasColumnName("city")
                .HasColumnType("varchar(50)")
                .IsRequired();
            entityBuilder.Property(t => t.State)
                .HasColumnName("state")
                .HasColumnType("varchar(50)")
                .IsRequired();
            entityBuilder.Property(t => t.Country)
                .HasColumnName("country")
                .HasColumnType("varchar(50)")
                .IsRequired();
            entityBuilder.Property(t => t.PhoneNumber)
                .HasColumnName("phone_number")
                .HasColumnType("varchar(50)")
                .IsRequired();
            entityBuilder.Property(t => t.PostalCode)
                .HasColumnName("Postal_code")
                .HasColumnType("varchar(20)")
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
            entityBuilder.Property(t => t.UserId)
                .HasColumnName(@"user_id");
            entityBuilder.HasOne(e => e.User).WithMany(e => e.Address).HasForeignKey(e => e.UserId);
        }
    }
}
