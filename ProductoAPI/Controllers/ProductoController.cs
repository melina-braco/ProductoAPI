using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly contexto _context;

        public ProductoController(contexto context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            return await _context.producto.ToListAsync();
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Producto>> GetProducto(int codigo)
        {
            var producto = await _context.producto.FirstOrDefaultAsync(p => p.Codigo == codigo);

            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                return producto;
            }
        }


        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            try
            {
                _context.producto.Add(producto);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.producto.Any(e => e.IdProducto == id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var estudiantes = await _context.producto.FindAsync(id);

                _context.producto.Remove(estudiantes);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
