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
    public class OrdenesDeMantenimientoRecibidasController : Controller
    {
        private readonly IRepositorioDelTaller RepositorioDelTaller;

        public OrdenesDeMantenimientoRecibidasController(IRepositorioDelTaller repositorioDeOrdenes)
        {
            RepositorioDelTaller = repositorioDeOrdenes;
        }

        // GET: OrdenesDeMantenimientoRecibidas
        public ActionResult Listar()
        {
            List<OrdenesDeMantenimiento> laLista;
            laLista = RepositorioDelTaller.ObtenerOrdenesRecibidas();

            return View(laLista);
        }

        // GET: OrdenesDeMantenimientoRecibidas/Details/5
        public ActionResult Detalles(int Id)
        {
            OrdenDetallada ordenDetallada = new OrdenDetallada();
            OrdenesDeMantenimiento orden = RepositorioDelTaller.ObtenerOrdenPorID(Id);
            ordenDetallada.NombreDelCliente = orden.NombreDelCliente;
            ordenDetallada.DescripcionDelProblema = orden.DescripcionDelProblema;
            ordenDetallada.FechaDeIngreso = orden.FechaDeIngreso;
            ordenDetallada.MontoDeAdelanto = orden.MontoDeAdelanto;
            Articulo articulo = new Articulo();
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(orden.Id_Articulo);
            ordenDetallada.NombreArticulo = articulo.Nombre;
            ordenDetallada.MarcaArticulo = articulo.Marca;
            ordenDetallada.ListaDeMantenimientosAsociados = RepositorioDelTaller.ObtenerMantenimientosParaUnaOrden(Id);

            return View(ordenDetallada);
        }

        // GET: OrdenesDeMantenimientoRecibidas/Create
        public ActionResult Agregar()
        {
            
            return View();
        }

        // POST: OrdenesDeMantenimientoRecibidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(OrdenesDeMantenimiento orden)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return RedirectToAction("ListarArticulosParaAsociar", new RouteValueDictionary(new
                    {
                        controller = "OrdenesDeMantenimientoRecibidas",
                        Action = "ListarArticulosParaAsociar",
                        nombre = orden.NombreDelCliente,
                        descripcion = orden.DescripcionDelProblema,
                        montoDeAdelanto = orden.MontoDeAdelanto,
                    })) ;
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


        public ActionResult ListarArticulosParaAsociar(string nombre, string descripcion, decimal montoDeAdelanto)
        {
            List<Articulo> articulos;
            articulos = RepositorioDelTaller.ObtenerTodosLosArticulos();
            ViewBag.NombreDelCliente = nombre;
            ViewBag.DescripcionDelProblema = descripcion;
            ViewBag.MontoDeAdelanto = montoDeAdelanto;

            return View(articulos);
        }


        public ActionResult AsociarArticulo(int Id_Articulo, string nombre, string descripcion, decimal montoDeAdelanto) 
        {
            OrdenesDeMantenimiento orden = new OrdenesDeMantenimiento();
            orden.NombreDelCliente = nombre;
            orden.DescripcionDelProblema = descripcion;
            orden.MontoDeAdelanto = montoDeAdelanto;
            orden.Id_Articulo = Id_Articulo;
            RepositorioDelTaller.AgregarOrden(orden);
            return RedirectToAction("Listar");
        }

        public ActionResult ListarMantenimientos(int id_Orden)
        {
            ViewBag.Id_Orden = id_Orden;
            List<Mantenimientos> mantenimientos;
            mantenimientos = RepositorioDelTaller.ObtenerMantenimientosParaUnaOrden(id_Orden);

             return View(mantenimientos);
        }


        public ActionResult AgregarMantenimiento(int Id_Mantenimiento, int Id_Orden)
        {
            RepositorioDelTaller.AgregarMantenimientoAUnaOrden(Id_Mantenimiento, Id_Orden);
            return RedirectToAction("Listar");
        }

        // GET: OrdenesDeMantenimientoRecibidas/Edit/5
        public ActionResult Editar(int id)
        {
            if (ModelState.IsValid)
            {
                OrdenesDeMantenimiento orden;
                orden = RepositorioDelTaller.ObtenerOrdenPorID(id);
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
        public ActionResult Editar(OrdenesDeMantenimiento orden)
        {
            try
            {
                RepositorioDelTaller.EditarOrden(orden);

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Iniciar(int id)
        {
            if (ModelState.IsValid)
            {
                OrdenesDeMantenimiento orden;
                orden = RepositorioDelTaller.ObtenerOrdenPorID(id);
                RepositorioDelTaller.IniciarOrden(orden);

                return RedirectToAction(nameof(Listar));

            }
            else
            {
                return View();
            }
        }

        // POST: OrdenesDeMantenimientoRecibidas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Iniciar(OrdenesDeMantenimiento orden)
        {
            try
            {
                RepositorioDelTaller.IniciarOrden(orden);

                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }
    }
}
