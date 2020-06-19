using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name ="Costo fijo")]
        public double CostoFijo { get; set; }

        [NotMapped, Display(Name = "Precio Total")]
        public double PrecioTotal { get; set; }

        [NotMapped, Display(Name = "Costo De Repuestos")]
        public double CostoDeRepuestos { get; set; }
    }
}
