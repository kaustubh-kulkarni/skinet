using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    //This class derives IEntityTypeConfiguration from the EF core
    //The main usage of this class is to access the properties of entities and set some definitions to them
    // For eg. StringLength, IsRequired and so on ....
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            //Set max length of the product name
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Description).IsRequired().HasMaxLength(180);
            //Set decimal till 2 e.g. 0.02
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);
        }
    }
}