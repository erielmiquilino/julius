using System;

namespace Julius.Domain.Models
{
    public class PaymentActionModel
    {
        public Guid ExpenseId { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal PaymentValue { get; set; }
    }
}
