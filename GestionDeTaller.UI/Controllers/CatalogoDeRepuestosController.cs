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


        // GET: CatalogoDeRepuestos
        public ActionResult Listar(int Id)
        {
            ViewBag.Id_Articulo = Id;
            List<Repuestos> laLista = new List<Repuestos>();
            Articulo articulo = new Articulo();
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            laLista = RepositorioDelTaller.ObtenerRepuestosAsociados(articulo);
            return View(laLista);
        }

        // GET: CatalogoDeRepuestos/Details/5
        

        // GET: CatalogoDeRepuestos/Create
        public ActionResult Agregar(int Id_Articulo)
        {            
            Repuestos repuesto = new Repuestos();
            repuesto.Id_Articulo = Id_Articulo;
            return View(repuesto);
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Repuestos repuesto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
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

        // GET: CatalogoDeRepuestos/Edit/5
        public ActionResult Editar(int Id)
        {
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
        // POST: Articulos/Editar/
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

        // GET: CatalogoDeRepuestos/Detalles/5

        public ActionResult DetallesDeRepuesto(int Id)
        {
            RepuestoDetallado repuestoDetallado = new RepuestoDetallado();
            Repuestos repuesto = RepositorioDelTaller.ObtenerRepuestoPorID(Id);
            Articulo articulo = RepositorioDelTaller.ObtenerArticuloPorID(repuesto.Id_Articulo);
            repuestoDetallado.Nombre = repuesto.Nombre;
            repuestoDetallado.Precio = repuesto.Precio;
            repuestoDetallado.Descripcion = repuesto.Descripcion;
            repuestoDetallado.MantenimientosAsociados = RepositorioDelTaller.ObtenerRepuestoParaMantenimientos(Id);

            return View(repuestoDetallado);
        }


    }
}