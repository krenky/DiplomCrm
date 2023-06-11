using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/chart/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/api/chart/repairorderwithcompany")]
        public async Task<IEnumerable<RepairOrder>> GetRepairOrdersAsync()
        {
            return await _context.RepairOrders
                .Include(x => x.Customer)
                .Include(x=>x.repairWorks)
                .Include(x=>x.PartsUsed)
                .Include(x => x.AdvertisingСompany).ToListAsync();
        }
        [HttpGet("/api/chart/salesstages")]
        public async Task<IEnumerable<SalesStages>> GetSalesSatgesAsync()
        {
            var stages = await _context.SalesStages.ToListAsync();
            foreach(var stage in stages)
            {
                stage.Orders = _context.RepairOrders
                    .Include(x => x.Customer)
                    .Include(x => x.repairWorks)
                    .Include(x => x.PartsUsed)
                    .Where(x => x.SalesStagesId == stage.Id).ToList();
            }
            return stages;
        }
        [HttpGet("/api/chart/advertisingcompany")]
        public async Task<IEnumerable<AdvertisingСompany>> GetAdvertisingСompanyAsync()
        {
            return await _context.AdvertisingСompany
                .Include(x => x.RepairOrders).ToListAsync();
        }
    }
}
