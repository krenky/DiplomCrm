using webapi.Models;

namespace webapi.Interfaсe
{
    public interface IRepairOrderHistoryService
    {
        void AddHistory(RepairOrder oldOrder, RepairOrder newOrder, actionHistory action);
        RepairOrderHistory ConvertToHistory(RepairOrder order);
    }
}