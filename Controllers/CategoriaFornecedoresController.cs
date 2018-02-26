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
    [Route("api/CategoriaFornecedores")]
    public class CategoriaFornecedoresController : Controller
    {
        private readonly SGPVContext _context;

        public CategoriaFornecedoresController(SGPVContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaFornecedores
        [HttpGet]
        public IEnumerable<CategoriaFornecedores> GetCategoriaFornecedores()
        {
            return _context.CategoriaFornecedores;
        }

        // GET: api/CategoriaFornecedores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaFornecedores([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaFornecedores = await _context.CategoriaFornecedores.SingleOrDefaultAsync(m => m.Id == id);

            if (categoriaFornecedores == null)
            {
                return NotFound();
            }

            return Ok(categoriaFornecedores);
        }

        // PUT: api/CategoriaFornecedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaFornecedores([FromRoute] Guid id, [FromBody] CategoriaFornecedores categoriaFornecedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaFornecedores.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaFornecedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaFornecedoresExists(id))
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

        // POST: api/CategoriaFornecedores
        [HttpPost]
        public async Task<IActionResult> PostCategoriaFornecedores([FromBody] CategoriaFornecedores categoriaFornecedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CategoriaFornecedores.Add(categoriaFornecedores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaFornecedores", new { id = categoriaFornecedores.Id }, categoriaFornecedores);
        }

        // DELETE: api/CategoriaFornecedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaFornecedores([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaFornecedores = await _context.CategoriaFornecedores.SingleOrDefaultAsync(m => m.Id == id);
            if (categoriaFornecedores == null)
            {
                return NotFound();
            }

            _context.CategoriaFornecedores.Remove(categoriaFornecedores);
            await _context.SaveChangesAsync();

            return Ok(categoriaFornecedores);
        }

        private bool CategoriaFornecedoresExists(Guid id)
        {
            return _context.CategoriaFornecedores.Any(e => e.Id == id);
        }
    }
}