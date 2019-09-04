using ApiRapunzel.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRapunzel.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ContextoApi _context;

        public CitasController(ContextoApi context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public IEnumerable<CitasModel> GetCitas()
        {
            //var listaini = _context.Citas.ToList();

            var lista = (from c in _context.Citas
                         join cl in _context.Clientes
                         on c.IdCliente equals cl.IdCliente
                         join e in _context.Estilistas
                         on c.IdEstilista equals e.IdEstilista
                         select new Models.CitasModel
                         {
                             Fecha = c.Fecha,
                             Cliente = cl.Nombre,
                             ApellidosCliente = cl.Apellidos,
                             Hora = c.Hora,
                             Estilista = e.Nombre,
                             ApellidosEstilista = e.Apellidos,
                             IdCita = c.IdCita
                         }).ToList();
            //List<Cita> listaresult = new List<Cita>();
            //foreach (var item in lista)
            //{
            //   // listaresult.Add(new CitasModel()
            //    {
            //        Fecha = item.Fecha,
            //        Cliente = item.Cliente,
            //        Estilista = item.Estilista          

            return lista;
        }
        
        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCita([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cita = await _context.Citas.FindAsync(id);

            if (cita == null)
            {
                return NotFound();
            }

            return Ok(cita);
        }

        // PUT: api/Citas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita([FromRoute] int id, [FromBody] Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cita.IdCita)
            {
                return BadRequest();
            }

            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(id))
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

        // POST: api/Citas
        [HttpPost]
        public async Task<IActionResult> PostCita([FromBody] Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCita", new { id = cita.IdCita }, cita);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();

            return Ok(cita);
        }

        private bool CitaExists(int id)
        {
            return _context.Citas.Any(e => e.IdCita == id);
        }
    }
}