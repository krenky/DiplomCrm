using webapi.Models;

namespace webapi.Interfaсe
{
    public interface IRepairOrderService
    {
        Task<RepairOrder> AddRepairOrder(RepairOrder repairOrder);
        Task<RepairOrder> ChangeRepairOrder(RepairOrder repairOrder);
        Task DeleteRepairOrder(int id);
        Task<List<Customer>> GetBirthdayBoy();
        Task<RepairOrder> GetRepairOrder(int id, bool WithIsSalesStages = false);
        Task<List<RepairOrder>> GetRepairOrders(bool WithIsSalesStages = false);
        public RepairOrder SetCancelSalesStages(int id);
        public RepairOrder SetNextSalesStages(int id);
    }
}