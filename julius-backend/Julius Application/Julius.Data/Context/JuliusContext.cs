using Julius.Data.Configurations;
using Julius.Domain.Domains;
using Microsoft.EntityFrameworkCore;

namespace Julius.Data.Context
{
    public class JuliusContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public JuliusContext(DbContextOptions<JuliusContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Expense>(new ExpenseConfiguration().Configure);
        }
    }
}
