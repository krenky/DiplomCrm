using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;
using webapi.Utils;

namespace webapi.Services
{
    public class RepairOrderHistoryService : IRepairOrderHistoryService
    {
        private readonly ApplicationDbContext _context;

        public RepairOrderHistoryService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddHistory(RepairOrder oldOrder, RepairOrder newOrder, actionHistory action)
        {
            RepairOrderHistory? lastHistory = _context.RepairOrderHistory.Where(x => x.RepairOrderId == newOrder.Id).OrderBy(x => x.Id).LastOrDefault();
            if (lastHistory != null)
            {
                lastHistory = CloseLastHistory(lastHistory);
                RepairOrderHistory newHistory = action == actionHistory.Изменен 
                    ?GetHistoryDifference(oldOrder, newOrder)
                    :ConvertToHistory(oldOrder);
                newHistory.Start = lastHistory.End;
                newHistory.End = DateTime.MaxValue;
                newHistory.ActionHistory = action.ToString();
                _context.RepairOrderHistory.Add(newHistory);
                _context.SaveChanges();//Todo ошибка
            }
            else
            {
                RepairOrderHistory newHistory = action == actionHistory.Изменен
                    ? GetHistoryDifference(oldOrder, newOrder)
                    : ConvertToHistory(oldOrder);
                newHistory.Start = DateTime.UtcNow;
                newHistory.End = DateTime.MaxValue;
                newHistory.ActionHistory = action.ToString();
                _context.RepairOrderHistory.Add(newHistory);
                _context.SaveChanges();
            }
        }
        private RepairOrderHistory CloseLastHistory(RepairOrderHistory lastHistory)
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
        public RepairOrderHistory ConvertToHistory(RepairOrder order)
        {
            return new RepairOrderHistory()
            {
                RepairOrderId = order.Id,
                CustomerId = order.CustomerId,
                DeviceId = order.DeviceId,
                SalesStagesId = order.SalesStagesId,
                Description = order.Description,
                Created = order.Created,
                Updated = order.Updated,
                ApplicationUserId = order.ApplicationUserId,
                LoyaltyDiscount = order.LoyaltyDiscount,
                Price = order.Price
            };
        }
        public RepairOrderHistory GetHistoryDifference(RepairOrder oldOrder, RepairOrder newOrder)
        {
            var result = UtilsClass.GetDifference<RepairOrder>(oldOrder, newOrder);
            return ConvertToHistory(result);
        }
    }
}
