using System;

namespace Julius.Domain.DTOs
{
    public class AmountExpenseDto
    {
        public Guid Id { get; set; }

        public decimal TotalValue { get; set; }

        public decimal TotalPaid { get; set; }
    }
}
