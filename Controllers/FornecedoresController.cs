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
    [Route("api/Fornecedores")]
    public class FornecedoresController : Controller
    {
        private readonly SGPVContext _context;

        public FornecedoresController(SGPVContext context)
        {
            _context = context;
        }

        // GET: api/Fornecedores
        [HttpGet]
        public IEnumerable<Fornecedor> GetFornecedor()
        {
            return _context.Fornecedor;
        }

        // GET: api/Fornecedores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFornecedor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fornecedor = await _context.Fornecedor.SingleOrDefaultAsync(m => m.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        // PUT: api/Fornecedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor([FromRoute] Guid id, [FromBody] Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fornecedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
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

        // POST: api/Fornecedores
        [HttpPost]
        public async Task<IActionResult> PostFornecedor([FromBody] Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
        }

        // DELETE: api/Fornecedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fornecedor = await _context.Fornecedor.SingleOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedor.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return Ok(fornecedor);
        }

        private bool FornecedorExists(Guid id)
        {
            return _context.Fornecedor.Any(e => e.Id == id);
        }
    }
}