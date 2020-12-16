using Julius.Domain.Contracts.Services;
using Julius.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Julius.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<IExpenseService, ExpenseService>();
            serviceDescriptors.AddTransient<IIncomeService, IncomeService>();
            serviceDescriptors.AddTransient<IPeriodService, PeriodService>();
        }
    }
}
