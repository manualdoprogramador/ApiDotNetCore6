using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Compra");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IdCompra").
                UseIdentityColumn();

            builder.Property(c => c.PersonId)
                .HasColumnName("IdPessoa");

            builder.Property(c => c.ProductId)
                .HasColumnName("IdProduto");

            builder.Property(c => c.Date)
                .HasColumnType("date")
                .HasColumnName("DataCompra");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Purchases);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Purchases);
        }
    }
}

