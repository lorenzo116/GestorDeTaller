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
using Newtonsoft.Json;

namespace GestionDeTaller.UI.Controllers
{
    public class OrdenesDeMantenimientoEnProcesoController : Controller
    {
        public OrdenesDeMantenimientoEnProcesoController()
        {
            
        }

        public async Task<ActionResult> Listar()
        {
            List<OrdenesDeMantenimiento> laLista = new List<OrdenesDeMantenimiento>();

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/OrdenesEnProceso");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<OrdenesDeMantenimiento>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(laLista);
        }
        public async Task<ActionResult> ListarMantenimientos(int Id_Orden)
        {
            ViewBag.Id_Orden = Id_Orden;
            Mantenimientos orden = new Mantenimientos();
            List<Mantenimientos> mantenimientos = new List<Mantenimientos>();

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/OrdenesEnProceso");

                string apiResponse = await response.Content.ReadAsStringAsync();

                mantenimientos = JsonConvert.DeserializeObject<List<Mantenimientos>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(mantenimientos);
        }
        public async Task<ActionResult> AgregarMantenimiento(int Id_Mantenimiento, int Id_Orden)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(Id_Mantenimiento, (Formatting)Id_Orden);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    await httpClient.PostAsync("https://localhost:44355/api/CatalogoDeArticulos", byteContent);


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

        public async Task<IActionResult> Detalles(int Id)
        {
            OrdenDetallada orden;

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeArticulos" + Id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                orden = JsonConvert.DeserializeObject<OrdenDetallada>(apiResponse);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return View(orden);
        }

        //public ActionResult Terminar(int id)
        //{
        //    OrdenesDeMantenimiento orden;

        //    orden = Repositorio.ObtenerOrdenPorID(id);

        //    Repositorio.TerminarOrden(orden);

        //    return RedirectToAction(nameof(Listar));
        //}
        //public ActionResult Cancelar(int id)
        //{
        //    OrdenesDeMantenimiento orden;
        //    orden = Repositorio.ObtenerOrdenPorID(id);
        //    return View(orden);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Cancelar(OrdenesDeMantenimiento orden)
        //{
        //    try
        //    {
        //        Repositorio.CancelarOrden(orden);

        //        return RedirectToAction(nameof(Listar));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}