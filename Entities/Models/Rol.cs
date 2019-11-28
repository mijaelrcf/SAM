using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Rol : Entity
    {
        public Rol()
        {
            this.Perfils = new List<Perfil>();
        }

        public System.Guid RolId { get; set; }
        public string NombreRol { get; set; }
        public virtual ICollection<Perfil> Perfils { get; set; }
    }
}
