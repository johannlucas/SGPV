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
    [Route("api/ItemCompra")]
    public class ItemCompraController : Controller
    {
        private readonly SGPVContext _context;

        public ItemCompraController(SGPVContext context)
        {
            _context = context;
        }

        // GET: api/ItemCompra
        [HttpGet]
        public IEnumerable<ItemCompra> GetItemCompra()
        {
            return _context.ItemCompra;
        }

        // GET: api/ItemCompra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemCompra([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemCompra = await _context.ItemCompra.SingleOrDefaultAsync(m => m.Id == id);

            if (itemCompra == null)
            {
                return NotFound();
            }

            return Ok(itemCompra);
        }

        // PUT: api/ItemCompra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCompra([FromRoute] Guid id, [FromBody] ItemCompra itemCompra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemCompra.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCompraExists(id))
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

        // POST: api/ItemCompra
        [HttpPost]
        public async Task<IActionResult> PostItemCompra([FromBody] ItemCompra itemCompra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ItemCompra.Add(itemCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemCompra", new { id = itemCompra.Id }, itemCompra);
        }

        // DELETE: api/ItemCompra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemCompra([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemCompra = await _context.ItemCompra.SingleOrDefaultAsync(m => m.Id == id);
            if (itemCompra == null)
            {
                return NotFound();
            }

            _context.ItemCompra.Remove(itemCompra);
            await _context.SaveChangesAsync();

            return Ok(itemCompra);
        }

        private bool ItemCompraExists(Guid id)
        {
            return _context.ItemCompra.Any(e => e.Id == id);
        }
    }
}