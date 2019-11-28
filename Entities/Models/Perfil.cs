using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Perfil : Entity
    {
        public Perfil()
        {
            this.Rols = new List<Rol>();
            this.Usuarios = new List<Usuario>();
        }

        public System.Guid PerfilId { get; set; }
        public System.Guid ProductoId { get; set; }
        public string NombrePerfil { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual ICollection<Rol> Rols { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
