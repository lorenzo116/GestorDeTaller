using GestionDeTaller.DA;
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
    }
}
