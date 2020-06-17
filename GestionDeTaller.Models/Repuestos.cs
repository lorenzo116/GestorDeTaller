using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionDeTaller.Models
{
    public class Repuestos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requierido")]
        public string Nombre { get; set; }
       
        public int Id_Articulo { get; set; }

        
        [Required(ErrorMessage = "El precio es requierido")]
        [Range(0, int.MaxValue, ErrorMessage = "El costo fijo debe ser mayor 0 ")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "La descripcion es requierida")]
        public string Descripcion { get; set; }
    }
}
