using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairWorksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RepairWorksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairWork>>> GetRepairWork()
        {
          if (_context.RepairWorks == null)
          {
              return NotFound();
          }
            return await _context.RepairWorks.ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairWork>> GetRepairWork(int id)
        {
          if (_context.RepairWorks == null)
          {
              return NotFound();
          }
            var device = await _context.RepairWorks.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairWork(int id, RepairWork device)
        {
            if (id != device.Id)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairWorkExists(id))
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
        public async Task<ActionResult<Device>> PostRepairWork(RepairWork device)
        {
          if (_context.RepairWorks == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Device'  is null.");
          }
            _context.RepairWorks.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepairWork", new { id = device.Id }, device);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairWork(int id)
        {
            if (_context.RepairWorks == null)
            {
                return NotFound();
            }
            var device = await _context.RepairWorks.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.RepairWorks.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairWorkExists(int id)
        {
            return (_context.RepairWorks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
