﻿using GestionDeTaller.DA;
using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


        public void AgregarArticulo(Articulo articulo)
        {
            ElContextoDeBaseDeDatos.Articulo.Add(articulo);
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

        public List<Repuestos> ObtenerRepuestosAsociados(Articulo articulo)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.Repuestos
                            where c.Id_Articulo == articulo.Id
                            select c;
            return resultado.ToList();
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


        public List<RepuestosParaMantenimiento> ObtenerRepuestoParaMantenimientos(int Id)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.RepuestosParaMantenimiento
                            where c.Id_Repuesto == Id
                            select c;
           return resultado.ToList();
                        
            
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

        public List<OrdenesDeMantenimiento> ObtenerOrdenesDeMantenimiento()
        {
            List<OrdenesDeMantenimiento> laListaDeOrdenes;
            laListaDeOrdenes = ElContextoDeBaseDeDatos.OrdenesDeMantenimiento.ToList();
            return laListaDeOrdenes;
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
    }
}
