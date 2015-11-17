using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMvc.Models;

namespace TiendaMvc.Controllers
{
    public class ProductosAjaxController : Controller
    {
        // Conexion a base de datos con Entity
        private Tienda25Entities db = new Tienda25Entities();

        // GET: ProductosAjax
        public ActionResult Index()
        {
            return View(db.Producto);
        }
        
        public ActionResult Buscar(String nombre)
        {
            var data = db.Producto.Where(o => o.nombre.Contains(nombre));
            // el nombre del partial y los datos
            return PartialView("_listadoProducto", data);
            
        }

        [HttpPost]
        public ActionResult Alta(Producto model)
        {
            db.Producto.Add(model);
            db.SaveChanges();
            return Json(model); // devuelve un objeto Json
        }
    }
}