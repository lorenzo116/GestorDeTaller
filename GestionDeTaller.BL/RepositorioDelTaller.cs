using GestionDeTaller.DA;
using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.WebPages.Html;

namespace GestionDeTaller.BL
{
    public class RepositorioDelTaller : IRepositorioDelTaller
    {
        private ContextoDeBaseDeDatos ElContextoDeBaseDeDatos;
        public RepositorioDelTaller(ContextoDeBaseDeDatos contexto)
        {
            ElContextoDeBaseDeDatos = contexto;

        }

        
        public List<Articulo> ObtenerTodosLosArticulos()
        {
            List<Articulo> laListaDeArticulos;
            laListaDeArticulos = ElContextoDeBaseDeDatos.Articulo.ToList();
            return laListaDeArticulos;
        }

        public List<OrdenesDeMantenimiento> ObtenerTodasLasOrdenes()
        {
            List<OrdenesDeMantenimiento> laListaDeOrdenes;
            laListaDeOrdenes = ElContextoDeBaseDeDatos.OrdenesDeMantenimiento.ToList();
            return laListaDeOrdenes;
        }

        public List<Repuestos> ObtenerTodosLosRepuestos()
        {
            List<Repuestos> laListaDeRepuestos;
            laListaDeRepuestos = ElContextoDeBaseDeDatos.Repuestos.ToList();
            return laListaDeRepuestos;
        }

        public List<RepuestosParaMantenimiento> ObtenerTodosLosRepuestosParaMantenimiento()
        {
            List<RepuestosParaMantenimiento> laListaDeRepuestosParaMantenimiento;
            laListaDeRepuestosParaMantenimiento = ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.ToList();
            return laListaDeRepuestosParaMantenimiento;
        }


        public List<DetalleOrdenesDeMantenimiento> ObtenerTodosLosDetallesDeOrdenes()
        {
            List<DetalleOrdenesDeMantenimiento> laListaDeDetalleDeOrdenes;
            laListaDeDetalleDeOrdenes = ElContextoDeBaseDeDatos.DetalleOrdenesDeMantenimiento.ToList();
            return laListaDeDetalleDeOrdenes;
        }

        public void AgregarArticulo(Articulo articulo)
        {
            ElContextoDeBaseDeDatos.Articulo.Add(articulo);
            ElContextoDeBaseDeDatos.SaveChanges();
        }
        public void AgregarOrden(OrdenesDeMantenimiento orden)
        {
            orden.Estado = Estado.Recibida;
            orden.FechaDeIngreso = DateTime.Now;
            ElContextoDeBaseDeDatos.OrdenesDeMantenimiento.Add(orden);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void AgregarRepuesto(Repuestos repuesto)
        {
            ElContextoDeBaseDeDatos.Repuestos.Add(repuesto);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public Articulo ObtenerArticuloPorID(int id)
        {
            Articulo articulo;
            articulo = ElContextoDeBaseDeDatos.Articulo.Find(id);
            return articulo;

        }

        public Repuestos ObtenerRepuestoPorID(int id)
        {
            Repuestos repuesto;
            repuesto = ElContextoDeBaseDeDatos.Repuestos.Find(id);
            return repuesto;

        }

        public Mantenimientos ObtenerMantenimientoPorID(int id)
        {
            Mantenimientos mantenimiento;
            mantenimiento = ElContextoDeBaseDeDatos.Mantenimientos.Find(id);
            return mantenimiento;

        }

        public List<Mantenimientos> ObtenerMantenimientosPorRepuesto(List<RepuestosParaMantenimiento> repuestosAsociados)
        {
            List<Mantenimientos> listaDeMantenimientos = new List<Mantenimientos>();
            Mantenimientos mantenimiento;
            foreach (var asociacion in repuestosAsociados)
            {
                mantenimiento = ObtenerMantenimientoPorID(asociacion.Id_Mantenimiento);
                listaDeMantenimientos.Add(mantenimiento);
            }
            return listaDeMantenimientos;
        }

        public List<RepuestosParaMantenimiento> ObtenerMantenimientosParaRepuestos(int Id)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.RepuestosParaMantenimiento
                            where c.Id_Repuesto == Id
                            select c;
            return resultado.ToList();


        }

        public List<RepuestosParaMantenimiento> ObtenerRepuestoParaMantenimientos(int Id)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.RepuestosParaMantenimiento
                            where c.Id_Mantenimiento == Id
                            select c;
            return resultado.ToList();


        }

        
        public List<Repuestos> ObtenerRepuestosPorMantenimiento(List<RepuestosParaMantenimiento> repuestosAsociados)
        {
            List<Repuestos> listaDeRepuestos = new List<Repuestos>();
            Repuestos repuesto;
            foreach (var asociacion in repuestosAsociados)
            {
                repuesto = ObtenerRepuestoPorID(asociacion.Id_Repuesto);
                listaDeRepuestos.Add(repuesto);
            }
            return listaDeRepuestos;
        }

        public double ObtenerPrecioTotalDeUnMantenimiento(Mantenimientos mantenimiento) 
        {
            double precioTotal = 0;
            List<RepuestosParaMantenimiento> repuestosAsociados;
            List<Repuestos> repuestos;

            repuestosAsociados = ObtenerRepuestoParaMantenimientos(mantenimiento.Id);
            repuestos = ObtenerRepuestosPorMantenimiento(repuestosAsociados);
            foreach (var repuesto in repuestos)
            {
                precioTotal += repuesto.Precio;

            }
            precioTotal += mantenimiento.CostoFijo;
            return precioTotal;
        }
        public double ObtenerCostoDeRepuestosDeMantenimiento(Mantenimientos mantenimiento)
        {
            double CostoDeRepuestos = 0;
            List<RepuestosParaMantenimiento> repuestosAsociados;
            List<Repuestos> repuestos;

            repuestosAsociados = ObtenerRepuestoParaMantenimientos(mantenimiento.Id);
            repuestos = ObtenerRepuestosPorMantenimiento(repuestosAsociados);

            foreach (var repuesto in repuestos)
            {
                CostoDeRepuestos = CostoDeRepuestos + repuesto.Precio;
            }
            return CostoDeRepuestos;
        }

        public List<Mantenimientos> ObtenerMantenimientosParaUnaOrden(int id_Orden)
        {
            OrdenesDeMantenimiento orden;
            Articulo articulo;
            List<Mantenimientos> listaDeMantenimientos;
            
            orden = ObtenerOrdenPorID(id_Orden);
            articulo = ObtenerArticuloPorID(orden.Id_Articulo);
            listaDeMantenimientos = ObtenerMantenimientosDeUnArticulo(articulo);
            
            foreach (var mantenimiento in listaDeMantenimientos)
            {
                mantenimiento.PrecioTotal = ObtenerPrecioTotalDeUnMantenimiento(mantenimiento);
            }
            foreach (var mantenimiento in listaDeMantenimientos) //Prueba
            {
                mantenimiento.CostoDeRepuestos = ObtenerCostoDeRepuestosDeMantenimiento(mantenimiento);
            }

            return listaDeMantenimientos;
        }
        public void Editar(Articulo articulo)
        {
            Articulo articuloParaEditar;
            articuloParaEditar = ObtenerArticuloPorID(articulo.Id);

            articuloParaEditar.Nombre = articulo.Nombre;
            articuloParaEditar.Marca = articulo.Marca;
            articuloParaEditar.Descripcion = articulo.Descripcion;

            ElContextoDeBaseDeDatos.Articulo.Update(articuloParaEditar);
            ElContextoDeBaseDeDatos.SaveChanges();

        }

        public void EditarRepuesto(Repuestos repuesto)
        {
            Repuestos repuestoParaEditar;
            repuestoParaEditar = ObtenerRepuestoPorID(repuesto.Id);

            repuestoParaEditar.Nombre = repuesto.Nombre;
            repuestoParaEditar.Precio = repuesto.Precio;
            repuestoParaEditar.Descripcion = repuesto.Descripcion;

            ElContextoDeBaseDeDatos.Repuestos.Update(repuestoParaEditar);
            ElContextoDeBaseDeDatos.SaveChanges();

        }

        public void EditarMantenimiento(Mantenimientos mantenimiento)
        {
            Mantenimientos mantenimientoParaEditar;
            mantenimientoParaEditar = ObtenerMantenimientoPorID(mantenimiento.Id);

            mantenimientoParaEditar.Descripcion = mantenimiento.Descripcion;
            mantenimientoParaEditar.CostoFijo = mantenimiento.CostoFijo;
            ElContextoDeBaseDeDatos.Mantenimientos.Update(mantenimientoParaEditar);
            ElContextoDeBaseDeDatos.SaveChanges();

        }
        public List<Repuestos> ObtenerRepuestosAsociados(Articulo articulo)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.Repuestos
                            where c.Id_Articulo == articulo.Id
                            select c;
            return resultado.ToList();
        }

        public List<Mantenimientos> ObtenerMantenimientosDeUnArticulo(Articulo articulo)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.Mantenimientos
                            where c.Id_Articulo == articulo.Id
                            select c;
            return resultado.ToList();
        }

        public int resumenDeUsoDelMantenimiento(int id)
        {
            List<OrdenesDeMantenimiento> ordenesAsociadas = new List<OrdenesDeMantenimiento>();
            List<DetalleOrdenesDeMantenimiento> detalleOrdenesDeMantenimientos;
            OrdenesDeMantenimiento ordeneDeMantenimiento;

            detalleOrdenesDeMantenimientos = ObtenerTodosLosDetallesDeOrdenes();

            foreach (var detalle in detalleOrdenesDeMantenimientos)
            {
                if (detalle.Id_Mantenimiento==id) 
                {
                    ordeneDeMantenimiento = ObtenerOrdenPorID(detalle.Id_OrdenesDeMantenimiento);
                    ordenesAsociadas.Add(ordeneDeMantenimiento);

                }

            }
            return ordenesAsociadas.Count;
        }

        public int resumenDeUsoDelRepuesto(int id) {
        
        List<RepuestosParaMantenimiento> listaDeMantenimientosAsociados;
        List<DetalleOrdenesDeMantenimiento> detalleOrdenesDeMantenimientos;
        List<OrdenesDeMantenimiento> ordenesAsociadas = new List<OrdenesDeMantenimiento>();
        OrdenesDeMantenimiento ordeneDeMantenimiento;

        listaDeMantenimientosAsociados = ObtenerMantenimientosParaRepuestos(id);
        detalleOrdenesDeMantenimientos = ObtenerTodosLosDetallesDeOrdenes();
         
        foreach (var mantenimiento in listaDeMantenimientosAsociados)
        {
            foreach (var orden in detalleOrdenesDeMantenimientos)
            {
                if (mantenimiento.Id_Mantenimiento == orden.Id_Mantenimiento) 
                {
                    ordeneDeMantenimiento = ObtenerOrdenPorID(orden.Id_OrdenesDeMantenimiento);
                    ordenesAsociadas.Add( ordeneDeMantenimiento);
                }
            }
        }
        return ordenesAsociadas.Count;
        }

        public List<Repuestos> DetallesDeOrdenesDeMantenimiento(){

            List<Repuestos> laListaDeDetalles;
            laListaDeDetalles = ElContextoDeBaseDeDatos.Repuestos.ToList();
            return laListaDeDetalles;


        }

        public String ContarOrdenesTerminadas(int id)
        {
            var laLista = from c in ElContextoDeBaseDeDatos.OrdenesDeMantenimiento
                          where c.Id_Articulo == id
                          select c;
            laLista.ToList();
            int ordenesTerminadas = 0;
            foreach (var orden in laLista)
            {
                if (orden.Estado == Estado.Terminada)
                {
                    ordenesTerminadas++;
                }
            }
            return ordenesTerminadas.ToString();
          
        }

        public String ContarOrdenesEnProceso(int id)
        {
            var laLista = from c in ElContextoDeBaseDeDatos.OrdenesDeMantenimiento
                          where c.Id_Articulo == id
                          select c;
            laLista.ToList();
            int ordenesEnProceso = 0;
            foreach (var orden in laLista)
            {
                if (orden.Estado == Estado.Proceso)
                {
                    ordenesEnProceso++;
                }
            }
            return ordenesEnProceso.ToString();
        }
        
        public List<Mantenimientos> ObtenerLosMantenimientos(Articulo articulo)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.Mantenimientos
                            where c.Id_Articulo == articulo.Id
                            select c;
            return resultado.ToList();
        }

        public void AgregarMantenimiento(Mantenimientos mantenimiento)
        {
            ElContextoDeBaseDeDatos.Mantenimientos.Add(mantenimiento);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

       
        public OrdenesDeMantenimiento ObtenerOrdenPorID(int id)
        {
            OrdenesDeMantenimiento orden;
            orden = ElContextoDeBaseDeDatos.OrdenesDeMantenimiento.Find(id);
            return orden;
        }
        public void EditarOrden(OrdenesDeMantenimiento orden)
        {
            OrdenesDeMantenimiento OrdenParaEditar;
            OrdenParaEditar = ObtenerOrdenPorID(orden.Id);

            OrdenParaEditar.NombreDelCliente = orden.NombreDelCliente;
            OrdenParaEditar.DescripcionDelProblema = orden.DescripcionDelProblema;
            OrdenParaEditar.MontoDeAdelanto = orden.MontoDeAdelanto;

            ElContextoDeBaseDeDatos.OrdenesDeMantenimiento.Update(OrdenParaEditar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void IniciarOrden(OrdenesDeMantenimiento orden)
        {
            OrdenesDeMantenimiento OrdenParaEnviar;
            OrdenParaEnviar = ObtenerOrdenPorID(orden.Id);
            OrdenParaEnviar.Estado = Estado.Proceso;
            OrdenParaEnviar.FechaDeInicio = DateTime.Now;
            ElContextoDeBaseDeDatos.OrdenesDeMantenimiento.Update(OrdenParaEnviar);
            ElContextoDeBaseDeDatos.SaveChanges();

        }
        public List<OrdenesDeMantenimiento> ObtenerOrdenesEnProceso()
        {
            var resultado = from c in ElContextoDeBaseDeDatos.OrdenesDeMantenimiento
                            where c.Estado == Estado.Proceso

                            select c;
            return resultado.ToList();
        }
        public List<OrdenesDeMantenimiento> ObtenerOrdenesTerminadas()
        {
            var resultado = from c in ElContextoDeBaseDeDatos.OrdenesDeMantenimiento
                            where c.Estado == Estado.Terminada

                            select c;
            return resultado.ToList();
        }

        public List<OrdenesDeMantenimiento> ObtenerOrdenesCanceladas()
        {
            var resultado = from c in ElContextoDeBaseDeDatos.OrdenesDeMantenimiento
                            where c.Estado == Estado.Cancelada

                            select c;
            return resultado.ToList();
        }

        public void TerminarOrden(OrdenesDeMantenimiento orden)
        {
            OrdenesDeMantenimiento OrdenParaTerminar;
            OrdenParaTerminar = ObtenerOrdenPorID(orden.Id);
            OrdenParaTerminar.Estado = Estado.Terminada;
            OrdenParaTerminar.FechaDeFinalizacion = DateTime.Now;
            ElContextoDeBaseDeDatos.OrdenesDeMantenimiento.Update(OrdenParaTerminar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void CancelarOrden(OrdenesDeMantenimiento orden)
        {
            OrdenesDeMantenimiento OrdenParaTerminar;
            OrdenParaTerminar = ObtenerOrdenPorID(orden.Id);
            OrdenParaTerminar.Estado = Estado.Cancelada;
            OrdenParaTerminar.MotivoDeCancelacion = orden.MotivoDeCancelacion;
            ElContextoDeBaseDeDatos.OrdenesDeMantenimiento.Update(OrdenParaTerminar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public List<RepuestosParaMantenimiento> ObtenerRepuestosConMantenimientos() 
        {
            List<RepuestosParaMantenimiento> laListaDeRepuestosConMantenimiento;
            laListaDeRepuestosConMantenimiento = ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.ToList();
            return laListaDeRepuestosConMantenimiento;
        }

        public List<Repuestos> ObtenerRepuestosSinAsociar(int Id)
        {
            Mantenimientos mantenimiento;
            mantenimiento = ObtenerMantenimientoPorID(Id);
            int Id_Articulo = mantenimiento.Id_Articulo;

            Articulo articulo = ObtenerArticuloPorID(Id_Articulo);
            List<Repuestos> TodosLosRepuestos = new List<Repuestos>();
            List<Repuestos> repuestosSinMantenimiento = new List<Repuestos>();
            List<Repuestos> RepuestosDelArticulo;
            List<RepuestosParaMantenimiento> listaDeRepuestosConMantenimiento;

            repuestosSinMantenimiento = ObtenerRepuestosAsociados(articulo);

            
            listaDeRepuestosConMantenimiento = ObtenerRepuestosConMantenimientos();

            RepuestosDelArticulo = ObtenerRepuestosAsociados(articulo);
            TodosLosRepuestos = ObtenerRepuestosAsociados(articulo);
            
            foreach (var repuesto in TodosLosRepuestos)
            {
                foreach (var repuestoConMantenimiento in listaDeRepuestosConMantenimiento)
                {
                   if (repuesto.Id == repuestoConMantenimiento.Id_Repuesto)
                        {
                            repuestosSinMantenimiento.Remove(repuesto);
                        }
                }
            }
            return repuestosSinMantenimiento;
        }

        public void AsociarRepuestoConUnMantenimiento(RepuestosParaMantenimiento repuestoParaAsociar)
        {
            ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.Add(repuestoParaAsociar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void DesasociarRepuestoDeMantenimiento(int Id_Repuesto, int Id_Mantenimiento) 
        {
            List<RepuestosParaMantenimiento> repuestosParaMantenimientos;
            repuestosParaMantenimientos = ObtenerTodosLosRepuestosParaMantenimiento();
            foreach (var repuestoParaMantenimiento in repuestosParaMantenimientos)
            {
                if (repuestoParaMantenimiento.Id_Repuesto == Id_Repuesto) 
                {
                    ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.Remove(repuestoParaMantenimiento);
                    ElContextoDeBaseDeDatos.SaveChanges();
                }

            }
            
        }
        public void AgregarMantenimientoAUnaOrden(int Id_Mantenimiento, int Id_Orden) 
        {
            Boolean existe = false;
            List<DetalleOrdenesDeMantenimiento> detallesDeOrdenes;
            detallesDeOrdenes = ObtenerTodosLosDetallesDeOrdenes();
            foreach (var detalle in detallesDeOrdenes)
            {
                if (detalle.Id_OrdenesDeMantenimiento==Id_Orden) 
                {
                    if (detalle.Id_Mantenimiento==Id_Mantenimiento) {
                        existe =true;
                        break;
                    }                
                }
            }
            if (existe==false) {
                DetalleOrdenesDeMantenimiento detallesDeOrden = new DetalleOrdenesDeMantenimiento();
                detallesDeOrden.Id_Mantenimiento = Id_Mantenimiento;
                detallesDeOrden.Id_OrdenesDeMantenimiento = Id_Orden;
                ElContextoDeBaseDeDatos.DetalleOrdenesDeMantenimiento.Add(detallesDeOrden);
                ElContextoDeBaseDeDatos.SaveChanges(); }


        }

        public List<OrdenesDeMantenimiento> ObtenerOrdenesRecibidas()
        {
            var resultado = from c in ElContextoDeBaseDeDatos.OrdenesDeMantenimiento
                            where c.Estado == Estado.Recibida

                            select c;
            return resultado.ToList();
        }

        public OrdenesDeMantenimiento DetallesDeRecibidos(OrdenesDeMantenimiento orden)
        {
            OrdenesDeMantenimiento OrdenPorDetallar;
            OrdenPorDetallar = ObtenerOrdenPorID(orden.Id);
            return OrdenPorDetallar;
        }
    }
}
