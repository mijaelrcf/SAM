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
    public class ProductoService : Service<Producto>, IProductoService
    {
        private readonly IRepositoryAsync<Producto> _repository;

        public ProductoService(IRepositoryAsync<Producto> repository) : base(repository)
        {
            _repository = repository;
        }
        public IEnumerable<Producto> GetProductoByNombreProducto(string NombreProducto)
        {
            return _repository.GetProductoByNombreProducto(NombreProducto).ToList();
        }

        public IEnumerable<Producto> ProductsByUserName(string nombreUsuario)
        {
            return _repository.ProductsByUserName(nombreUsuario).ToList();
        }

        public override void Insert(Producto entity)
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
