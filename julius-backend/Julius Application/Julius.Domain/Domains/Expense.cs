using System;
using Julius.Domain.Domains.Base;
using Julius.Domain.Enums;

namespace Julius.Domain.Domains
{
    public class Expense : BaseEntity
    {
        public string BillingDate { get; set; }

        public string Description { get; set; }

        public decimal TotalValue { get; set; }

        public decimal TotalPaid { get; set; }

        public ExpenseStatus Status { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        public void UpdateExpenseStatus()
        {
            Status = ExpenseStatus.Opened;
        }
    }
}
