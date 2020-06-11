using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace GestionDeTaller.Models
{
    public class OrdenesDeMantenimiento
    {
        public int Id { get; set; }

        public string NombreDelCliente { get; set; }

        public Estado Estado { get; set; }

        public string DescripcionDelProblema { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public decimal MontoDeAdelanto { get; set; }

        public int Id_Articulo { get; set; }

        public DateTime FechaDeInicio { get; set; }

        public DateTime FechaDeFinalizacion { get; set; }

        public string MotivoDeCancelacion { get; set; }
    }
}
