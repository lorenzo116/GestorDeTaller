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

            articuloParaEditar.Nombre= articulo.Nombre;
            articuloParaEditar.Marca = articulo.Marca;
            articuloParaEditar.Descripcion = articulo.Descripcion;

            ElContextoDeBaseDeDatos.Articulo.Update(articuloParaEditar);
            ElContextoDeBaseDeDatos.SaveChanges();

        }

        public List<Repuestos> ObtenerLosRepuestos(int id_articulo)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.Repuestos
                            where c.Id_Articulo == id_articulo
                            select c;
            return resultado.ToList();    
        }

       
    }
}
