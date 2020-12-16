using System;
using Julius.Domain.Domains.Base;

namespace Julius.Domain.Domains
{
    public class Income : BaseEntity
    {
        public string ReceivingDate { get; set; }

        public string Description { get; set; }

        public decimal TotalValue { get; set; }

        public Guid PeriodId { get; set; }

        public virtual Period Period { get; set; }
    }
}
