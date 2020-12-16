using Julius.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Julius.Data.Configurations
{
    public class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Income");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ReceivingDate)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.TotalValue)
                .IsRequired();

            builder.HasOne(p => p.Period);
            builder.Property(p => p.PeriodId)
                .IsRequired();
        }
    }
}
