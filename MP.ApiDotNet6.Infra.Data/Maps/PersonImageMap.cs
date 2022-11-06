using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    public class PersonImageMap : IEntityTypeConfiguration<PersonImage>
    {
        public void Configure(EntityTypeBuilder<PersonImage> builder)
        {
            builder.ToTable("pessoaimagem");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idimagem").
                UseIdentityColumn();

            builder.Property(c => c.PersonId)
                .HasColumnName("idpessoa");

            builder.Property(c => c.ImageUri)                
                .HasColumnName("imagemurl");
                

            builder.Property(c => c.ImageBase)                
                .HasColumnName("imagembase");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.PersonImages);
        }
    }
}