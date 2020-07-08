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
    public class OrdenesDeMantenimientoRecibidasController : Controller
    {
        public OrdenesDeMantenimientoRecibidasController()
        {
            
        }

        public async Task<ActionResult> Listar()
        {
            List<OrdenesDeMantenimiento> laLista = new List<OrdenesDeMantenimiento>();

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeOrdenesDeMantenimientoRecibidas");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<OrdenesDeMantenimiento>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(laLista);
        }

        public async Task<IActionResult> Detalles(int Id)
        {
            OrdenDetallada orden;

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44355/api/OrdenesDeMantenimientoRecibidas" + Id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                orden = JsonConvert.DeserializeObject<OrdenDetallada>(apiResponse);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return View(orden);
        }

        public ActionResult Agregar()
        {
            
            return View();
        }

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


        public async Task<ActionResult> ListarArticulosParaAsociar(string nombre, string descripcion, decimal montoDeAdelanto)
        {
            ViewBag.NombreDelCliente = nombre;
            ViewBag.DescripcionDelProblema = descripcion;
            ViewBag.MontoDeAdelanto = montoDeAdelanto;

            List<Articulo> laLista = new List<Articulo>();

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeOrdenesDeMantenimientoRecibidas");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<Articulo>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(laLista);
        }


        //public ActionResult AsociarArticulo(int Id_Articulo, string nombre, string descripcion, decimal montoDeAdelanto) 
        //{
        //    OrdenesDeMantenimiento orden = new OrdenesDeMantenimiento();
        //    orden.NombreDelCliente = nombre;
        //    orden.DescripcionDelProblema = descripcion;
        //    orden.MontoDeAdelanto = montoDeAdelanto;
        //    orden.Id_Articulo = Id_Articulo;
        //    RepositorioDelTaller.AgregarOrden(orden);
        //    return RedirectToAction("Listar");
        //}

        public async Task<ActionResult> ListarMantenimientos(int id_Orden)
        {
            ViewBag.Id_Orden = id_Orden;
            List<Mantenimientos> laLista = new List<Mantenimientos>();

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeOrdenesDeMantenimientoRecibidas");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<Mantenimientos>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(laLista);
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

        //public ActionResult Editar(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        OrdenesDeMantenimiento orden;
        //        orden = RepositorioDelTaller.ObtenerOrdenPorID(id);
        //        return View(orden);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Editar(OrdenesDeMantenimiento orden)
        //{
        //    try
        //    {
        //        RepositorioDelTaller.EditarOrden(orden);

        //        return RedirectToAction(nameof(Listar));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //public ActionResult Iniciar(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        OrdenesDeMantenimiento orden;
        //        orden = RepositorioDelTaller.ObtenerOrdenPorID(id);
        //        RepositorioDelTaller.IniciarOrden(orden);

        //        return RedirectToAction(nameof(Listar));

        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
