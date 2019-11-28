using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Entities.Models.Mapping;
using Repository.Pattern.Ef6;

namespace Entities.Models
{
    public partial class SAMContext : DataContext
    {
        static SAMContext()
        {
            Database.SetInitializer<SAMContext>(null);
        }

        public SAMContext()
            : base("Name=SAMContext")
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Producto> Productoes { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new ProductoMap());
            modelBuilder.Configurations.Add(new RolMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
