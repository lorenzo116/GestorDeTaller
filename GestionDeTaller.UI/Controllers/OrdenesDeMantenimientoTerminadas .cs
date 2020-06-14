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
    public class OrdenesDeMantenimientoTerminadas : Controller
    {

        private readonly IRepositorioDelTaller Repositorio;

        public OrdenesDeMantenimientoTerminadas(IRepositorioDelTaller repositorio)
        {
            Repositorio = repositorio;
        }

        // GET: OrdenesDeMantenimientoTerminadas
        public ActionResult Listar()
        {
            List<OrdenesDeMantenimiento> ordenes;

            ordenes = Repositorio.ObtenerOrdenesTerminadas();

            return View(ordenes);
        }




        // GET: OrdenesDeMantenimientoTerminadas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenesDeMantenimientoTerminadas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoTerminadas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenesDeMantenimientoTerminadas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoTerminadas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenesDeMantenimientoTerminadas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoTerminadas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
