using System;
using Julius.Domain.Enums;

namespace Julius.Domain.Models
{
    public class ExpenseModel
    {
        public Guid Id { get; set; }

        public string BillingDate { get; set; }

        public string Description { get; set; }

        public decimal TotalValue { get; set; }

        public decimal TotalPaid { get; set; }

        public ExpenseStatus Status { get; set; }
    }
}
