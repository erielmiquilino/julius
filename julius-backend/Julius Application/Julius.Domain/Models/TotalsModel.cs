namespace Julius.Domain.Models
{
    public class TotalsModel
    {
        public decimal SpendingForecast { get; set; }

        public decimal TotalPaid { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalAvailable { get; set; }

        public decimal CurrentInAccounts { get; set; }
    }
}
