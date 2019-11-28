using Entities.Models;
using Repository.Pattern.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public static class UsuarioRepository
    {
        public static IEnumerable<Usuario> UsersByUserName(this IRepository<Usuario> repository, string NombreUsuario)
        {
            return repository
                .Queryable()
                .Where(x => x.NombreUsuario.Equals(NombreUsuario))
                .AsEnumerable();
        }

        public static IEnumerable<Usuario> SignIn(this IRepository<Usuario> repository, string NombreUsuario, string Password, bool RememberMe)
        {
            return repository
                .Queryable()
                .Where(x => x.NombreUsuario.Equals(NombreUsuario) && x.Password.Equals(Password))
                .AsEnumerable();
        }
    }
}
