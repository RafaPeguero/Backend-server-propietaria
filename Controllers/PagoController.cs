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

    [Produces("application/json")]
    [Route("api/Pago")]
    public class PagoController : Controller
    {
        private readonly facturacionContext _context;

        public PagoController(facturacionContext context)
        {
            _context = context;
        }

        // GET: api/Pago
        [HttpGet]
        public IEnumerable<Condicionpago> GetCondicionpago()
        {
            return _context.Condicionpago;
        }

        // GET: api/Pago/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCondicionpago([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var condicionpago = await _context.Condicionpago.SingleOrDefaultAsync(m => m.PagoId == id);

            if (condicionpago == null)
            {
                return NotFound();
            }

            return Ok(condicionpago);
        }

        // PUT: api/Pago/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondicionpago([FromRoute] int id, [FromBody] Condicionpago condicionpago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condicionpago.PagoId)
            {
                return BadRequest();
            }

            _context.Entry(condicionpago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondicionpagoExists(id))
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

        // POST: api/Pago
        [HttpPost]
        public async Task<IActionResult> PostCondicionpago([FromBody] Condicionpago condicionpago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Condicionpago.Add(condicionpago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondicionpago", new { id = condicionpago.PagoId }, condicionpago);
        }

        // DELETE: api/Pago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondicionpago([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var condicionpago = await _context.Condicionpago.SingleOrDefaultAsync(m => m.PagoId == id);
            if (condicionpago == null)
            {
                return NotFound();
            }

            _context.Condicionpago.Remove(condicionpago);
            await _context.SaveChangesAsync();

            return Ok(condicionpago);
        }

        private bool CondicionpagoExists(int id)
        {
            return _context.Condicionpago.Any(e => e.PagoId == id);
        }
    }
}