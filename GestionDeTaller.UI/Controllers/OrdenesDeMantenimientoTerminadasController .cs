using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using GestionDeTaller.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionDeTaller.UI.Controllers
{
    public class OrdenesDeMantenimientoTerminadasController : Controller
    {
        public OrdenesDeMantenimientoTerminadasController()
        {
            
        }

        //public ActionResult Listar()
        //{
        //    List<OrdenesDeMantenimiento> ordenes;

        //    ordenes = Repositorio.ObtenerOrdenesTerminadas();

        //    return View(ordenes);
        //}


        public async Task<IActionResult> Detalles(int Id)
        {
            OrdenDetallada orden;

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44355/api/OrdenesDeMantenimientoTerminadas" + Id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                orden = JsonConvert.DeserializeObject<OrdenDetallada>(apiResponse);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return View(orden);
        }
    }
}
