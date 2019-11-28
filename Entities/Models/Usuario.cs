using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Usuario : Entity
    {
        public Usuario()
        {
            this.Perfils = new List<Perfil>();
        }

        public System.Guid UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string CorreoElectronico { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public virtual ICollection<Perfil> Perfils { get; set; }
    }
}
