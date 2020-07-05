using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace GestionDeTaller.UI.Controllers
{
    public class CatalogoDeRepuestosParaMantenimientoController : Controller
    {
        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeRepuestosParaMantenimientoController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }

        public async Task<ActionResult> Listar(int Id)
        {
            Mantenimientos mantenimiento;
            mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id);
            List<Repuestos> laListaDeRepuestos = new List<Repuestos>();
            ViewBag.Id_Articulo = mantenimiento.Id_Articulo;
            ViewBag.Id_Mantenimiento = Id;
            ViewBag.descripconDelMantenimiento = mantenimiento.Descripcion;

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeRpuestosParaMantenimiento");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laListaDeRepuestos = JsonConvert.DeserializeObject<List<Repuestos>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(laListaDeRepuestos);
        }

        public async Task<ActionResult> ListarRepuestosSinMantenimientoAsync(int Id_Mantenimiento) 
        {     
            Mantenimientos mantenimiento;
            mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id_Mantenimiento);
            ViewBag.Id_Mantenimiento = Id_Mantenimiento;
            ViewBag.descripcionDelMantenimiento = mantenimiento.Descripcion;
            ViewBag.Id_Articulo = mantenimiento.Id_Articulo;

            List<Repuestos> listaDeRepuestosSinMantenimiento = new List<Repuestos>();
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeRpuestosParaMantenimiento");

                string apiResponse = await response.Content.ReadAsStringAsync();

                listaDeRepuestosSinMantenimiento = JsonConvert.DeserializeObject<List<Repuestos>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

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