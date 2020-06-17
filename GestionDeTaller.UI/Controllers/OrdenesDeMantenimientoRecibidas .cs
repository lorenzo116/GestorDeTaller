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
    public class OrdenesDeMantenimientoRecibidas : Controller
    {
        private readonly IRepositorioDelTaller RepositorioDelTaller;

        public OrdenesDeMantenimientoRecibidas(IRepositorioDelTaller repositorioDeOrdenes)
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
            List<Articulo> listaDeArticulos = new List<Articulo>();
            listaDeArticulos = RepositorioDelTaller.ObtenerTodosLosArticulos();
            return View();
        }

        // POST: OrdenesDeMantenimientoRecibidas/Create
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
