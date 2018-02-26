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
    [Route("api/Vendas")]
    public class VendasController : Controller
    {
        private readonly SGPVContext _context;

        public VendasController(SGPVContext context)
        {
            _context = context;
        }

        // GET: api/Vendas
        [HttpGet]
        public IEnumerable<Venda> GetVenda()
        {
            return _context.Venda;
        }

        // GET: api/Vendas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenda([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var venda = await _context.Venda.SingleOrDefaultAsync(m => m.Id == id);

            if (venda == null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        // PUT: api/Vendas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda([FromRoute] Guid id, [FromBody] Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venda.Id)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExists(id))
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

        // POST: api/Vendas
        [HttpPost]
        public async Task<IActionResult> PostVenda([FromBody] Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenda", new { id = venda.Id }, venda);
        }

        // DELETE: api/Vendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var venda = await _context.Venda.SingleOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();

            return Ok(venda);
        }

        private bool VendaExists(Guid id)
        {
            return _context.Venda.Any(e => e.Id == id);
        }
    }
}