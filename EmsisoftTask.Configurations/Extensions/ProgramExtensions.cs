using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmsisoftTask.Configurations.Extensions
{
    public static class ProgramExtensions
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);

            services.RegisterApplicationServices();
            services.RegisterApplicationRepositories();
        }
    }
}
