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
    [Route("api/Facturacion")]
    public class FacturacionController : Controller
    {
        private readonly facturacionContext _context;

        public FacturacionController(facturacionContext context)
        {
            _context = context;
        }

        // GET: api/Facturacion
        [HttpGet]
        public IEnumerable<Modal.Facturacion> GetFacturacion()
        {
            return _context.Facturacion;
        }

        // GET: api/Facturacion/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacturacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facturacion = await _context.Facturacion.SingleOrDefaultAsync(m => m.FacturaId == id);

            if (facturacion == null)
            {
                return NotFound();
            }

            return Ok(facturacion);
        }

        // PUT: api/Facturacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturacion([FromRoute] int id, [FromBody] Modal.Facturacion facturacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facturacion.FacturaId)
            {
                return BadRequest();
            }

            _context.Entry(facturacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturacionExists(id))
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

        // POST: api/Facturacion
        [HttpPost]
        public async Task<IActionResult> PostFacturacion([FromBody] Modal.Facturacion facturacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Facturacion.Add(facturacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturacion", new { id = facturacion.FacturaId }, facturacion);
        }

        // DELETE: api/Facturacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facturacion = await _context.Facturacion.SingleOrDefaultAsync(m => m.FacturaId == id);
            if (facturacion == null)
            {
                return NotFound();
            }

            _context.Facturacion.Remove(facturacion);
            await _context.SaveChangesAsync();

            return Ok(facturacion);
        }

        private bool FacturacionExists(int id)
        {
            return _context.Facturacion.Any(e => e.FacturaId == id);
        }
    }
}