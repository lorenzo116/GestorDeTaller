using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeTaller.UI.Models
{
    public class MantenimientoDetallado
    {
        public int Id { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Resumen de uso")]
        public int ResumenDeUso { get; set; }

        public List<Repuestos> RepuestosAsociados { get; set; }
    }
}
