using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Entities.Models.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.UsuarioId);

            // Properties
            this.Property(t => t.NombreUsuario)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CorreoElectronico)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Nombres)
                .HasMaxLength(50);

            this.Property(t => t.Apellidos)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Usuario");
            this.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            this.Property(t => t.NombreUsuario).HasColumnName("NombreUsuario");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.CorreoElectronico).HasColumnName("CorreoElectronico");
            this.Property(t => t.Nombres).HasColumnName("Nombres");
            this.Property(t => t.Apellidos).HasColumnName("Apellidos");
        }
    }
}
