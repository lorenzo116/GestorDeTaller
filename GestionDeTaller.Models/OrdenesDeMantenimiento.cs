using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace GestionDeTaller.Models
{
    public class OrdenesDeMantenimiento
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Cliente")]
        [Required (ErrorMessage ="El nombre del cliente es requerido")]
        public string NombreDelCliente { get; set; }

        public Estado Estado { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [Display(Name = "Descripción del problema")]
        public string DescripcionDelProblema { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaDeIngreso { get; set; }

        [Display(Name = "Monto de Adelanto")]
        [Required(ErrorMessage = "El monto de adelanto es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El monto de adelanto debe ser 0 o mayor ")]
        public decimal MontoDeAdelanto { get; set; }

        public int Id_Articulo { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime? FechaDeInicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Finalización")]
        public DateTime? FechaDeFinalizacion { get; set; }

        [Display(Name = "Motivo de Cancelación")]
        public string? MotivoDeCancelacion { get; set; }

        [NotMapped, Display(Name = "Días En Proceso")]
        public int DiasEnProceso { get; set; }

        [NotMapped, Display(Name = "Días Trabajados")]
        public int DiasTrabajados { get; set; }
    }
}
