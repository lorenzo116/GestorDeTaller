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
    public class OrdenesDeMantenimientoRecibidasController : ControllerBase
    {
        private readonly IRepositorioDelTaller RepositorioDelTaller;

        public OrdenesDeMantenimientoRecibidasController(IRepositorioDelTaller repositorioDeOrdenes)
        {
            RepositorioDelTaller = repositorioDeOrdenes;
        }

        // GET: api/<OrdenesRecibidasController>
        [HttpGet("listar")]
        public IEnumerable<OrdenesDeMantenimiento> Listar()
        {
            List<OrdenesDeMantenimiento> laLista;
            laLista = RepositorioDelTaller.ObtenerOrdenesRecibidas();

            return laLista;
        }

        [HttpGet("listarmantenimientos")]
        public IEnumerable<Mantenimientos> ListarMantenimientos(int id_Orden)
        {
            OrdenesDeMantenimiento orden;
            Articulo articulo;
            orden = RepositorioDelTaller.ObtenerOrdenPorID(id_Orden);
            articulo = RepositorioDelTaller.ObtenerArticuloPorID(orden.Id_Articulo);

            List<Mantenimientos> mantenimientos;
            mantenimientos = RepositorioDelTaller.ObtenerMantenimientosConElPrecioTotal(articulo);
            return mantenimientos;
        }

        [HttpGet("ListarMantenimientosArticulosParaAsociar")]
        public IEnumerable<Articulo> ListarMantenimientosArticulosParaAsociar(string nombre, string descripcion, decimal montoDeAdelanto)
        {
            List<Articulo> articulos;
            articulos = RepositorioDelTaller.ObtenerTodosLosArticulos();

            return articulos;
        }

        // GET api/<OrdenesRecibidasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OrdenDetallada ordenDetallada = new OrdenDetallada();
            OrdenesDeMantenimiento orden = RepositorioDelTaller.ObtenerOrdenPorID(id);
            ordenDetallada.NombreDelCliente = orden.NombreDelCliente;
            ordenDetallada.DescripcionDelProblema = orden.DescripcionDelProblema;
            ordenDetallada.FechaDeIngreso = orden.FechaDeIngreso;
            ordenDetallada.MontoDeAdelanto = orden.MontoDeAdelanto;
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

        // POST api/<OrdenesRecibidasController>
        [HttpPost]
        public IActionResult AgregarMantenimiento([FromBody] int Id_Mantenimiento, int Id_Orden)
        {
            try
            {
                RepositorioDelTaller.AgregarMantenimientoAUnaOrden(Id_Mantenimiento, Id_Orden);
                return RedirectToAction("Listar");
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        // PUT api/<OrdenesRecibidasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdenesRecibidasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
