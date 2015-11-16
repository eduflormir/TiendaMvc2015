using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMvc.Models
{
    public partial class Almacen
    {
        [DisplayName("Id Almacen:")]
        
        public int id_almacen { get; set; }

        [DisplayName("Ciudad:")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string ciudad { get; set; }

        [DisplayName("Código Postal:")]
        [DataType(DataType.MultilineText)]
        [Required]
        [RegularExpression(@"^[0-9]{5}$",
         ErrorMessage = "Código Postal incorrecto")]
        public int codigo_postal { get; set; }

        [DisplayName("Nombre:")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string nombre { get; set; }
    }
}
