using System;

namespace EL
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set;}
        public bool Activo { get; set; }
        public int IdUsuarioRegistra { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set;}
    }
}
