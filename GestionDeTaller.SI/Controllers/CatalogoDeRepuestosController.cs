using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeTaller.BL;
using GestionDeTaller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionDeTaller.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoDeRepuestosController : ControllerBase
    {

        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeRepuestosController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }

        // GET: api/<CatalogoDeRepuestosController>
        [HttpGet]
        public IEnumerable<Repuestos> listar(int Id)
        {
            List<Repuestos> laListaDeRepuestos = new List<Repuestos>();
            Articulo articulo = new Articulo();
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            laListaDeRepuestos = RepositorioDelTaller.ObtenerRepuestosAsociados(articulo);

            return laListaDeRepuestos;
        }

        // GET api/<CatalogoDeRepuestosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RepuestoDetallado repuestoDetallado = new RepuestoDetallado();
            Repuestos repuesto = RepositorioDelTaller.ObtenerRepuestoPorID(id);
            //ViewBag.Id_Articulo = repuesto.Id_Articulo; Otra vez este hpta viewbag jode la vida
            Articulo articulo = RepositorioDelTaller.ObtenerArticuloPorID(repuesto.Id_Articulo);
            repuestoDetallado.Nombre = repuesto.Nombre;
            repuestoDetallado.Precio = repuesto.Precio;
            repuestoDetallado.Descripcion = repuesto.Descripcion;
            repuestoDetallado.ArticuloAsociado = articulo;
            List<RepuestosParaMantenimiento> repuestosAsociados;
            repuestosAsociados = RepositorioDelTaller.ObtenerMantenimientosParaRepuestos(id);
            repuestoDetallado.MantenimientosAsociados = RepositorioDelTaller.ObtenerMantenimientosPorRepuesto(repuestosAsociados);
            repuestoDetallado.ResumenDeUso = RepositorioDelTaller.ResumenDeUsoDelRepuesto(id);

            if (repuesto == null) { return NotFound(); }
            else
            {
                return Ok(repuestoDetallado);
            }
        }

        // POST api/<CatalogoDeRepuestosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CatalogoDeRepuestosController>/5
        [HttpPut("{id}")]
        public IActionResult AgregarRepuesto([FromBody] Repuestos repuesto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RepositorioDelTaller.AgregarRepuesto(repuesto);
                    return RedirectToAction("Listar", new RouteValueDictionary(new
                    {
                        controller = "CatalogoDeRepuestos",
                        Action = "Listar",
                        Id = repuesto.Id_Articulo
                    }));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return Ok(repuesto);
            }
        }

        // DELETE api/<CatalogoDeRepuestosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
