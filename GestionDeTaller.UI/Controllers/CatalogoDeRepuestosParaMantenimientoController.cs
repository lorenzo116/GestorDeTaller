using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GestionDeTaller.UI.Controllers
{
    public class CatalogoDeRepuestosParaMantenimientoController : Controller
    {
        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeRepuestosParaMantenimientoController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }

        // GET: CatalogoDeRepuestosParaMantenimiento
        public ActionResult Listar(int Id)
        {
            Mantenimientos mantenimiento;
            mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id);
            ViewBag.Id_Articulo = mantenimiento.Id_Articulo;
            ViewBag.Id_Mantenimiento = Id;
            ViewBag.descripconDelMantenimiento = mantenimiento.Descripcion;
            List<Repuestos> laListaDeRepuestos = new List<Repuestos>();
            List<RepuestosParaMantenimiento> laListaDeRepuestosYMantenimientos = new List<RepuestosParaMantenimiento>();
            laListaDeRepuestosYMantenimientos = RepositorioDelTaller.ObtenerRepuestoParaMantenimientos(Id);
            laListaDeRepuestos = RepositorioDelTaller.ObtenerRepuestosPorMantenimiento(laListaDeRepuestosYMantenimientos);   
            return View(laListaDeRepuestos);
        }

        public ActionResult ListarRepuestosSinMantenimiento(int Id_Mantenimiento) 
        {     
            Mantenimientos mantenimiento;
            mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id_Mantenimiento);
            ViewBag.Id_Mantenimiento = Id_Mantenimiento;
            ViewBag.descripcionDelMantenimiento = mantenimiento.Descripcion;

            ViewBag.Id_Articulo = mantenimiento.Id_Articulo;
            List<Repuestos> listaDeRepuestosSinMantenimiento;
            listaDeRepuestosSinMantenimiento = RepositorioDelTaller.ObtenerRepuestosSinAsociar(mantenimiento.Id);

            return View(listaDeRepuestosSinMantenimiento);
        }


        public ActionResult Asociar(int Id_Repuesto, int Id_Mantenimiento) 
        {
            RepuestosParaMantenimiento repuestoParaAsociar = new RepuestosParaMantenimiento();
            repuestoParaAsociar.Id_Mantenimiento = Id_Mantenimiento;
            repuestoParaAsociar.Id_Repuesto = Id_Repuesto;
            RepositorioDelTaller.AsociarRepuestoConUnMantenimiento(repuestoParaAsociar);

            return RedirectToAction("ListarRepuestosSinMantenimiento", new RouteValueDictionary(new
            {
                controller = "CatalogoDeRepuestosParaMantenimiento",
                Action = "ListarRepuestosSinMantenimiento", 
                Id_Mantenimiento = Id_Mantenimiento }));
        }

        public ActionResult Desasociar(int Id_Repuesto, int Id_Mantenimiento) 
        {
            RepositorioDelTaller.DesasociarRepuestoDeMantenimiento(Id_Repuesto, Id_Mantenimiento);
            return RedirectToAction("Listar", new RouteValueDictionary(new
            {
                controller = "CatalogoDeRepuestosParaMantenimiento",
                Action = "ListarRepuestosSinMantenimiento",
                Id = Id_Mantenimiento
            }));
        }

       
    }
}