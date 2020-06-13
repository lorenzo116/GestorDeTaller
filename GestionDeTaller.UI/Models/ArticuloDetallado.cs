using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeTaller.UI.Models
{
    public class ArticuloDetallado
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Marca { get; set; }

        public string Descripcion { get; set; }


        [Display(Name = "Nombre del repuesto")]
        public string NombreDelRepuesto { get; set; }

        [Display(Name = "Precio del repuesto")]
        public double PrecioDelRepuesto { get; set; }

        [Display(Name = "Ordenes Terminadas")]
        public string CantidadDeOrdenesTerminadas { get; set; }

        [Display(Name = "Ordenes En Proceso")]
        public string CantidadDeOrdenesEnProceso { get; set; }

    }
}
