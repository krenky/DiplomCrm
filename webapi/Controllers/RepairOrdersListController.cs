using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairOrdersListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepairOrderHistoryService _repairOrderHistoryService;

        public RepairOrdersListController(ApplicationDbContext context, IRepairOrderHistoryService repairOrderHistory)
        {
            _context = context;
            _repairOrderHistoryService = repairOrderHistory;
        }

        // GET: api/RepairOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairOrder>>> GetRepairOrderList()
        {
          if (_context.RepairOrders == null)
          {
              return NotFound();
          }
            var result = await _context.RepairOrders
                .Include(x => x.SalesStages)
                .Include(x => x.Device)
                .Include(x => x.Customer)
                .Include(x => x.ApplicationUser)
                .Include(x => x.PartsUsed)
                .Include(x => x.repairWorks).ToListAsync();
            foreach(var i in result)
            {
                i.AdvertisingСompany = _context.AdvertisingСompany.Find(i.AdvertisingСompanyId);
            }
            return result;
        }

        //// GET: api/RepairOrders/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<RepairOrder>> GetRepairOrder(int id)
        //{
        //  if (_context.RepairOrders == null)
        //  {
        //      return NotFound();
        //  }
        //    var repairOrder = _context.RepairOrders.Include(x => x.Device).First(x => x.Id == id);
        //    var repairWork = _context.RepairWorks.Where(x => x.repairOrders.Contains(repairOrder)).ToList();
        //    var inventoryItem = _context.InventoryItem.Where(x => x.repairOrders.Contains(repairOrder)).ToList();
        //    repairOrder.repairWorks = repairWork;
        //    repairOrder.PartsUsed = inventoryItem;

        //    if (repairOrder == null)
        //    {
        //        return NotFound();
        //    }

        //    return repairOrder;
        //}

        //[HttpGet("/api/RepairOrders/RepairWork/{repairOrderId}")]
        //public async Task<ActionResult<IEnumerable<RepairWork>>> GetRepairWorks(int repairOrderId)
        //{
        //    if (_context.RepairWorks == null)
        //    {
        //        return NotFound();
        //    }
        //    var repairOrder = _context.RepairOrders.First(x => x.Id == repairOrderId);
        //    var repairWork = _context.RepairWorks.Where(x => x.repairOrders.Contains(repairOrder)).ToList();
        //    repairOrder.repairWorks = repairWork;
        //    if (repairWork == null)
        //    {
        //        return NotFound();
        //    }

        //    return repairWork;
        //}

        //// PUT: api/RepairOrders/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRepairOrder(int id, RepairOrder repairOrder)
        //{
        //    //if (id != repairOrder.Id)
        //    //{
        //    //    return BadRequest();
        //    //}
        //    RepairOrder order = _context.RepairOrders.Find(id);
        //    _repairOrderHistoryService.AddHistory(order, repairOrder, actionHistory.Изменен);
        //    CopyValues<RepairOrder>(order, repairOrder);
        //    repairOrder.Id = id;

        //    _context.ChangeTracker.DetectChanges();
        //    Console.WriteLine(_context.ChangeTracker.DebugView.LongView);

        //    //_context.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RepairOrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/RepairOrders
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<RepairOrder>> PostRepairOrder(RepairOrder repairOrder)
        //{
        //  if (_context.RepairOrders == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.RepairOrder'  is null.");
        //  }
        //    _context.RepairOrders.Add(repairOrder);
        //    await _context.SaveChangesAsync();
        //    _repairOrderHistoryService.AddHistory(repairOrder, repairOrder, actionHistory.Добавлен);

        //    return CreatedAtAction("GetRepairOrder", new { id = repairOrder.Id }, repairOrder);
        //}

        //// DELETE: api/RepairOrders/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRepairOrder(int id)
        //{
        //    if (_context.RepairOrders == null)
        //    {
        //        return NotFound();
        //    }
        //    var repairOrder = await _context.RepairOrders.FindAsync(id);
        //    if (repairOrder == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.RepairOrders.Remove(repairOrder);
        //    await _context.SaveChangesAsync();
        //    _repairOrderHistoryService.AddHistory(repairOrder, repairOrder, actionHistory.Удален);

        //    return NoContent();
        //}

        //private bool RepairOrderExists(int id)
        //{
        //    return (_context.RepairOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
        //public void CopyValues<T>(T target, T source)
        //{
        //    Type t = typeof(T);

        //    var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite && prop.Name != "Id");

        //    foreach (var prop in properties)
        //    {
        //        var value = prop.GetValue(source, null);
        //        if (value is int)
        //            if ((int)value == 0)
        //                continue;
        //        if (value != null)
        //            prop.SetValue(target, value, null);
        //    }
        //}
        //public T GetDifference<T>(T oldData, T newData)
        //{
        //    Type t = typeof(T);

        //    var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite && prop.Name != "Id");
        //    T result = oldData;
        //    foreach (var prop in properties)
        //    {
        //        if (prop.GetValue(newData, null) != prop.GetValue(oldData, null))
        //            prop.SetValue(result, prop.GetValue(newData, null));
        //        else
        //            prop.SetValue(result, null);
        //        //var value = prop.GetValue(source, null);
        //        //if (value is int)
        //        //    if ((int)value == 0)
        //        //        continue;
        //        //if (value != null)
        //        //    prop.SetValue(target, value, null);
        //    }
        //    return result;
        //}
    }
}
