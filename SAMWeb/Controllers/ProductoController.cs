using Repository.Pattern.UnitOfWork;
using Service;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public ProductoController(IUnitOfWorkAsync unitOfWork, IProductoService productoService)
        {
            _unitOfWork = unitOfWork;
            _productoService = productoService;
        }
        

        // GET: Index
        public ActionResult Index()
        {
            if (ValidarAcceso())
                return View();

            return View();
        }

        // GET: ListProduct
        public ActionResult ListProducts()
        {
            if (ValidarAcceso())
                return View();

            string nombreUsuario = Convert.ToString(Session["NombreUsuario"]);
            ViewBag.result1 = _productoService.ProductsByUserName(nombreUsuario);
            //ViewBag.result1 = _productoService.Queryable().ToList();
            return View();
        }

        private bool ValidarAcceso() {
            bool tieneAcceso = false;
            //tieneAcceso = true;
            return tieneAcceso;
        }
    }
}