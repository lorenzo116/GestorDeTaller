using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GestionDeTaller.Models
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
