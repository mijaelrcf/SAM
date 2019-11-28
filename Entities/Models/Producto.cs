using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Producto : Entity
    {
        public Producto()
        {
            this.Menus = new List<Menu>();
            this.Perfils = new List<Perfil>();
        }

        public System.Guid ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string UrlWebSite { get; set; }
        public string UrlImagen { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Perfil> Perfils { get; set; }
    }
}
