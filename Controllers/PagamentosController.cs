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
    [Route("api/Pagamentos")]
    public class PagamentosController : Controller
    {
        private readonly SGPVContext _context;

        public PagamentosController(SGPVContext context)
        {
            _context = context;
        }

        // GET: api/Pagamentos
        [HttpGet]
        public IEnumerable<Pagamento> GetPagamento()
        {
            return _context.Pagamento;
        }

        // GET: api/Pagamentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPagamento([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pagamento = await _context.Pagamento.SingleOrDefaultAsync(m => m.Id == id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return Ok(pagamento);
        }

        // PUT: api/Pagamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento([FromRoute] Guid id, [FromBody] Pagamento pagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pagamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoExists(id))
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

        // POST: api/Pagamentos
        [HttpPost]
        public async Task<IActionResult> PostPagamento([FromBody] Pagamento pagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pagamento.Add(pagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagamento", new { id = pagamento.Id }, pagamento);
        }

        // DELETE: api/Pagamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pagamento = await _context.Pagamento.SingleOrDefaultAsync(m => m.Id == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            _context.Pagamento.Remove(pagamento);
            await _context.SaveChangesAsync();

            return Ok(pagamento);
        }

        private bool PagamentoExists(Guid id)
        {
            return _context.Pagamento.Any(e => e.Id == id);
        }
    }
}