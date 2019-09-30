using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRapunzel.Models;

namespace ApiRapunzel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstilistasController : ControllerBase
    {
        private readonly ContextoApi _context;

        public EstilistasController(ContextoApi context)
        {
            _context = context;
        }

        // GET: api/Estilistas
        [HttpGet]
        public IEnumerable<Estilista> GetEstilistas()
        {
            return _context.Estilistas;
        }

        // GET: api/Estilistas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstilista([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estilista = await _context.Estilistas.FindAsync(id);

            if (estilista == null)
            {
                return NotFound();
            }

            return Ok(estilista);
        }
        

        // PUT: api/Estilistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstilista([FromRoute] int id, [FromBody] Estilista estilista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estilista.IdEstilista)
            {
                return BadRequest();
            }

            _context.Entry(estilista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstilistaExists(id))
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

        // POST: api/Estilistas
        [HttpPost]
        public async Task<IActionResult> PostEstilista([FromBody] Estilista estilista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Estilistas.Add(estilista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstilista", new { id = estilista.IdEstilista }, estilista);
        }

        // DELETE: api/Estilistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstilista([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estilista = await _context.Estilistas.FindAsync(id);
            if (estilista == null)
            {
                return NotFound();
            }

            _context.Estilistas.Remove(estilista);
            await _context.SaveChangesAsync();

            return Ok(estilista);
        }

        private bool EstilistaExists(int id)
        {
            return _context.Estilistas.Any(e => e.IdEstilista == id);
        }
    }
}