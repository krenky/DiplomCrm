using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;

namespace webapi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (_context.Customer == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            Customer addingCustomer = _context.Customer.Add(customer).Entity;
            await _context.SaveChangesAsync();
            
            return addingCustomer;
        }

        public async Task<Customer> ChangeCustomer(Customer customer)
        {
            if (customer.Id == 0)
            {
                throw new ArgumentException("Id клиента не может быть равен 0", "customer.Id");
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.Id))
                {
                    throw new Exception("Клиент не найден");
                }
                else
                {
                    throw;
                }
            }

            return customer;
        }

        public async Task DeleteCustomer(int id)
        {
            if (_context.Customer == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                throw new ArgumentException($"Клиент с ID {id} не найден");
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            if (_context.Customer == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                throw new ArgumentException($"Клиент с ID {id} не найден");
            }

            return customer;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            if (_context.Customer == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.Customer'  is null.");
            }
            return await _context.Customer.ToListAsync();
        }

        public async Task<List<Customer>> GetBirthdayBoy()
        {
            return _context.Customer.Where(x => x.Birthdate.Month == DateTime.UtcNow.Month && x.Birthdate.Day == DateTime.UtcNow.Day).ToList<Customer>();
        }
        private bool CustomerExists(int id)
        {
            return (_context.Customer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
