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

        public ActionResult Listar(int Id)
        {
            ViewBag.Id_Articulo = Id;

            List<Mantenimientos> laListaDeMantenimientos;
            Articulo articulo;
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            laListaDeMantenimientos = RepositorioDelTaller.ObtenerLosMantenimientos(articulo);

            return View(laListaDeMantenimientos);
        }

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
            mantenimientoDetallado.ResumenDeUso = RepositorioDelTaller.ResumenDeUsoDelMantenimiento(Id);
            return View(mantenimientoDetallado);
        }

        public ActionResult AgregarMantenimiento(int Id_Articulo)
        {
            
            Mantenimientos mantenimiento = new Mantenimientos();
            mantenimiento.Id_Articulo = Id_Articulo;
            ViewBag.Id_Articulo = Id_Articulo;
            return View(mantenimiento);
        }

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
    }
}