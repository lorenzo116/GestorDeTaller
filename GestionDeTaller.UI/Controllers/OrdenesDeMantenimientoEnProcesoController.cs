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
    public class OrdenesDeMantenimientoEnProcesoController : Controller
    {
        private readonly IRepositorioDelTaller Repositorio;

        public OrdenesDeMantenimientoEnProcesoController(IRepositorioDelTaller repositorio)
        {
            Repositorio = repositorio;
        } 


        // GET: OrdenesDeMantenimientoEnProceso
        public ActionResult Listar()
        {
            List<OrdenesDeMantenimiento> ordenes;

            ordenes = Repositorio.ObtenerOrdenesEnProceso();

            return View(ordenes);
        }

        // GET: OrdenesDeMantenimientoEnProceso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Terminar(int id)
        {
            if (ModelState.IsValid)
            {
                OrdenesDeMantenimiento orden;
                orden = Repositorio.ObtenerOrdenPorID(id);
                return View(orden);
            }
            else
            {
                return View();
            }
        }

        // POST: OrdenesDeMantenimientoRecibidas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Terminar(OrdenesDeMantenimiento orden)
        {
            try
            {
                Repositorio.TerminarOrden(orden);

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Cancelar(int id)
        {
            if (ModelState.IsValid)
            {
                OrdenesDeMantenimiento orden;
                orden = Repositorio.ObtenerOrdenPorID(id);
                return View(orden);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancelar(OrdenesDeMantenimiento orden)
        {
            try
            {
                Repositorio.CancelarOrden(orden);

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }
    }
}
