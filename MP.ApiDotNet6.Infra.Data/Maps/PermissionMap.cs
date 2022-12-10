using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Infra.Data.Maps 
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permissao");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idpermissao").
                UseIdentityColumn();

            builder.Property(c => c.VisualName)
                .HasColumnName("nomevisual");

            builder.Property(c => c.PermissionName)
                .HasColumnName("nomepermissao");  

            builder.HasMany(c => c.UserPermissions)
                    .WithOne(p=> p.Permission) 
                    .HasForeignKey(x => x.PermissionId);          
        }
    }
}