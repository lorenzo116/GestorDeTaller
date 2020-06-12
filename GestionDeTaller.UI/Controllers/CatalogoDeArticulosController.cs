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
        public ActionResult Detalles(int Id)
        {


            Articulo articulo;
            DetallesDelArticulo detallesDelArticulo = new DetallesDelArticulo();
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            detallesDelArticulo.Nombre = articulo.Nombre;
            detallesDelArticulo.Marca = articulo.Marca;
            detallesDelArticulo.Descripcion = articulo.Descripcion;
            

            return View(detallesDelArticulo);
        }

        // GET: Articulos/Agregar
        public ActionResult Agregar()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Articulo libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    RepositorioDelTaller.AgregarArticulo(libro);
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

        // GET: Articulos/Delete/5
       
    }
}