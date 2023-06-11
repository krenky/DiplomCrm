using webapi.Models;

namespace webapi.Interfaсe
{
    public interface ICustomerHistoryService
    {
        void AddHistory(Customer customer, actionHistory action);
        CustomerHistory ConvertToHistory(Customer customer);
    }
}