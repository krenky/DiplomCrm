using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;

namespace webapi.Services
{
    public class AdvertisingСompanyService : IAdvertisingСompanyService
    {
        private readonly ApplicationDbContext _context;

        public AdvertisingСompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdvertisingСompany> Change(AdvertisingСompany сompany)
        {
            _context.Entry(сompany).State = EntityState.Modified;
            _context.SaveChanges();
            return сompany;
        }

        public async Task<AdvertisingСompany> Create(AdvertisingСompany сompany)
        {
            try
            {
                var result = _context.AdvertisingСompany.Add(сompany);
                _context.SaveChanges();
                return сompany;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<AdvertisingСompany>> GetList()
        {
            return await _context.AdvertisingСompany.Include(x=>x.RepairOrders).ToListAsync();
        }
    }
}
