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
    public class CatalogoDeRepuestosParaMantenimientoController : ControllerBase
    {
        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeRepuestosParaMantenimientoController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }
        // GET: api/<CatalogoDeRepuestosParaMantenimientoController>
        [HttpGet]
        public IEnumerable<Repuestos> Listar(int Id)
        {
            Mantenimientos mantenimiento;
            mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id);
            List<Repuestos> laListaDeRepuestos = new List<Repuestos>();
            List<RepuestosParaMantenimiento> laListaDeRepuestosYMantenimientos = new List<RepuestosParaMantenimiento>();
            laListaDeRepuestosYMantenimientos = RepositorioDelTaller.ObtenerRepuestoParaMantenimientos(Id);
            laListaDeRepuestos = RepositorioDelTaller.ObtenerRepuestosPorMantenimiento(laListaDeRepuestosYMantenimientos);
            
            return laListaDeRepuestos;
        }

        [HttpGet]
        public IEnumerable<Repuestos> ListarRepuestosSinMantenimiento(int Id_Mantenimiento)
        {
            Mantenimientos mantenimiento;
            mantenimiento = RepositorioDelTaller.ObtenerMantenimientoPorID(Id_Mantenimiento);
            List<Repuestos> listaDeRepuestosSinMantenimiento;
            listaDeRepuestosSinMantenimiento = RepositorioDelTaller.ObtenerRepuestosSinAsociar(mantenimiento.Id);

            return listaDeRepuestosSinMantenimiento;
        }

        // GET api/<CatalogoDeRepuestosParaMantenimientoController>/5
        [HttpGet("{id}")]
        public string Get()
        {
            return "value";
        }

        // POST api/<CatalogoDeRepuestosParaMantenimientoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CatalogoDeRepuestosParaMantenimientoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatalogoDeRepuestosParaMantenimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
