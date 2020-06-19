using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace GestionDeTaller.BL
{
    public interface IRepositorioDelTaller
    {
        public void AgregarArticulo(Articulo articulo);
        public void AgregarMantenimiento(Mantenimientos mantenimiento);
        public void AgregarMantenimientoAUnaOrden(int Id_Mantenimiento, int Id_Orden);
        public void AgregarOrden(OrdenesDeMantenimiento orden);
        public void AgregarRepuesto(Repuestos repuesto);
        

        public List<Articulo> ObtenerTodosLosArticulos();
        public List<DetalleOrdenesDeMantenimiento> ObtenerTodosLosDetallesDeOrdenes();
        public List<Repuestos> DetallesDeOrdenesDeMantenimiento();
        public List<OrdenesDeMantenimiento> ObtenerTodasLasOrdenes();
        public List<OrdenesDeMantenimiento> ObtenerOrdenesEnProceso();
        public List<OrdenesDeMantenimiento> ObtenerOrdenesTerminadas();
        public List<OrdenesDeMantenimiento> ObtenerOrdenesCanceladas();
        public List<OrdenesDeMantenimiento> ObtenerOrdenesRecibidas();
        public List<Repuestos> ObtenerRepuestosSinAsociar(int Id);
        public List<Repuestos> ObtenerTodosLosRepuestos();
        public List<RepuestosParaMantenimiento> ObtenerTodosLosRepuestosParaMantenimiento();
        public List<Mantenimientos>ObtenerMantenimientosParaUnaOrden(int id);
        public List<Repuestos> ObtenerRepuestosAsociados(Articulo articulo);
        public List<Mantenimientos> ObtenerMantenimientosDeUnArticulo(Articulo articulo);
        public List<Mantenimientos> ObtenerMantenimientosPorRepuesto(List<RepuestosParaMantenimiento> repuestosAsociados);
        public List<Repuestos> ObtenerRepuestosPorMantenimiento(List<RepuestosParaMantenimiento> repuestosAsociados);
        public List<Mantenimientos> ObtenerLosMantenimientos(Articulo articulo);
        public List<RepuestosParaMantenimiento> ObtenerMantenimientosParaRepuestos(int Id);
        public List<RepuestosParaMantenimiento> ObtenerRepuestoParaMantenimientos(int Id);


        public double ObtenerPrecioTotalDeUnMantenimiento(Mantenimientos mantenimiento);
        public double ObtenerCostoDeRepuestosDeMantenimiento(Mantenimientos mantenimiento);
        public int ResumenDeUsoDelRepuesto(int Id);
        public int ResumenDeUsoDelMantenimiento(int id);
        public Articulo ObtenerArticuloPorID(int id);
        public Repuestos ObtenerRepuestoPorID(int id);
        public Mantenimientos ObtenerMantenimientoPorID(int id);
        public OrdenesDeMantenimiento ObtenerOrdenPorID(int id);
        public String ContarOrdenesTerminadas(int id);
        public String ContarOrdenesEnProceso(int id);
        public void EditarArticulo(Articulo articulo);
        public void EditarRepuesto(Repuestos repuesto);
        public void EditarMantenimiento(Mantenimientos Mmntenimiento);
        public void EditarOrden(OrdenesDeMantenimiento orden);

        public void IniciarOrden(OrdenesDeMantenimiento orden);
        public void TerminarOrden(OrdenesDeMantenimiento orden);
        public void CancelarOrden(OrdenesDeMantenimiento orden);
        public void AsociarRepuestoConUnMantenimiento(RepuestosParaMantenimiento repuestoParaAsociar);
        public void DesasociarRepuestoDeMantenimiento(int Id_Repuesto, int Id_Mantenimiento);

    }
}
