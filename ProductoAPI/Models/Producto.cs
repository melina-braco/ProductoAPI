using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductoAPI.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }

        [Index(IsUnique = true)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El campo Nombre no puede estar vacio")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Cantidad no puede estar vacio")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo Precio Costo no puede estar vacio")]
        public decimal PrecioCosto { get; set; }

        public decimal Total { get; set; }

        public DateTime FechaIngreso { get; set; }
    }
}
