using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Text;

namespace GestionDeTaller.Models
{
    public class OrdenesDeMantenimiento
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Cliente")]
        public string NombreDelCliente { get; set; }

        public Estado Estado { get; set; }

        [Display(Name = "Descripción del problema")]
        public string DescripcionDelProblema { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaDeIngreso { get; set; }

        [Display(Name = "Monto de Adelanto")]
        public decimal MontoDeAdelanto { get; set; }

        public int Id_Articulo { get; set; }

        [Display(Name = "Fecha de Inicio")]
        public DateTime? FechaDeInicio { get; set; }

        [Display(Name = "Fecha de Finalización")]
        public DateTime? FechaDeFinalizacion { get; set; }

        [Display(Name = "Motivo de Cancelación")]
        public string? MotivoDeCancelacion { get; set; }
    }
}
