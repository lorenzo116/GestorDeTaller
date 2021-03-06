﻿using System;
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
    public class CatalogoDeArticulosController : ControllerBase
    {

        private IRepositorioDelTaller RepositorioDelTaller;
        public CatalogoDeArticulosController(IRepositorioDelTaller repositorioDeLibros)
        {
            RepositorioDelTaller = repositorioDeLibros;
        }

        // GET: api/<CatalogoDeArticulosController>
        [HttpGet]
        public IEnumerable<Articulo> Listar()
        {
            List<Articulo> laLista;
            laLista = RepositorioDelTaller.ObtenerTodosLosArticulos();
            return laLista;
        }

        // GET api/<CatalogoDeArticulosController>/5

        // POST api/<CatalogoDeArticulosController>
        [HttpPost]
        public IActionResult AgregarArticulo([FromBody] Articulo articulo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RepositorioDelTaller.AgregarArticulo(articulo);
                }
            }
            catch
            {
                return NotFound();
            }

            return Ok(articulo);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ArticuloDetallado articuloDetallado = new ArticuloDetallado();
            Articulo articulo = RepositorioDelTaller.ObtenerArticuloPorID(id);
            articuloDetallado.Nombre = articulo.Nombre;
            articuloDetallado.Marca = articulo.Marca;
            articuloDetallado.Descripcion = articulo.Descripcion;
            articuloDetallado.CantidadDeOrdenesEnProceso = RepositorioDelTaller.ContarOrdenesEnProceso(id);
            articuloDetallado.CantidadDeOrdenesTerminadas = RepositorioDelTaller.ContarOrdenesTerminadas(id);
            articuloDetallado.RepuestosAsociados = RepositorioDelTaller.ObtenerRepuestosAsociados(articulo);
            if (articulo == null) { return NotFound(); }
            else
            {
                return Ok(articuloDetallado);
            }
        }

        // PUT api/<CatalogoDeArticulosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/<CatalogoDeArticulosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
