using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TiendaMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // por defecto mostrar /Producto/Index

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Producto", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "DetalleProducto",
                url: "item/{nombre}",
                defaults: new { controller = "Producto", action = "Detalle", nombre = UrlParameter.Optional }
            );



            //Ruta generica al final
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );



        }
    }
}
