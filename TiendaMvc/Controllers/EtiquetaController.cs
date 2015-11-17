using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMvc.Models;

namespace TiendaMvc.Controllers
{
    public class EtiquetaController : BaseController
    {

        // Conexion a base de datos con Entity
        private Tienda25Entities db = new Tienda25Entities();

        // [FiltroTiempo]
        public ActionResult Index()
        {
            var data = db.Etiqueta;
            ViewBag.Almacenes = db.Almacen;
            return View(data);
        }
    }
}