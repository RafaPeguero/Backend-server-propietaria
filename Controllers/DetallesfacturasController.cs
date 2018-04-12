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
    [Route("api/Detallesfacturas")]
    public class DetallesfacturasController : Controller
    {
        private readonly facturacionContext _context;

        public DetallesfacturasController(facturacionContext context)
        {
            _context = context;
        }

        // GET: api/Detallesfacturas
        [HttpGet]
        public IEnumerable<Detallesfactura> GetDetallesfactura()
        {
            return _context.Detallesfactura;
        }

        // GET: api/Detallesfacturas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetallesfactura([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detallesfactura = await _context.Detallesfactura.SingleOrDefaultAsync(m => m.DetalleId == id);

            if (detallesfactura == null)
            {
                return NotFound();
            }

            return Ok(detallesfactura);
        }

        // PUT: api/Detallesfacturas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesfactura([FromRoute] int id, [FromBody] Detallesfactura detallesfactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallesfactura.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(detallesfactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesfacturaExists(id))
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

        // POST: api/Detallesfacturas
        [HttpPost]
        public async Task<IActionResult> PostDetallesfactura([FromBody] Detallesfactura detallesfactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Detallesfactura.Add(detallesfactura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesfactura", new { id = detallesfactura.DetalleId }, detallesfactura);
        }

        // DELETE: api/Detallesfacturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesfactura([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detallesfactura = await _context.Detallesfactura.SingleOrDefaultAsync(m => m.DetalleId == id);
            if (detallesfactura == null)
            {
                return NotFound();
            }

            _context.Detallesfactura.Remove(detallesfactura);
            await _context.SaveChangesAsync();

            return Ok(detallesfactura);
        }

        private bool DetallesfacturaExists(int id)
        {
            return _context.Detallesfactura.Any(e => e.DetalleId == id);
        }
    }
}