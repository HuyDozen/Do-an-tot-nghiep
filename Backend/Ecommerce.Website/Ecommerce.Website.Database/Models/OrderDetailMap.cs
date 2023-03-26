using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class OrderDetailMap
    {
        public OrderDetailMap(EntityTypeBuilder<OrderDetail> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Id)
                .HasColumnName("order_detail_id")
                .IsRequired();
            entityBuilder.Property(t => t.Quantity)
                .HasColumnName("quantity");
            entityBuilder.Property(t => t.OrderId)
                .HasColumnName(@"order_id"); 
            entityBuilder.Property(t => t.ProductId)
                 .HasColumnName(@"product_id");

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
            entityBuilder.HasOne(e => e.Order).WithMany(e => e.orderDetails).HasForeignKey(e => e.OrderId);
            entityBuilder.HasOne(e => e.Product).WithMany(e => e.orderDetails).HasForeignKey(e => e.ProductId);
        }
    }
}
