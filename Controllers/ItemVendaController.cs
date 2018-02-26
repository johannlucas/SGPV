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
    [Route("api/ItemVendas")]
    public class ItemVendaController : Controller
    {
        private readonly SGPVContext _context;

        public ItemVendaController(SGPVContext context)
        {
            _context = context;
        }

        // GET: api/ItemVendas
        [HttpGet]
        public IEnumerable<ItemVenda> GetItemVenda()
        {
            return _context.ItemVenda;
        }

        // GET: api/ItemVendas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemVenda([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemVenda = await _context.ItemVenda.SingleOrDefaultAsync(m => m.Id == id);

            if (itemVenda == null)
            {
                return NotFound();
            }

            return Ok(itemVenda);
        }

        // PUT: api/ItemVendas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemVenda([FromRoute] Guid id, [FromBody] ItemVenda itemVenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemVenda.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemVenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemVendaExists(id))
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

        // POST: api/ItemVendas
        [HttpPost]
        public async Task<IActionResult> PostItemVenda([FromBody] ItemVenda itemVenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ItemVenda.Add(itemVenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemVenda", new { id = itemVenda.Id }, itemVenda);
        }

        // DELETE: api/ItemVendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemVenda([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemVenda = await _context.ItemVenda.SingleOrDefaultAsync(m => m.Id == id);
            if (itemVenda == null)
            {
                return NotFound();
            }

            _context.ItemVenda.Remove(itemVenda);
            await _context.SaveChangesAsync();

            return Ok(itemVenda);
        }

        private bool ItemVendaExists(Guid id)
        {
            return _context.ItemVenda.Any(e => e.Id == id);
        }
    }
}