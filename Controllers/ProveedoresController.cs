using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;

namespace ApiEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly Conexiones _context;

        public ProveedoresController(Conexiones context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedores>>> GetProveedores()
        {
          if (_context.Proveedores == null)
          {
              return NotFound();
          }
            return await _context.Proveedores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedores>> GetProveedores(int id)
        {
          if (_context.Proveedores == null)
          {
              return NotFound();
          }
            var Proveedores = await _context.Proveedores.FindAsync(id);

            if (Proveedores == null)
            {
                return NotFound();
            }

            return Proveedores;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedores(int id, Proveedores Proveedores)
        {
            if (id != Proveedores.id_cliente)
            {
                return BadRequest();
            }

            _context.Entry(Proveedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedoresExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Proveedores>> PostProveedores(Proveedores Proveedores)
        {
          if (_context.Proveedores == null)
          {
              return Problem("Entity set 'Conexiones.Proveedores'  is null.");
          }
            _context.Proveedores.Add(Proveedores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedores", new { id = Proveedores.id_cliente }, Proveedores);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedores(int id)
        {
            if (_context.Proveedores == null)
            {
                return NotFound();
            }
            var Proveedores = await _context.Proveedores.FindAsync(id);
            if (Proveedores == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(Proveedores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedoresExists(int id)
        {
            return (_context.Proveedores?.Any(e => e.id_cliente == id)).GetValueOrDefault();
        }
    }
}
