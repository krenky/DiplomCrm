using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairOrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RepairOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RepairOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairOrder>>> GetRepairOrder()
        {
          if (_context.RepairOrder == null)
          {
              return NotFound();
          }
            return await _context.RepairOrder.Include(x => x.Device).ToListAsync();
        }

        // GET: api/RepairOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairOrder>> GetRepairOrder(int id)
        {
          if (_context.RepairOrder == null)
          {
              return NotFound();
          }
            var repairOrder = _context.RepairOrder.Include(x => x.Device).First(x => x.Id == id);

            if (repairOrder == null)
            {
                return NotFound();
            }

            return repairOrder;
        }

        // PUT: api/RepairOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairOrder(int id, RepairOrder repairOrder)
        {
            //if (id != repairOrder.Id)
            //{
            //    return BadRequest();
            //}
            RepairOrder order = _context.RepairOrder.Find(id);
            CopyValues<RepairOrder>(order, repairOrder);
            repairOrder.Id = id;

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairOrderExists(id))
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

        // POST: api/RepairOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RepairOrder>> PostRepairOrder(RepairOrder repairOrder)
        {
          if (_context.RepairOrder == null)
          {
              return Problem("Entity set 'ApplicationDbContext.RepairOrder'  is null.");
          }
            _context.RepairOrder.Add(repairOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepairOrder", new { id = repairOrder.Id }, repairOrder);
        }

        // DELETE: api/RepairOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairOrder(int id)
        {
            if (_context.RepairOrder == null)
            {
                return NotFound();
            }
            var repairOrder = await _context.RepairOrder.FindAsync(id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            _context.RepairOrder.Remove(repairOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairOrderExists(int id)
        {
            return (_context.RepairOrder?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public void CopyValues<T>(T target, T source)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite && prop.Name != "Id");

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value is int)
                    if ((int)value == 0)
                        continue;
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }
    }
}
