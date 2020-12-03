using Julius.Domain.Enums;
using System;

namespace Julius.Domain.DTOs
{
    public class ExpenseDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal TotalValue { get; set; }

        public decimal TotalPaid { get; set; }

        public ExpenseStatus Status { get; set; }
    }
}
