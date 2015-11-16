using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMvc.Models
{
    public partial  class Producto
    {
        [DisplayName("Id Producto:")]
        public int id_producto { get; set; }

        [DisplayName("Fabricante:")]
        [DataType(DataType.MultilineText)]
        public string fabricante_nombre { get; set; }

        [DisplayName("Descripción:")]
        [DataType(DataType.MultilineText)]
        public string descripcion_corta { get; set; }

        [DisplayName("Precio de coste:")]
        [DataType(DataType.Currency)]
        public decimal precio_coste { get; set; }

        [DisplayName("Precio de venta:")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> precio_venta { get; set; }

        [DisplayName("Id Categoria:")]
        public int id_categoria { get; set; }

        [DisplayName("Nombre:")]
        public string nombre { get; set; }
    }
}
