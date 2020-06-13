using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using GestionDeTaller.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

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
            ArticuloDetallado articuloDetallado = new ArticuloDetallado();
            Articulo articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            articuloDetallado.Nombre = articulo.Nombre;
            articuloDetallado.Marca = articulo.Marca;
            articuloDetallado.Descripcion = articulo.Descripcion;
            articuloDetallado.CantidadDeOrdenesEnProceso = RepositorioDelTaller.ContarOrdenesEnProceso(Id);
            articuloDetallado.CantidadDeOrdenesTerminadas = RepositorioDelTaller.ContarOrdenesTerminadas(Id);
            articuloDetallado.repuestosAsosiados = RepositorioDelTaller.ObtenerRepuestosAsociados(articulo);

            return View(articuloDetallado);
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


        public ActionResult DetallesDeRepuesto(int id)
        {
            return RedirectToAction("Listar", new RouteValueDictionary(new
            {
                controller = "CatalogoDeRepuestos",
                Action = "Listar",
                Id = id
            })); 
        }

        
  
        public ActionResult DetalleMantenimientos()
        {
                return RedirectToAction("Listar", "CatalogoDeMantenimientos");
        }

    }
}