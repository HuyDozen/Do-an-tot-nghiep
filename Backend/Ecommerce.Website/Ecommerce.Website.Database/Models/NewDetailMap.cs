//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ecommerce.Website.Database.Models
//{
//    public class NewDetailMap
//    {
//        public NewDetailMap(EntityTypeBuilder<NewDetail> entityBuilder)
//        {
//            entityBuilder.HasKey(t => t.Id);
//            entityBuilder.Property(t => t.Id)
//                .HasColumnName("new_detail_id")
//                .IsRequired();
//            entityBuilder.Property(t => t.Quantity)
//                .HasColumnName("quantity");
//            entityBuilder.Property(t => t.ProductId)
//                .HasColumnName(@"product_id");
//            entityBuilder.Property(t => t.New)
//                 .HasColumnName(@"new_id");

//            entityBuilder.Property(t => t.ModifiedBy)
//                .HasColumnName("modified_by")
//                .HasColumnType("varchar(255)");
//            entityBuilder.Property(t => t.ModifiedDate)
//                .HasColumnName("modified_date");
//            entityBuilder.Property(t => t.CreatedBy)
//                .HasColumnName("created_by")
//                .HasColumnType("varchar(255)");
//            entityBuilder.Property(t => t.CreatedDate)
//                .HasColumnName("created_date");
//            entityBuilder.Property(t => t.IsDeleted)
//                .HasColumnName("is_deleted");
//            entityBuilder.HasOne(e => e.New).WithMany(e => e.NewDetails).HasForeignKey(e => e.NewId);
//            entityBuilder.HasOne(e => e.Product).WithMany(e => e.NewDetails).HasForeignKey(e => e.ProductId);


//        }
//    }
//}
