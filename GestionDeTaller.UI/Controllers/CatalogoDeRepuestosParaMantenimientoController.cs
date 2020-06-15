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
    public class CatalogoDeRepuestosParaMantenimientoController : Controller
    {
        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeRepuestosParaMantenimientoController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }

        // GET: CatalogoDeRepuestosParaMantenimiento
        public ActionResult Listar(int Id)
        {
            ViewBag.Id_Mantenimiento = Id;
            List<Repuestos> laListaDeRepuestos = new List<Repuestos>();
            List<RepuestosParaMantenimiento> laListaDeRepuestosYMantenimientos = new List<RepuestosParaMantenimiento>();
            laListaDeRepuestosYMantenimientos = RepositorioDelTaller.ObtenerRepuestoParaMantenimientos(Id);
            laListaDeRepuestos = RepositorioDelTaller.ObtenerRepuestosPorMantenimiento(laListaDeRepuestosYMantenimientos);
            return View(laListaDeRepuestos);
        }

        // GET: CatalogoDeRepuestosParaMantenimiento/Details/5
        public ActionResult Details(int Id)
        {
            List<RepuestosParaMantenimiento> laLista;
            laLista = RepositorioDelTaller.ObtenerRepuestoParaMantenimientos(Id);
            return View();
        }

        // GET: CatalogoDeRepuestosParaMantenimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogoDeRepuestosParaMantenimiento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoDeRepuestosParaMantenimiento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogoDeRepuestosParaMantenimiento/Edit/5
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

        // GET: CatalogoDeRepuestosParaMantenimiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogoDeRepuestosParaMantenimiento/Delete/5
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