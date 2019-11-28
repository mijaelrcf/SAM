using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Entities.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuId);

            // Properties
            this.Property(t => t.NombreMenu)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Url)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Menu");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.NombreMenu).HasColumnName("NombreMenu");
            this.Property(t => t.MenuPadreId).HasColumnName("MenuPadreId");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Orden).HasColumnName("Orden");

            // Relationships
            this.HasRequired(t => t.Producto)
                .WithMany(t => t.Menus)
                .HasForeignKey(d => d.ProductoId);

        }
    }
}
