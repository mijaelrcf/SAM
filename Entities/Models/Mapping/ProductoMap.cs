using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Entities.Models.Mapping
{
    public class ProductoMap : EntityTypeConfiguration<Producto>
    {
        public ProductoMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductoId);

            // Properties
            this.Property(t => t.NombreProducto)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DescripcionProducto)
                .HasMaxLength(150);

            this.Property(t => t.UrlWebSite)
                .HasMaxLength(150);

            this.Property(t => t.UrlImagen)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Producto");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.NombreProducto).HasColumnName("NombreProducto");
            this.Property(t => t.DescripcionProducto).HasColumnName("DescripcionProducto");
            this.Property(t => t.UrlWebSite).HasColumnName("UrlWebSite");
            this.Property(t => t.UrlImagen).HasColumnName("UrlImagen");
        }
    }
}
