using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;

namespace webapi.Services
{
    public class RepairOrderService : IRepairOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepairOrderHistoryService _customerHistoryService;

        public RepairOrderService(ApplicationDbContext context, IRepairOrderHistoryService customerHistoryService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _customerHistoryService = customerHistoryService;
        }

        public async Task<RepairOrder> AddRepairOrder(RepairOrder repairOrder)
        {
            if (_context.RepairOrders == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            RepairOrder addingCustomer = _context.RepairOrders.Add(repairOrder).Entity;
            await _context.SaveChangesAsync();
            _customerHistoryService.AddHistory(repairOrder, repairOrder, actionHistory.Добавлен);

            return addingCustomer;
        }

        public async Task<RepairOrder> ChangeRepairOrder(RepairOrder repairOrder)
        {
            if (repairOrder.Id == 0)
            {
                throw new ArgumentException("Id клиента не может быть равен 0", "customer.Id");
            }
            var oldOrder = await _context.RepairOrders.FindAsync(repairOrder.Id);
            _context.Entry(repairOrder).State = EntityState.Modified;
            //_context.customerHistories.Add(new CustomerHistory);
            _customerHistoryService.AddHistory(oldOrder, repairOrder, actionHistory.Изменен);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairOrderExists(repairOrder.Id))
                {
                    throw new Exception("Клиент не найден");
                }
                else
                {
                    throw;
                }
            }

            return repairOrder;
        }

        public async Task DeleteRepairOrder(int id)
        {
            if (_context.Customer == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            var customer = await _context.RepairOrders.FindAsync(id);
            if (customer == null)
            {
                throw new ArgumentException($"Клиент с ID {id} не найден");
            }

            _context.RepairOrders.Remove(customer);
            await _context.SaveChangesAsync();
            _customerHistoryService.AddHistory(customer, customer, actionHistory.Удален);
        }

        public async Task<RepairOrder> GetRepairOrder(int id, bool WithIsSalesStages = false)
        {
            if (_context.RepairOrders == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            var customer = await _context.RepairOrders.FindAsync(id);// WithIsSalesStages 
                //? 
                //_context.RepairOrders.Include(x => x.Status).FirstOrDefault(x => x.Id == id)
                //: 
                //await _context.RepairOrders.FindAsync(id);

            if (customer == null)
            {
                throw new ArgumentException($"Клиент с ID {id} не найден");
            }

            return customer;
        }

        public async Task<List<RepairOrder>> GetRepairOrders(bool WithIsSalesStages = false)
        {
            if (_context.RepairOrders == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            return _context.RepairOrders.ToList(); //WithIsSalesStages ?
                //_context.RepairOrders.Include(x => x.Status).ToList()
                //:
                //_context.RepairOrders.ToList();
        }
        public RepairOrder SetNextSalesStages(int id)
        {
            var order = _context.RepairOrders.Find(id);
            var currentStages = _context.SalesStages.Find(order.SalesStagesId);
            order.SalesStagesId = currentStages.NextStagesId;
            _context.SaveChanges();
            return order;
        }
        public RepairOrder SetCancelSalesStages(int id)
        {
            var order = _context.RepairOrders.Find(id);
            var currentStages = _context.SalesStages.FirstOrDefault(x => x.IsCancelDefault == true);
            order.SalesStagesId = currentStages.Id;
            _context.SaveChanges();
            return order;
        }

        public async Task<List<Customer>> GetBirthdayBoy()
        {
            return _context.Customer.Where(x => x.Birthdate.Month == DateTime.UtcNow.Month && x.Birthdate.Day == DateTime.UtcNow.Day).ToList<Customer>();
        }
        private bool RepairOrderExists(int id)
        {
            return (_context.RepairOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
