using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesStagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalesStagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesStages>>> GetSalesStages()
        {
          if (_context.SalesStages == null)
          {
              return NotFound();
          }
          var result = await _context.SalesStages.Include(x => x.Orders).ToListAsync();
            return await _context.SalesStages.Include(x => x.Orders).ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesStages>> GetSalesStages(int id)
        {
          if (_context.SalesStages == null)
          {
              return NotFound();
          }
            var device = await _context.SalesStages.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesStages(string id, SalesStages user)
        {
            if (id != user.Id.ToString())
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesStagesExists(id))
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

        // POST: api/Devices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesStages>> PostSalesStages(SalesStages user)
        {
          if (_context.SalesStages == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Device'  is null.");
          }
            _context.SalesStages.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesStage", new { id = user.Id }, user);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesStages(int id)
        {
            if (_context.SalesStages == null)
            {
                return NotFound();
            }
            var device = await _context.SalesStages.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.SalesStages.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesStagesExists(string id)
        {
            return (_context.SalesStages?.Any(e => e.Id.ToString() == id)).GetValueOrDefault();
        }
    }
}
