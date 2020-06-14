﻿using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeTaller.BL
{
    public interface IRepositorioDelTaller
    {
        public List<Articulo> ObtenerTodosLosArticulos();

        public List<Repuestos> DetallesDeOrdenesDeMantenimiento();

        public List<OrdenesDeMantenimiento> ObtenerOrdenesDeMantenimiento();
        public List<OrdenesDeMantenimiento> ObtenerOrdenesEnProceso();
        public List<OrdenesDeMantenimiento> ObtenerOrdenesTerminadas();
        public List<OrdenesDeMantenimiento> ObtenerOrdenesCanceladas();

        public List<Repuestos> ObtenerRepuestosAsociados(Articulo articulo);

        public void AgregarArticulo(Articulo articulo);
        public void AgregarRepuesto(Repuestos repuesto);

        public Articulo ObtenerArticuloPorID(int id);

        public Repuestos ObtenerRepuestoPorID(int id);

        public Mantenimientos ObtenerMantenimientoPorID(int id);

        public List<Mantenimientos> ObtenerMantenimientosPorRepuesto(List<RepuestosParaMantenimiento> repuestosAsociados);
        public String ContarOrdenesTerminadas(int id);

        public String ContarOrdenesEnProceso(int id);

        public void Editar(Articulo articulo);

        public void EditarRepuesto(Repuestos repuesto);

        public List<Mantenimientos> ObtenerLosMantenimientos(Articulo articulo);

        public List<RepuestosParaMantenimiento> ObtenerRepuestoParaMantenimientos(int Id);
        public void AgregarMantenimiento(Mantenimientos mantenimiento);
        public OrdenesDeMantenimiento ObtenerOrdenPorID(int id);
        public void EditarOrden(OrdenesDeMantenimiento orden);
        public void IniciarOrden(OrdenesDeMantenimiento orden);
        public void TerminarOrden(OrdenesDeMantenimiento orden);
        public void CancelarOrden(OrdenesDeMantenimiento orden);

    }
}
