using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Facturacion.Modal;
using Microsoft.AspNetCore.Cors;
namespace Facturacion.Controllers
{
    [EnableCors("Access-Control-Allow-Origin")]
    [Produces("application/json")]
    [Route("api/Asiento")]
    public class AsientoController : Controller
    {
        private readonly facturacionContext _context;

        public AsientoController(facturacionContext context)
        {
            _context = context;
        }

        // GET: api/Asiento
        [HttpGet]
        public IEnumerable<Asientocontable> GetAsientocontable()
        {
            return _context.Asientocontable;
        }

        // GET: api/Asiento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsientocontable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asientocontable = await _context.Asientocontable.SingleOrDefaultAsync(m => m.AsientoId == id);

            if (asientocontable == null)
            {
                return NotFound();
            }

            return Ok(asientocontable);
        }

        // PUT: api/Asiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsientocontable([FromRoute] int id, [FromBody] Asientocontable asientocontable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asientocontable.AsientoId)
            {
                return BadRequest();
            }

            _context.Entry(asientocontable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientocontableExists(id))
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

        // POST: api/Asiento
        [HttpPost]
        public async Task<IActionResult> PostAsientocontable([FromBody] Asientocontable asientocontable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Asientocontable.Add(asientocontable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsientocontable", new { id = asientocontable.AsientoId }, asientocontable);
        }

        // DELETE: api/Asiento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsientocontable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asientocontable = await _context.Asientocontable.SingleOrDefaultAsync(m => m.AsientoId == id);
            if (asientocontable == null)
            {
                return NotFound();
            }

            _context.Asientocontable.Remove(asientocontable);
            await _context.SaveChangesAsync();

            return Ok(asientocontable);
        }

        private bool AsientocontableExists(int id)
        {
            return _context.Asientocontable.Any(e => e.AsientoId == id);
        }
    }
}