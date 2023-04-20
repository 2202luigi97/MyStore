using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("Productos")]
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        [MaxLength(100)]
        public string CodigoBarra { get; set; }
        [MaxLength(200)]
        [Required]
        public string Descripcion { get; set; }
        [MaxLength(50)]
        [Required]
        public string Marca { get; set; }
        [Required]
        public int IdCategoria { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
    }
    public class vProducto
    {
        [Key]
        public int IdProducto { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
    }
}
