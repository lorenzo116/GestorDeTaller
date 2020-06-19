using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionDeTaller.Models
{
    public class Repuestos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
       
        public int Id_Articulo { get; set; }

        
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio debe ser mayor 0 ")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }
    }
}
