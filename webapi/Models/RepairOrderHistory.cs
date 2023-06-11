using static webapi.Models.RepairOrder;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace webapi.Models
{
    public class RepairOrderHistory
    {
        private actionHistory action;
        public int Id { get; set; }
        public int RepairOrderId { get; set; }
        public int? CustomerId { get; set; }
        public Device? Device { get; set; }
        public int? DeviceId { get; set; }
        //public SalesStages? Status { get; set; }
        public int? SalesStagesId { get; set; }
        public string? Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? ApplicationUserId { get; set; }
        //public ApplicationUser? ApplicationUser { get; set; }
        public bool? LoyaltyDiscount { get; set; } 
        public decimal? Price { get; set; }
        public string ActionHistory
        {
            get
            {
                return action.ToString();
            }
            set
            {
                switch (value)
                {
                    case "Добавлен":
                        {
                            action = actionHistory.Добавлен;
                        }
                        break;
                    case "Изменен":
                        {
                            action = actionHistory.Изменен;
                        }
                        break;
                    case "Удален":
                        {
                            action = actionHistory.Удален;
                        }
                        break;
                }
            }
        }
    }
}
