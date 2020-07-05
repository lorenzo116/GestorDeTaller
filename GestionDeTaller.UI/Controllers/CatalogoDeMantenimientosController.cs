using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using GestionDeTaller.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace GestionDeTaller.UI.Controllers
{
    public class CatalogoDeMantenimientosController : Controller
    {
        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeMantenimientosController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }

        public async Task<IActionResult> Listar(int Id)
        {
            ViewBag.Id_Articulo = Id;
            List<Mantenimientos> laListaDeMantenimientos = new List<Mantenimientos>();

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeMantenimientos");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laListaDeMantenimientos = JsonConvert.DeserializeObject<List<Mantenimientos>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return View(laListaDeMantenimientos);
        }

        public ActionResult DetallesDeMantenimientos(int Id)
        {
           
            MantenimientoDetallado mantenimientoDetallado = new MantenimientoDetallado();
            Mantenimientos mantenimiento;
            mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id);
            ViewBag.Id_Articulo = mantenimiento.Id_Articulo;
            mantenimientoDetallado.Id = mantenimiento.Id;
            mantenimientoDetallado.Descripcion = mantenimiento.Descripcion;
            List<RepuestosParaMantenimiento> repuestosAsociados;
            repuestosAsociados = RepositorioDelTaller.ObtenerRepuestoParaMantenimientos(Id);
            mantenimientoDetallado.RepuestosAsociados = RepositorioDelTaller.ObtenerRepuestosPorMantenimiento(repuestosAsociados);
            mantenimientoDetallado.ResumenDeUso = RepositorioDelTaller.ResumenDeUsoDelMantenimiento(Id);
            return View(mantenimientoDetallado);
        }

        public ActionResult AgregarMantenimiento(int Id_Articulo)
        {
            
            Mantenimientos mantenimiento = new Mantenimientos();
            mantenimiento.Id_Articulo = Id_Articulo;
            ViewBag.Id_Articulo = Id_Articulo;
            return View(mantenimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AgregarMantenimiento(Mantenimientos mantenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(mantenimiento);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    await httpClient.PostAsync("https://localhost:44355/api/CatalogoDeMantenimientos", byteContent);


                    return RedirectToAction(nameof(Listar));
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Editar(int Id)
        {
            Mantenimientos mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id);
            ViewBag.Id_Articulo = mantenimiento.Id_Articulo;
            if (ModelState.IsValid)
            {
                Mantenimientos mantenimientos;
                mantenimientos = RepositorioDelTaller.ObtenerMantenimientoPorID(Id);
                return View(mantenimientos);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Mantenimientos mantenimientos)
        {

            try
            {
                RepositorioDelTaller.EditarMantenimiento(mantenimientos);

                return RedirectToAction("Listar", new RouteValueDictionary(new
                {
                    controller = "CatalogoDeMantenimientos",
                    Action = "Listar",
                    Id = mantenimientos.Id_Articulo
                }));
            }
            catch
            {
                return View();
            }
        }
    }
}