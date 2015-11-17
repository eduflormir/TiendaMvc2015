﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMvc.Models;

namespace TiendaMvc.Controllers
{
    public class ProductoController : BaseController
    {
        // Conexion a base de datos con Entity
        Tienda25Entities db = new Tienda25Entities();
        // GET: Producto
        public ActionResult Alta()
        {
            // Para limpiar la pagina le envio un objeto vacio
            return View(new Producto());  
        }

        public ActionResult Index()
        {
            var data = db.Producto;

            return View(data);
        }

        public ActionResult Detalle(int id)
        {
            var data = db.Producto.Find(id);
            return View(data);
        }

        [HttpPost] // Unicamente por Post
        // llega la petición desde Http
        public ActionResult Alta(Producto model)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(model);
                db.SaveChanges();
                // porque si guarda podrias crear otro, es como limpiar el formulario
                return View(new Producto());
            }
            // por defecto esta el formulario para corregirlo
            return View(model);
        }




    }
}