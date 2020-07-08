using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionDeTaller.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesDeMantenimientoCanceladasController : ControllerBase
    {
        private readonly IRepositorioDelTaller RepositorioDelTaller;

        public OrdenesDeMantenimientoCanceladasController(IRepositorioDelTaller repositorioDeOrdenes)
        {
            RepositorioDelTaller = repositorioDeOrdenes;
        }

        // GET: api/<OrdenesDeMantenimientoCanceladasController>
        [HttpGet]
        public IEnumerable<OrdenesDeMantenimiento> listar()
        {
            List<OrdenesDeMantenimiento> ordenes;

            ordenes = RepositorioDelTaller.ObtenerOrdenesCanceladas();

            return ordenes;
        }

        // GET api/<OrdenesDeMantenimientoCanceladasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OrdenDetallada ordenDetallada = new OrdenDetallada();
            OrdenesDeMantenimiento orden = RepositorioDelTaller.ObtenerOrdenPorID(id);
            ordenDetallada.NombreDelCliente = orden.NombreDelCliente;
            ordenDetallada.DescripcionDelProblema = orden.DescripcionDelProblema;
            ordenDetallada.FechaDeIngreso = orden.FechaDeIngreso;
            ordenDetallada.FechaDeInicio = orden.FechaDeInicio;
            ordenDetallada.MontoDeAdelanto = orden.MontoDeAdelanto;
            ordenDetallada.MotivoDeCancelacion = orden.MotivoDeCancelacion;
            Articulo articulo = new Articulo();
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(orden.Id_Articulo);
            ordenDetallada.NombreArticulo = articulo.Nombre;
            ordenDetallada.MarcaArticulo = articulo.Marca;
            ordenDetallada.ListaDeMantenimientosAsociados = RepositorioDelTaller.ObtenerMantenimientosParaUnaOrden(id);
            if (orden == null) { return NotFound(); }
            else
            {
                return Ok(ordenDetallada);
            }
        }

        // POST api/<OrdenesDeMantenimientoCanceladasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdenesDeMantenimientoCanceladasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdenesDeMantenimientoCanceladasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
