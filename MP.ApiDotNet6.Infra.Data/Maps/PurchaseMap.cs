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
            builder.ToTable("compra");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idcompra").
                UseIdentityColumn();

            builder.Property(c => c.PersonId)
                .HasColumnName("idpessoa");

            builder.Property(c => c.ProductId)
                .HasColumnName("idproduto");

            builder.Property(c => c.Date)
                .HasColumnType("date")
                .HasColumnName("datacompra");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Purchases);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Purchases);
        }
    }
}

