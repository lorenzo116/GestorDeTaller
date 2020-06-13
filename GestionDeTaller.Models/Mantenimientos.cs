using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace GestionDeTaller.Models
{
    public class Mantenimientos
    {
        public int Id { get; set; }
        public int Id_Articulo { get; set; }

        public string Descripcion { get; set; }

        public double CostoFijo { get; set; }
    }
}
