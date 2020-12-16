using System;
using Julius.Domain.Domains.Base;
using Julius.Domain.Enums;
using Julius.Domain.Models;

namespace Julius.Domain.Domains
{
    public class Expense : BaseEntity
    {
        public string BillingDate { get; set; }

        public string Description { get; set; }

        public decimal TotalValue { get; set; }

        public decimal TotalPaid { get; set; }

        public ExpenseStatus Status { get; set; }

        public Guid PeriodId { get; set; }

        public virtual Period Period { get; set; }

        public void UpdateExpenseStatus(ExpenseStatus expenseStatus)
        {
            Status = expenseStatus;
        }

        public void UpdateByPaymentAction(PaymentActionModel paymentActionModel)
        {
            UpdateExpenseStatus(paymentActionModel.PaymentValue == TotalValue
                ? ExpenseStatus.Paid
                : ExpenseStatus.Partial);

            TotalPaid = paymentActionModel.PaymentValue;
        }
    }
}
