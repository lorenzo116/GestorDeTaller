using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionDeTaller.Models
{
    public class ArticuloDetallado
    {
        public string Nombre { get; set; }

        public string Marca { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Ordenes Terminadas")]
        public string CantidadDeOrdenesTerminadas { get; set; }

        [Display(Name = "Ordenes En Proceso")]
        public string CantidadDeOrdenesEnProceso { get; set; }
        public List<Repuestos> RepuestosAsociados { get; set; }
    }
}
