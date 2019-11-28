using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Menu : Entity
    {
        public System.Guid MenuId { get; set; }
        public System.Guid ProductoId { get; set; }
        public string NombreMenu { get; set; }
        public Nullable<System.Guid> MenuPadreId { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
