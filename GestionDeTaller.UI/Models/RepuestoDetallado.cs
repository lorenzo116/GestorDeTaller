using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeTaller.UI.Models
{
    public class RepuestoDetallado
    {


        public int Id { get; set; }

        public string Nombre { get; set; }
        
        public double Precio { get; set; }
        
        public string Descripcion { get; set; }

        public Articulo ArticuloAsociado { get; set; }

        public List<Mantenimientos> MantenimientosAsociados { get; set; }
        [Display(Name ="Resumen de uso")]
        public int ResumenDeUso { get; set; }





    }
}
