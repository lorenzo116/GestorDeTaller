using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionDeTaller.Models
{
    public class Repuestos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requierido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El artículo es requerido")]
        public int Id_Articulo { get; set; }
        [Required(ErrorMessage = "El precio es requierido")]
        public float Precio { get; set; }
        [Required(ErrorMessage = "La descripcion es requierida")]
        public string Descripcion { get; set; }
    }
}
