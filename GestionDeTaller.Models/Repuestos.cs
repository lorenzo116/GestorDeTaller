using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeTaller.Models
{
    public class Repuestos
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Id_Articulo { get; set; }

        public float Precio { get; set; }

        public string Descripcion { get; set; }
    }
}
