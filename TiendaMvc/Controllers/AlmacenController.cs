using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaMvc.Filtros;
using TiendaMvc.Models;

namespace TiendaMvc.Controllers
{
    public class AlmacenController : Controller
    {

        // Conexion a base de datos con Entity
        private Tienda25Entities db = new Tienda25Entities();

        public ActionResult Etiquetas()
        {
            
            // Asigno al ViewBag etiquetas
            ViewBag.etiquetas = db.Etiqueta.ToList();
            // Asigno al ViewBag almacenes
            ViewBag.almacenes = db.Almacen.ToList();
            
            return View();
        }

        // GET: Listado de almacenes
        public ActionResult Index()
        {
            // obtener listado de etiquetas
            var info = db.Etiqueta;
            // guardo objeto en ViewBag
            ViewBag.etiquetas = info.ToList();
            ViewData["Titulo"] = "Listado de almacenes"; 

            var data = db.Almacen;
            return View(data);
        }

        [FiltroId] // aplica este filtro
        // para cargar el formulario
        public ActionResult Modificar(int? id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }


        
        // para guardar el almacen
        [HttpPost]
        [ValidateAntiForgeryToken] // genera un token
        public ActionResult Modificar(Almacen model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified; // indica el estado en que esta el objeto = Modified
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Borrar(int id)
        {
            var data = db.Almacen.Find(id);
            if (data.Almacen_Producto.Any()) // si hay algun registro
                db.Almacen_Producto.RemoveRange(data.Almacen_Producto); // hago borrado en cascada

            db.Almacen.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //public ActionResult Detalle(int id)
        //{
        //    var data = db.Almacen.Find(id);
        //    return View(data);
        //}

        //[HttpPost] // Unicamente por Post
        //// llega la petición desde Http
        //public ActionResult Actualizar(Almacen model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Almacen.Add(model);
        //        db.SaveChanges();
        //        // porque si guarda podrias crear otro, es como limpiar el formulario
        //        return View(new Almacen());
        //    }
        //    // por defecto esta el formulario para corregirlo
        //    return View(model);
        //}

        
        //// llega la petición desde Http
        //public ActionResult Borrar(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Almacen almacen = db.Almacen.Find(id);
        //    if (almacen == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(almacen);
        //}

        //// POST: Almacen/Borrar/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult BorrarConfirmed(int id)
        //{
        //    var data = db.Almacen.Find(id);
        //    db.Almacen.Remove(data);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Editar(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Almacen almacen = db.Almacen.Find(id);
        //    if (almacen == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(almacen);
        //}




    }
}