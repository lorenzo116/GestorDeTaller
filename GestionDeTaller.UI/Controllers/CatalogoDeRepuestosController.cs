using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeTaller.UI.Controllers
{
    public class CatalogoDeRepuestosController : Controller
    {
        // GET: CatalogoDeRepuestos
        public ActionResult Listar()
        {
            return View();
        }

        // GET: CatalogoDeRepuestos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatalogoDeRepuestos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogoDeRepuestos/Create
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