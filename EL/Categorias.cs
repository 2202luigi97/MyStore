using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("Categorias")]
    public class Categorias
    {
        [Key]
        public int IdCategoria { get; set; }
        [MaxLength(50)]
        [Required]
        public string Categoria { get; set;}
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }

    }
}
