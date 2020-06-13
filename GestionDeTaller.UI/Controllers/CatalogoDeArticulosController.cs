using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using GestionDeTaller.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeTaller.UI.Controllers
{
    public class CatalogoDeArticulosController : Controller
    {
        private  IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeArticulosController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }

        // GET: Articulos
        public ActionResult Listar()
        {
            List<Articulo> laLista;
            laLista = RepositorioDelTaller.ObtenerTodosLosArticulos();

            return View(laLista);
        }

        // GET: Articulos/Detalles/5
    

        public ActionResult DetallesDeArticulo(int Id)
        {
            Articulo articulo;
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            ArticuloDetallado articuloDetallado = new ArticuloDetallado();
            List<ArticuloDetallado> laListaCompleta = new List<ArticuloDetallado>();
            List<Repuestos> laLista;
            laLista= RepositorioDelTaller.ObtenerLosRepuestos(articulo);
            articuloDetallado.Nombre = articulo.Nombre;
            articuloDetallado.Marca = articulo.Marca;
            articuloDetallado.Descripcion = articulo.Descripcion;
            Repuestos repuesto;
            if (laLista.Count>0) {
                repuesto = laLista[0];
                articuloDetallado.NombreDelRepuesto = repuesto.Nombre;
                articuloDetallado.PrecioDelRepuesto = repuesto.Precio;
                laLista.RemoveAt(0);
            }        
            string ordenesTerminadas, ordenesEnProceso;
            ordenesTerminadas = RepositorioDelTaller.ObtenerOrdenesTerminadas(Id);
            ordenesEnProceso = RepositorioDelTaller.ObtenerOrdenesEnProceso(Id);
            articuloDetallado.CantidadDeOrdenesEnProceso = ordenesEnProceso;
            articuloDetallado.CantidadDeOrdenesTerminadas = ordenesTerminadas;
            laListaCompleta.Add(articuloDetallado);

            foreach (var repuestos in laLista)
            {
                articuloDetallado = new ArticuloDetallado();
                articuloDetallado.NombreDelRepuesto = repuestos.Nombre;
                articuloDetallado.PrecioDelRepuesto = repuestos.Precio;
                laListaCompleta.Add(articuloDetallado);

            }
            return View(laListaCompleta);
        }

        // GET: Articulos/Agregar
        public ActionResult AgregarArticulo()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarArticulo(Articulo articulo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    RepositorioDelTaller.AgregarArticulo(articulo);
                    return RedirectToAction(nameof(Listar));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulos/Edit/5
        // GET: Articulos/Editar/
        public ActionResult Editar(int Id)
        {
            if (ModelState.IsValid)
            {
                Articulo articulo;
                articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
                return View(articulo);
            }
            else
            {
                return View();
            }
        }
        // POST: Articulos/Editar/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Articulo articulo)
        {
            try
            {
                RepositorioDelTaller.Editar(articulo);

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }




        // GET: Articulos/Agregar
        public ActionResult AgregarRepuesto()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarRepuesto(Repuestos repuesto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    RepositorioDelTaller.AgregarRepuesto(repuesto);
                    return RedirectToAction(nameof(Listar));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

    }
}