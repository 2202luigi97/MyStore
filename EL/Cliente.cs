﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EL
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(10)]
        public string Celular { get; set; }
        [Required]
        [MaxLength(200)]
        public string Correo { get; set;}
        [Required]
        public bool Activo { get; set; }
        [Required]
        public int IdUsuarioRegistra { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set;}
    }
}
