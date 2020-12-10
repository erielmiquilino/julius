using Julius.Domain.Domains.Base;

namespace Julius.Domain.Domains
{
    public class Income : BaseEntity
    {
        public string ReceivingDate { get; set; }

        public string Description { get; set; }

        public decimal TotalValue { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }
    }
}
