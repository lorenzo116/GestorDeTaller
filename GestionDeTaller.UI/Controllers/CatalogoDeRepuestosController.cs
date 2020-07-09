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
    public class CatalogoDeRepuestosController : Controller
    {

        public CatalogoDeRepuestosController()
        {
            
        }


        public async Task<ActionResult> Listar(int Id)
        {
            ViewBag.Id_Articulo = Id;

            List<Repuestos> laLista = new List<Repuestos>();

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeRepuestos");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<Repuestos>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(laLista);
        }


        public ActionResult Agregar(int Id_Articulo)
        {            
            Repuestos repuesto = new Repuestos();
            repuesto.Id_Articulo = Id_Articulo;
            ViewBag.Id_Articulo =Id_Articulo;
            return View(repuesto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Agregar(Repuestos repuesto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(repuesto);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    await httpClient.PostAsync("https://localhost:44355/api/CatalogoDeRepuestos", byteContent);


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


        //public ActionResult Editar(int Id)
        //{
        //    Repuestos Repuesto = RepositorioDelTaller.ObtenerRepuestoPorID(Id);
        //    ViewBag.Id_Articulo = Repuesto.Id_Articulo;
        //    if (ModelState.IsValid)
        //    {
        //        Repuestos repuesto;
        //        repuesto = RepositorioDelTaller.ObtenerRepuestoPorID(Id);
        //        return View(repuesto);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Editar(Repuestos repuesto)
        //{
            
        //    try
        //    {
        //        RepositorioDelTaller.EditarRepuesto(repuesto);

        //        return RedirectToAction("Listar", new RouteValueDictionary(new
        //        {
        //            controller = "CatalogoDeRepuestos",
        //            Action = "Listar",
        //            Id = repuesto.Id_Articulo
        //        }));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public async Task<IActionResult> DetallesDeRepuesto(int Id)
        {
            RepuestoDetallado repuesto;

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeRepuestos" + Id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                repuesto = JsonConvert.DeserializeObject<RepuestoDetallado>(apiResponse);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return View(repuesto);
        }

        public ActionResult VolverADetallesDeRepuesto(int id) {
            return RedirectToAction("Listar", new RouteValueDictionary(new
            {
                controller = "CatalogoDeRepuestos",
                Action = "Listar",
                Id = id
            }));
        }
    }
}