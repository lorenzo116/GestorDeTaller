using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeTaller.UI.Models
{
    public class OrdenDetallada
    {
        [Display(Name = "Nombre Del Cliente")]
        public string NombreDelCliente { get; set; }
        [Display(Name = "Descripción del problema")]
        public string DescripcionDelProblema { get; set; }
        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaDeIngreso { get; set; }
        [Display(Name = "Monto de adelanto")]
        public decimal MontoDeAdelanto { get; set; }
        [Display(Name = "Fecha de inicio")]
        public DateTime? FechaDeInicio { get; set; }
        [Display(Name = "Fecha de finalización")]
        public DateTime? FechaDeFinalizacion { get; set; }
        [Display(Name = "Motivo de cancelación")]
        public string? MotivoDeCancelacion { get; set; }
        [Display(Name = "Nombre del articulo")]
        public string NombreArticulo { get; set; }
        [Display(Name = "Marca del artículo")]
        public string MarcaArticulo { get; set; }
        public List<Mantenimientos> ListaDeMantenimientosAsociados { get; set; }
    }
}
