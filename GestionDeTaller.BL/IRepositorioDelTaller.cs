using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeTaller.BL
{
    public interface IRepositorioDelTaller
    {
        public List<Articulo> ObtenerTodosLosArticulos();

        public List<Repuestos> DetallesDeOrdenesDeMantenimiento();

        public List<Repuestos> ObtenerRepuestosAsociados(Articulo articulo);

        public void AgregarArticulo(Articulo articulo);
        public void AgregarRepuesto(Repuestos repuesto);

        public Articulo ObtenerArticuloPorID(int id);

        public Repuestos ObtenerRepuestoPorID(int id);

        public Mantenimientos ObtenerMantenimientoPorID(int id);

        public String ContarOrdenesTerminadas(int id);

        public String ContarOrdenesEnProceso(int id);

        public void Editar(Articulo articulo);

        public void EditarRepuesto(Repuestos repuesto);

        public List<Mantenimientos> ObtenerLosMantenimientos(Articulo articulo);

        public List<Mantenimientos> ObtenerRepuestoParaMantenimientos(int Id);
        public void AgregarMantenimiento(Mantenimientos mantenimiento);
    }
}
