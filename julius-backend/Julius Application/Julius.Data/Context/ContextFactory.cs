using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Julius.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<JuliusContext>
    {
        public JuliusContext CreateDbContext(string[] args)
        {
            const string connectionString = "Data Source=localhost;Initial Catalog=Julius;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";

            var optionBuilder = new DbContextOptionsBuilder<JuliusContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new JuliusContext(optionBuilder.Options);
        }

    }
}
