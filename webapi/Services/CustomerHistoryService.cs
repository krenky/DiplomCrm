using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;

namespace webapi.Services
{
    public class CustomerHistoryService : ICustomerHistoryService
    {
        private readonly ApplicationDbContext _context;

        public CustomerHistoryService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddHistory(Customer customer, actionHistory action)
        {
            CustomerHistory? lastHistory = _context.customerHistories.Where(x => x.CustomerId == customer.Id).OrderBy(x=>x.Id).LastOrDefault();
            if (lastHistory != null)
            {
                lastHistory = CloseLastHistory(lastHistory);
                CustomerHistory newHistory = ConvertToHistory(customer);
                newHistory.Start = lastHistory.End;
                newHistory.End = DateTime.MaxValue;
                newHistory.ActionHistory = action.ToString();
                _context.customerHistories.Add(newHistory);
                _context.SaveChanges();
            }
            else
            {
                CustomerHistory newHistory = ConvertToHistory(customer);
                newHistory.Start = DateTime.UtcNow;
                newHistory.End = DateTime.MaxValue;
                newHistory.ActionHistory = action.ToString();
                _context.customerHistories.Add(newHistory);
                _context.SaveChanges();
            }
        }
        private CustomerHistory CloseLastHistory(CustomerHistory lastHistory)
        {
            lastHistory.End = DateTime.UtcNow;
            _context.Entry(lastHistory).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return lastHistory;
        }
        public CustomerHistory ConvertToHistory(Customer customer)
        {
            return new CustomerHistory()
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Birthdate = customer.Birthdate
            };
        }
    }
}
