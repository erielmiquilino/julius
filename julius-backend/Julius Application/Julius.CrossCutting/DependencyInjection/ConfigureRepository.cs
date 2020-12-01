using Julius.Data.Context;
using Julius.Data.Repositories.Base;
using Julius.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Julius.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddDbContext<JuliusContext>(
                options => options.UseSqlServer("Data Source=localhost;Initial Catalog=Julius;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120")
            );

            serviceDescriptors.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
