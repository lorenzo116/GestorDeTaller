using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GestionDeTaller.UI.Controllers
{
    public class CatalogoDeRepuestosController : Controller
    {

        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeRepuestosController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }




        // GET: CatalogoDeRepuestos
        public ActionResult Listar(int Id)
        {
            ViewBag.Id_Articulo = Id;
            List<Repuestos> laLista = new List<Repuestos>();
            Articulo articulo = new Articulo();
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            laLista = RepositorioDelTaller.ObtenerRepuestosAsociados(articulo);
            return View(laLista);
        }

        // GET: CatalogoDeRepuestos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatalogoDeRepuestos/Create
        public ActionResult Agregar(int Id_Articulo)
        {            
            Repuestos repuesto = new Repuestos();
            repuesto.Id_Articulo = Id_Articulo;
            return View(repuesto);
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Repuestos repuesto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    RepositorioDelTaller.AgregarRepuesto(repuesto);
                    return RedirectToAction("Listar", new RouteValueDictionary(new
                    {
                        controller = "CatalogoDeRepuestos",
                        Action = "Listar",
                        Id = repuesto.Id_Articulo
                    }));
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

        // GET: CatalogoDeRepuestos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogoDeRepuestos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoDeRepuestos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogoDeRepuestos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}