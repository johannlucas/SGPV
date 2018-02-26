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
    [Route("api/Estoques")]
    public class EstoquesController : Controller
    {
        private readonly SGPVContext _context;

        public EstoquesController(SGPVContext context)
        {
            _context = context;
        }

        // GET: api/Estoques
        [HttpGet]
        public IEnumerable<Estoque> GetEstoque()
        {
            return _context.Estoque;
        }

        // GET: api/Estoques/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstoque([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estoque = await _context.Estoque.SingleOrDefaultAsync(m => m.Id == id);

            if (estoque == null)
            {
                return NotFound();
            }

            return Ok(estoque);
        }

        // PUT: api/Estoques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstoque([FromRoute] Guid id, [FromBody] Estoque estoque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estoque.Id)
            {
                return BadRequest();
            }

            _context.Entry(estoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueExists(id))
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

        // POST: api/Estoques
        [HttpPost]
        public async Task<IActionResult> PostEstoque([FromBody] Estoque estoque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Estoque.Add(estoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstoque", new { id = estoque.Id }, estoque);
        }

        // DELETE: api/Estoques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstoque([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estoque = await _context.Estoque.SingleOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            _context.Estoque.Remove(estoque);
            await _context.SaveChangesAsync();

            return Ok(estoque);
        }

        private bool EstoqueExists(Guid id)
        {
            return _context.Estoque.Any(e => e.Id == id);
        }
    }
}