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
    public class OrdenesDeMantenimientoEnProceso : Controller
    {
        private readonly IRepositorioDelTaller Repositorio;

        public OrdenesDeMantenimientoEnProceso(IRepositorioDelTaller repositorio)
        {
            Repositorio = repositorio;
        } 


        // GET: OrdenesDeMantenimientoEnProceso
        public ActionResult Listar()
        {
            List<OrdenesDeMantenimiento> ordenes;

            ordenes = Repositorio.ObtenerOrdenesEnProceso();

            return View(ordenes);
        }

        // GET: OrdenesDeMantenimientoEnProceso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
