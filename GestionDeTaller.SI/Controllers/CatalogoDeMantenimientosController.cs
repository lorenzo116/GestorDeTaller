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
    public class CatalogoDeMantenimientosController : ControllerBase
    {
        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeMantenimientosController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }
        // GET: api/<CatalogoDeMantenimientosController>
        [HttpGet]
        public IEnumerable<Mantenimientos> Get(int Id)
        {
            List<Mantenimientos> laListaDeMantenimientos;
            Articulo articulo;
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(Id);
            laListaDeMantenimientos = RepositorioDelTaller.ObtenerLosMantenimientos(articulo);

            return laListaDeMantenimientos;
        }

        // GET api/<CatalogoDeMantenimientosController>/5
        [HttpGet("{id}")]
        public string Get()
        {
            return "value";
        }

        // POST api/<CatalogoDeMantenimientosController>
        [HttpPost]
        public IActionResult AgregarMantenimiento([FromBody] Mantenimientos mantenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RepositorioDelTaller.AgregarMantenimiento(mantenimiento);
                    return RedirectToAction("Listar", new RouteValueDictionary(new
                    {
                        controller = "CatalogoDeMantenimientos",
                        Action = "Listar",
                        Id = mantenimiento.Id_Articulo
                    }));
                }
            }
            catch
            {
                return NotFound();
            }

            return Ok(mantenimiento);
        }

        // PUT api/<CatalogoDeMantenimientosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatalogoDeMantenimientosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
