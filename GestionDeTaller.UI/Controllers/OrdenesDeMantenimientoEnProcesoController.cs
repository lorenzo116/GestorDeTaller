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
    public class OrdenesDeMantenimientoEnProcesoController : Controller
    {
        private readonly IRepositorioDelTaller Repositorio;

        public OrdenesDeMantenimientoEnProcesoController(IRepositorioDelTaller repositorio)
        {
            Repositorio = repositorio;
        } 


        public ActionResult Listar()
        {
            List<OrdenesDeMantenimiento> ordenes;

            ordenes = Repositorio.ObtenerOrdenesEnProceso();

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
            ordenDetallada.MontoDeAdelanto = orden.MontoDeAdelanto;
            Articulo articulo = new Articulo();
            articulo = Repositorio.ObtenerArticuloPorID(orden.Id_Articulo);
            ordenDetallada.NombreArticulo = articulo.Nombre;
            ordenDetallada.MarcaArticulo = articulo.Marca;
            ordenDetallada.ListaDeMantenimientosAsociados = Repositorio.ObtenerMantenimientosParaUnaOrden(Id);

            return View(ordenDetallada);
        }

        public ActionResult Terminar(int id)
        {
            OrdenesDeMantenimiento orden;

            orden = Repositorio.ObtenerOrdenPorID(id);

            Repositorio.TerminarOrden(orden);

            return RedirectToAction(nameof(Listar));
        }
        public ActionResult Cancelar(int id)
        {
            OrdenesDeMantenimiento orden;
            orden = Repositorio.ObtenerOrdenPorID(id);
            return View(orden);
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
