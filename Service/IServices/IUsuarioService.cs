using Entities.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IUsuarioService : IService<Usuario>
    {
        IEnumerable<Usuario> UsersByUserName(string NombreUsuario);
        bool SignIn(string NombreUsuario, string Password, bool RememberMe);
    }
}
