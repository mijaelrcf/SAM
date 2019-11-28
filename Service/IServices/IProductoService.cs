using Entities.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IProductoService : IService<Producto>
    {
        IEnumerable<Producto> GetProductoByNombreProducto(string NombreProducto);
        IEnumerable<Producto> ProductsByUserName(string NombreUsuario);
    }
}
