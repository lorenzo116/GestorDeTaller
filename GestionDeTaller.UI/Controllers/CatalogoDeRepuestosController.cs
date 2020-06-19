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
    public class CatalogoDeRepuestosController : Controller
    {

        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeRepuestosController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }


        public ActionResult Listar(int Id)
        {
            ViewBag.Id_Articulo = Id;

            List<Repuestos> laListaDeRepuestos = new List<Repuestos>();
            Articulo articulo = new Articulo();
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            laListaDeRepuestos = RepositorioDelTaller.ObtenerRepuestosAsociados(articulo);
            
            return View(laListaDeRepuestos);
        }


        public ActionResult Agregar(int Id_Articulo)
        {            
            Repuestos repuesto = new Repuestos();
            repuesto.Id_Articulo = Id_Articulo;
            ViewBag.Id_Articulo =Id_Articulo;
            return View(repuesto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Repuestos repuesto)
        {
            try
            {
                if (ModelState.IsValid)
                {
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


        public ActionResult Editar(int Id)
        {
            Repuestos Repuesto = RepositorioDelTaller.ObtenerRepuestoPorID(Id);
            ViewBag.Id_Articulo = Repuesto.Id_Articulo;
            if (ModelState.IsValid)
            {
                Repuestos repuesto;
                repuesto = RepositorioDelTaller.ObtenerRepuestoPorID(Id);
                return View(repuesto);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Repuestos repuesto)
        {
            
            try
            {
                RepositorioDelTaller.EditarRepuesto(repuesto);

                return RedirectToAction("Listar", new RouteValueDictionary(new
                {
                    controller = "CatalogoDeRepuestos",
                    Action = "Listar",
                    Id = repuesto.Id_Articulo
                }));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DetallesDeRepuesto(int Id)
        {
            
            RepuestoDetallado repuestoDetallado = new RepuestoDetallado();
            Repuestos repuesto = RepositorioDelTaller.ObtenerRepuestoPorID(Id);
            ViewBag.Id_Articulo = repuesto.Id_Articulo;
            Articulo articulo = RepositorioDelTaller.ObtenerArticuloPorID(repuesto.Id_Articulo);
            repuestoDetallado.Nombre = repuesto.Nombre;
            repuestoDetallado.Precio = repuesto.Precio;
            repuestoDetallado.Descripcion = repuesto.Descripcion;
            repuestoDetallado.ArticuloAsociado = articulo;
            List<RepuestosParaMantenimiento> repuestosAsociados;
            repuestosAsociados = RepositorioDelTaller.ObtenerMantenimientosParaRepuestos(Id);
            repuestoDetallado.MantenimientosAsociados = RepositorioDelTaller.ObtenerMantenimientosPorRepuesto(repuestosAsociados);
            repuestoDetallado.ResumenDeUso = RepositorioDelTaller.resumenDeUsoDelRepuesto(Id);

            return View(repuestoDetallado);
        }

        public ActionResult VolverADetallesDeRepuesto(int id) {
            return RedirectToAction("Listar", new RouteValueDictionary(new
            {
                controller = "CatalogoDeRepuestos",
                Action = "Listar",
                Id = id
            }));
        }
    }
}