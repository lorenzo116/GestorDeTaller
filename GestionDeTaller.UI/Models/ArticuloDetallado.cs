using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeTaller.UI.Models
{
    public class ArticuloDetallado
    {

        public string Nombre { get; set; }

        public string Marca { get; set; }

        public string Descripcion { get; set; }

        [Display(Name = "Ordenes Terminadas")]
        public string CantidadDeOrdenesTerminadas { get; set; }

        [Display(Name = "Ordenes En Proceso")]
        public string CantidadDeOrdenesEnProceso { get; set; }
        public List<Repuestos> repuestosAsosiados { get; set; }


    }
}
