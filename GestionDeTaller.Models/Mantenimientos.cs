using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace GestionDeTaller.Models
{
    public class Mantenimientos
    {
        public int Id { get; set; }
        public int Id_Articulo { get; set; }

        [Required(ErrorMessage ="La descripcion es requerida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El costo fijo es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El costo fijo debe ser mayor 0 ")]
        public double CostoFijo { get; set; }
    }
}
