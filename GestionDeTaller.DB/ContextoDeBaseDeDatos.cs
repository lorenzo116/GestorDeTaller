using GestionDeTaller.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeTaller.DA
{
    public class ContextoDeBaseDeDatos : DbContext
    {

      
        public ContextoDeBaseDeDatos(DbContextOptions<ContextoDeBaseDeDatos> opciones) : base(opciones)
        {

        }
        public DbSet<Articulo> Articulo { get; set; }

        public DbSet<Repuestos> Repuestos { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<DetalleOrdenesDeMantenimiento> DetallesDeMantenimiento { get; set; }

        public DbSet<Mantenimientos> Mantenimientos { get; set; }

        public DbSet<OrdenesDeMantenimiento> OrdenesDeMantenimiento { get; set; }

        public DbSet<RepuestosParaMantenimiento> RepuestosParaMantenimiento { get; set; }




    }
}
