using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionDeTaller.Models
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es requierido")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "El Marca es requierida")]
        public String Marca { get; set; }

        [Required(ErrorMessage = "La Descripcion es requierida")]
        public String Descripcion { get; set; }

    }
}
