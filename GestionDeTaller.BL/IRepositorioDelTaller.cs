using GestionDeTaller.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeTaller.BL
{
    public interface IRepositorioDelTaller
    {
        public List<Articulo> ObtenerTodosLosArticulos();

        public List<Repuestos> ObtenerLosRepuestos(int id_articulo);

        public void AgregarArticulo(Articulo articulo);

        public Articulo ObtenerArticuloPorID(int id);

        public void Editar(Articulo articulo);
    }
}
