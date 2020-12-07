using System;
using System.Collections.Generic;
using System.Text;
using Julius.Domain.Enums;

namespace Julius.Domain.Models
{
    public class CreateExpenseModel
    {
        public string BillingDate { get; set; }

        public string Description { get; set; }

        public decimal TotalValue { get; set; }

        public decimal TotalPaid { get; set; }

        public ExpenseStatus Status { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }
    }
}
