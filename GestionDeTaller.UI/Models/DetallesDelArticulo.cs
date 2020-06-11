using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeTaller.UI.Models
{
    public class DetallesDelArticulo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Marca { get; set; }

        public string Descripcion { get; set; }

        public string NombreDelRepuesto { get; set; }
        
        public float PrecioDelRepuesto { get; set; }

        public int CantidadDeOrdenesTerminadas { get; set; }

        public int CantidadDeOrdenesEnProceso { get; set; }

    }
}
