using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using GestionDeTaller.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeTaller.UI.Controllers
{
    public class OrdenesDeMantenimientoTerminadasController : Controller
    {

        private readonly IRepositorioDelTaller Repositorio;

        public OrdenesDeMantenimientoTerminadasController(IRepositorioDelTaller repositorio)
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


        public ActionResult Detalles(int Id)
        {
            OrdenDetallada ordenDetallada = new OrdenDetallada();
            OrdenesDeMantenimiento orden = Repositorio.ObtenerOrdenPorID(Id);
            ordenDetallada.NombreDelCliente = orden.NombreDelCliente;
            ordenDetallada.DescripcionDelProblema = orden.DescripcionDelProblema;
            ordenDetallada.FechaDeIngreso = orden.FechaDeIngreso;
            ordenDetallada.FechaDeInicio = orden.FechaDeInicio;
            ordenDetallada.FechaDeFinalizacion = orden.FechaDeFinalizacion;
            ordenDetallada.MontoDeAdelanto = orden.MontoDeAdelanto;
            Articulo articulo = new Articulo();
            articulo = Repositorio.ObtenerArticuloPorID(orden.Id_Articulo);
            ordenDetallada.NombreArticulo = articulo.Nombre;
            ordenDetallada.MarcaArticulo = articulo.Marca;
            ordenDetallada.ListaDeMantenimientosAsociados = Repositorio.ObtenerMantenimientosParaUnaOrden(Id);

            return View(ordenDetallada);
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
