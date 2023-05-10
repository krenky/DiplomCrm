using webapi.Models;

namespace webapi.Interfaсe
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> ChangeCustomer(Customer customer);
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
        Task DeleteCustomer(int id);
        Task<List<Customer>> GetBirthdayBoy();
    }
}
