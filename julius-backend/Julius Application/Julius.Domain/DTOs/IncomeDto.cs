using System;
using System.Collections.Generic;
using System.Text;

namespace Julius.Domain.DTOs
{
    public class IncomeDto
    {
        public string ReceivingDate { get; set; }

        public string Description { get; set; }

        public decimal TotalValue { get; set; }
    }
}
