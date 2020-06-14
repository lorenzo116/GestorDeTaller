using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using GestionDeTaller.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

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
        public ActionResult Listar(int Id)
        {
            ViewBag.Id_Articulo = Id;
            Articulo articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            List<Mantenimientos> laListaDeMantenimientos;
            laListaDeMantenimientos = RepositorioDelTaller.ObtenerLosMantenimientos(articulo);
            return View(laListaDeMantenimientos);
        }

        // GET: CatalogoDeMantenimientos/Detalles/5
        public ActionResult DetallesDeMantenimientos(int Id)
        {
           
            MantenimientoDetallado mantenimientoDetallado = new MantenimientoDetallado();
            Mantenimientos mantenimiento;
            mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id);
            ViewBag.Id_Articulo = mantenimiento.Id_Articulo;
            mantenimientoDetallado.Id = mantenimiento.Id;
            mantenimientoDetallado.Descripcion = mantenimiento.Descripcion;
            List<RepuestosParaMantenimiento> repuestosAsociados;
            repuestosAsociados = RepositorioDelTaller.ObtenerRepuestoParaMantenimientos(Id);
            mantenimientoDetallado.RepuestosAsociados = RepositorioDelTaller.ObtenerRepuestosPorMantenimiento(repuestosAsociados);

            return View(mantenimientoDetallado);
        }

        // GET: CatalogoDeMantenimientos/Create
        public ActionResult AgregarMantenimiento(int Id_Articulo)
        {
            ViewBag.Id_Articulo =Id_Articulo;
            Mantenimientos mantenimiento = new Mantenimientos();
            mantenimiento.Id_Articulo = Id_Articulo;
            return View(mantenimiento);
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
                    return RedirectToAction("Listar", new RouteValueDictionary(new
                    {
                        controller = "CatalogoDeMantenimientos",
                        Action = "Listar",
                        Id = mantenimiento.Id_Articulo
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

        // GET: CatalogoDeMantenimientos/Edit/5
        public ActionResult Editar(int Id)
        {
            Mantenimientos mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id);
            ViewBag.Id_Articulo = mantenimiento.Id_Articulo;
            if (ModelState.IsValid)
            {
                Mantenimientos mantenimientos;
                mantenimientos = RepositorioDelTaller.ObtenerMantenimientoPorID(Id);
                return View(mantenimientos);
            }
            else
            {
                return View();
            }
        }
        // POST: Articulos/Editar/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Mantenimientos mantenimientos)
        {

            try
            {
                RepositorioDelTaller.EditarMantenimiento(mantenimientos);

                return RedirectToAction("Listar", new RouteValueDictionary(new
                {
                    controller = "CatalogoDeMantenimientos",
                    Action = "Listar",
                    Id = mantenimientos.Id_Articulo
                }));
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