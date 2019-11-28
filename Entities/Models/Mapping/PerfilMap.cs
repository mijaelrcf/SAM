using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Entities.Models.Mapping
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            // Primary Key
            this.HasKey(t => t.PerfilId);

            // Properties
            this.Property(t => t.NombrePerfil)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Perfil");
            this.Property(t => t.PerfilId).HasColumnName("PerfilId");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.NombrePerfil).HasColumnName("NombrePerfil");

            // Relationships
            this.HasMany(t => t.Rols)
                .WithMany(t => t.Perfils)
                .Map(m =>
                    {
                        m.ToTable("PerfilRol");
                        m.MapLeftKey("PerfilId");
                        m.MapRightKey("RolId");
                    });

            this.HasMany(t => t.Usuarios)
                .WithMany(t => t.Perfils)
                .Map(m =>
                    {
                        m.ToTable("UsuarioPerfil");
                        m.MapLeftKey("PerfilId");
                        m.MapRightKey("UsuarioId");
                    });

            this.HasRequired(t => t.Producto)
                .WithMany(t => t.Perfils)
                .HasForeignKey(d => d.ProductoId);

        }
    }
}
