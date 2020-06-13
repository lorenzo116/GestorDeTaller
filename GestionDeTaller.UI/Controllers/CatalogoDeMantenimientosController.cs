using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeTaller.UI.Controllers
{
    public class CatalogoDeMantenimientosController : Controller
    {
        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeMantenimientosController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }

        // GET: CatalogoDeMantenimientos
        public ActionResult Listar(Articulo articulo)
        {
            List<Mantenimientos> laListaDeMantenimientos;
            laListaDeMantenimientos = RepositorioDelTaller.ObtenerLosMantenimientos(articulo);
            return View(laListaDeMantenimientos);
        }

        // GET: CatalogoDeMantenimientos/Details/5
        public ActionResult Detalles(int id)
        {
            return View();
        }

        // GET: CatalogoDeMantenimientos/Create
        public ActionResult AgregarMantenimiento()
        {
            return View();
        }

        // POST: CatalogoDeMantenimientos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarMantenimiento(Mantenimientos mantenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RepositorioDelTaller.AgregarMantenimiento(mantenimiento);
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

        // GET: CatalogoDeMantenimientos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogoDeMantenimientos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoDeMantenimientos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogoDeMantenimientos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }
    }
}