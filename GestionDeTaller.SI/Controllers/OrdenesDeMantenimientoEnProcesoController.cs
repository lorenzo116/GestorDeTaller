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
    public class OrdenesDeMantenimientoEnProcesoController : ControllerBase
    {
        private readonly IRepositorioDelTaller Repositorio;

        public OrdenesDeMantenimientoEnProcesoController(IRepositorioDelTaller repositorio)
        {
            Repositorio = repositorio;
        }

        // GET: api/<OrdenesDeMantenimientoEnProcesoController>
        [HttpGet("listar")]
        public IEnumerable<OrdenesDeMantenimiento> Listar()
        {
            List<OrdenesDeMantenimiento> ordenes;

            ordenes = Repositorio.ObtenerOrdenesEnProceso();

            return ordenes;
        }

        [HttpGet("listarmantenimientos")]
        public IEnumerable<Mantenimientos> ListarMantenimientos(int Id_Orden)
        {
            OrdenesDeMantenimiento orden;
            orden = Repositorio.ObtenerOrdenPorID(Id_Orden);
            Articulo articulo;
            articulo = Repositorio.ObtenerArticuloPorID(orden.Id_Articulo);
            List<Mantenimientos> mantenimientos;
            mantenimientos = Repositorio.ObtenerMantenimientosConElPrecioTotal(articulo);

            return mantenimientos;
        }

        // GET api/<OrdenesDeMantenimientoEnProcesoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OrdenDetallada ordenDetallada = new OrdenDetallada();
            OrdenesDeMantenimiento orden = Repositorio.ObtenerOrdenPorID(id);
            ordenDetallada.NombreDelCliente = orden.NombreDelCliente;
            ordenDetallada.DescripcionDelProblema = orden.DescripcionDelProblema;
            ordenDetallada.FechaDeIngreso = orden.FechaDeIngreso;
            ordenDetallada.FechaDeInicio = orden.FechaDeInicio;
            ordenDetallada.MontoDeAdelanto = orden.MontoDeAdelanto;
            Articulo articulo = new Articulo();
            articulo = Repositorio.ObtenerArticuloPorID(orden.Id_Articulo);
            ordenDetallada.NombreArticulo = articulo.Nombre;
            ordenDetallada.MarcaArticulo = articulo.Marca;
            ordenDetallada.ListaDeMantenimientosAsociados = Repositorio.ObtenerMantenimientosParaUnaOrden(id);
            if (orden == null) { return NotFound(); }
            else
            {
                return Ok(ordenDetallada);
            }
        }

        // POST api/<OrdenesDeMantenimientoEnProcesoController>
        [HttpPost]
        public IActionResult AgregarMantenimientos([FromBody] int Id_Mantenimiento, int Id_Orden)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.AgregarMantenimientoAUnaOrden(Id_Mantenimiento, Id_Orden);
                }
            }
            catch
            {
                return NotFound();
            }

            return RedirectToAction("Listar");
        }

        // PUT api/<OrdenesDeMantenimientoEnProcesoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdenesDeMantenimientoEnProcesoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
