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
    public class OrdenesDeMantenimientoCanceladasController : Controller
    {
        private readonly IRepositorioDelTaller RepositorioDelTaller;

        public OrdenesDeMantenimientoCanceladasController(IRepositorioDelTaller repositorioDeOrdenes)
        {
            RepositorioDelTaller = repositorioDeOrdenes;
        }

        public async Task<ActionResult> ListarAsync()
        {
            List<OrdenesDeMantenimiento> laLista = new List<OrdenesDeMantenimiento>();

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44355/api/CatalogoDeArticulos");

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
                var response = await httpClient.GetAsync("https://localhost:44355/api/OrdenesDeMantenimientoCanceladas" + Id);
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
