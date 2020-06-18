using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeTaller.UI.Models
{
    public class OrdenDetallada
    {
        public string NombreDelCliente { get; set; }

        public string DescripcionDelProblema { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public decimal MontoDeAdelanto { get; set; }

        public DateTime? FechaDeInicio { get; set; }

        public DateTime? FechaDeFinalizacion { get; set; }

        public string? MotivoDeCancelacion { get; set; }

        public string NombreArticulo { get; set; }

        public string MarcaArticulo { get; set; }

        public List<Mantenimientos> ListaDeMantenimientosAsociados { get; set; }
    }
}
