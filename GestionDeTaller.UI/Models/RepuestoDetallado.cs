using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
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

        public int ResumenDeUso { get; set; }





    }
}
