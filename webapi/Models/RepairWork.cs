﻿namespace webapi.Models
{
    public class RepairWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<RepairOrder> repairOrders { get; set; } = new List<RepairOrder>();
    }
}