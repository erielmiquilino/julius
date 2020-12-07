using Julius.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Julius.Data.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expense");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.TotalValue)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(p => p.TotalPaid)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.BillingDate)
                .HasDefaultValue(string.Empty)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(p => p.Month)
                .IsRequired();

            builder.Property(p => p.Year)
                .IsRequired();
        }
    }
}
