using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGPV.Data;
using SGPV.Models;

namespace SGPV.Controllers
{
    [Produces("application/json")]
    [Route("api/Vendedores")]
    public class VendedoresController : Controller
    {
        private readonly SGPVContext _context;

        public VendedoresController(SGPVContext context)
        {
            _context = context;
        }

        // GET: api/Vendedores
        [HttpGet]
        public IEnumerable<Vendedor> GetVendedor()
        {
            return _context.Vendedor;
        }

        // GET: api/Vendedores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendedor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendedor = await _context.Vendedor.SingleOrDefaultAsync(m => m.Id == id);

            if (vendedor == null)
            {
                return NotFound();
            }

            return Ok(vendedor);
        }

        // PUT: api/Vendedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedor([FromRoute] Guid id, [FromBody] Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorExists(id))
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

        // POST: api/Vendedores
        [HttpPost]
        public async Task<IActionResult> PostVendedor([FromBody] Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vendedor.Add(vendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedor", new { id = vendedor.Id }, vendedor);
        }

        // DELETE: api/Vendedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendedor = await _context.Vendedor.SingleOrDefaultAsync(m => m.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            _context.Vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();

            return Ok(vendedor);
        }

        private bool VendedorExists(Guid id)
        {
            return _context.Vendedor.Any(e => e.Id == id);
        }
    }
}