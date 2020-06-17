using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
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
            laLista = RepositorioDelTaller.ObtenerTodasLasOrdenes();

            return View(laLista);
        }

        // GET: OrdenesDeMantenimientoRecibidas/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
