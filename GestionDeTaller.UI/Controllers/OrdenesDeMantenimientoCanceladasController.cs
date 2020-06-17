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
    public class OrdenesDeMantenimientoCanceladasController : Controller
    {
        private readonly IRepositorioDelTaller RepositorioDelTaller;

        public OrdenesDeMantenimientoCanceladasController(IRepositorioDelTaller repositorioDeOrdenes)
        {
            RepositorioDelTaller = repositorioDeOrdenes;
        }

        // GET: OrdenesDeMantenimientoCanceladas
        public ActionResult Listar()
        {
            List<OrdenesDeMantenimiento> ordenes;

            ordenes = RepositorioDelTaller.ObtenerOrdenesCanceladas();

            return View(ordenes);
        }

        // GET: OrdenesDeMantenimientoCanceladas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenesDeMantenimientoCanceladas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoCanceladas/Create
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

        // GET: OrdenesDeMantenimientoCanceladas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoCanceladas/Edit/5
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

        // GET: OrdenesDeMantenimientoCanceladas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoCanceladas/Delete/5
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
