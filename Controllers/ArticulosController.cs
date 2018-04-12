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
    [Route("api/Articulos")]
    public class ArticulosController : Controller
    {
        private readonly facturacionContext _context;

        public ArticulosController(facturacionContext context)
        {
            _context = context;
        }

        // GET: api/Articulos
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpGet]
        public IEnumerable<Articulos> GetArticulos()
        {
            return _context.Articulos;
        }

        // GET: api/Articulos/5
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticulos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var articulos = await _context.Articulos.SingleOrDefaultAsync(m => m.ArticuloId == id);

            if (articulos == null)
            {
                return NotFound();
            }

            return Ok(articulos);
        }

        // PUT: api/Articulos/5
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulos([FromRoute] int id, [FromBody] Articulos articulos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articulos.ArticuloId)
            {
                return BadRequest();
            }

            _context.Entry(articulos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticulosExists(id))
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

        // POST: api/Articulos
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpPost]
        public async Task<IActionResult> PostArticulos([FromBody] Articulos articulos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articulos.Add(articulos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulos", new { id = articulos.ArticuloId }, articulos);
        }

        // DELETE: api/Articulos/5
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var articulos = await _context.Articulos.SingleOrDefaultAsync(m => m.ArticuloId == id);
            if (articulos == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulos);
            await _context.SaveChangesAsync();

            return Ok(articulos);
        }

        private bool ArticulosExists(int id)
        {
            return _context.Articulos.Any(e => e.ArticuloId == id);
        }
    }
}