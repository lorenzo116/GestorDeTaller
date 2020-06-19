using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionDeTaller.Models
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es requerido")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "La Marca es requerida")]
        public String Marca { get; set; }

        [Required(ErrorMessage = "La Descripción es requerida")]
        public String Descripcion { get; set; }

    }
}
