using Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public static class ProductoRepository
    {
        public static IEnumerable<Producto> GetProductoByNombreProducto(this IRepository<Producto> repository, string NombreProducto)
        {
            return repository
                .Queryable()
                .Where(x => x.NombreProducto.Contains(NombreProducto))
                .AsEnumerable();
        }

        public static IEnumerable<Producto> ProductsByUserName(this IRepository<Producto> repository, string NombreUsuario)
        {
            var producto = repository.GetRepository<Producto>().Queryable();
            var perfil = repository.GetRepository<Perfil>().Queryable();

            var query = from productItem in producto
                          from perfilItem in perfil
                        where perfilItem.NombrePerfil == NombreUsuario
                        select productItem;

            return query.AsEnumerable();
        }
    }
}
