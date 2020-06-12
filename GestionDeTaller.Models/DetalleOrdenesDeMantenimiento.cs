using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeTaller.Models
{
    public class DetalleOrdenesDeMantenimiento
    {
        public int Id { get; set; }
        public int Id_OrdenesDeMantenimiento { get; set; }
        public int Id_Mantenimiento { get; set; }


    }
}
/*
 * 	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_OrdenesDeMantenimiento] [int] NOT NULL,
	[Id_Mantenimiento] [int] NOT NULL,
 */
