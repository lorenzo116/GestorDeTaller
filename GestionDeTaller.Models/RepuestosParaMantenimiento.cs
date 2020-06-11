using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeTaller.Models
{
    public class RepuestosParaMantenimiento
    {
        public int Id { get; set; }

        public int Id_Mantenimiento { get; set; }

        public int Id_Repuesto { get; set; }
    }
}
