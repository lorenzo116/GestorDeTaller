using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using GestionDeTaller.UI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionDeTaller.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesDeMantenimientoTerminadasController : ControllerBase
    {
        private readonly IRepositorioDelTaller Repositorio;

        public OrdenesDeMantenimientoTerminadasController(IRepositorioDelTaller repositorio)
        {
            Repositorio = repositorio;
        }

        // GET: api/<OrdenesDeMantenimientoTerminadasController>
        [HttpGet]
        public IEnumerable<OrdenesDeMantenimiento> Listar()
        {
            List<OrdenesDeMantenimiento> ordenes;

            ordenes = Repositorio.ObtenerOrdenesTerminadas();

            return ordenes;
        }

        // GET api/<OrdenesDeMantenimientoTerminadasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OrdenDetallada ordenDetallada = new OrdenDetallada();
            OrdenesDeMantenimiento orden = Repositorio.ObtenerOrdenPorID(Id);
            ordenDetallada.NombreDelCliente = orden.NombreDelCliente;
            ordenDetallada.DescripcionDelProblema = orden.DescripcionDelProblema;
            ordenDetallada.FechaDeIngreso = orden.FechaDeIngreso;
            ordenDetallada.FechaDeInicio = orden.FechaDeInicio;
            ordenDetallada.FechaDeFinalizacion = orden.FechaDeFinalizacion;
            ordenDetallada.MontoDeAdelanto = orden.MontoDeAdelanto;
            Articulo articulo = new Articulo();
            articulo = Repositorio.ObtenerArticuloPorID(orden.Id_Articulo);
            ordenDetallada.NombreArticulo = articulo.Nombre;
            ordenDetallada.MarcaArticulo = articulo.Marca;
            ordenDetallada.ListaDeMantenimientosAsociados = Repositorio.ObtenerMantenimientosParaUnaOrden(Id);
            if (orden == null) { return NotFound(); }
            else
            {
                return Ok(articuloDetallado);
            }
        }

        // POST api/<OrdenesDeMantenimientoTerminadasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdenesDeMantenimientoTerminadasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdenesDeMantenimientoTerminadasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
