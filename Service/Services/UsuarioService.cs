using Entities.Models;
using Repository.Pattern.Repositories;
using Repository.Repositories;
using Service.IServices;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        private readonly IRepositoryAsync<Usuario> _repository;

        public UsuarioService(IRepositoryAsync<Usuario> repository) : base(repository)
        {
            _repository = repository;
        }
        public IEnumerable<Usuario> UsersByUserName(string NombreUsuario)
        {
            return _repository.UsersByUserName(NombreUsuario).ToList();
        }

        public bool SignIn(string NombreUsuario, string Password, bool RememberMe)
        {

            return _repository.SignIn(NombreUsuario, Password, RememberMe).ToList().Count > 0;
        }


        public override void Insert(Usuario entity)
        {
            // e.g. add business logic here before inserting
            base.Insert(entity);
        }

        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }
    }
}
