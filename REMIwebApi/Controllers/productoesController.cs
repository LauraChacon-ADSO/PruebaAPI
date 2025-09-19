using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REMIwebApi.Datos;
using REMIwebApi.Models;

namespace REMIwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public productoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<producto>>> Getproductos()
        {
            return await _context.productos.ToListAsync();
        }

        // GET: api/productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<producto>> Getproducto(string id)
        {
            var producto = await _context.productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproducto(string id, producto producto)
        {
            if (id != producto.cod_Producto)
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
                if (!productoExists(id))
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

        // POST: api/productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<producto>> Postproducto(producto producto)
        {
            _context.productos.Add(producto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (productoExists(producto.cod_Producto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getproducto", new { id = producto.cod_Producto }, producto);
        }

        // DELETE: api/productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproducto(string id)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool productoExists(string id)
        {
            return _context.productos.Any(e => e.cod_Producto == id);
        }
    }
}
