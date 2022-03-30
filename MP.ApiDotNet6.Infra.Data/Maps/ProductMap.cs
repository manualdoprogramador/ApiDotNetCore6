using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idproduto").
                UseIdentityColumn();

            builder.Property(c => c.Name)
                .HasColumnName("nome");

            builder.Property(c => c.CodErp)
                .HasColumnName("coderp");

            builder.Property(c => c.Price)
                .HasColumnName("preco");

            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(x => x.ProductId);

        }
    }
}

