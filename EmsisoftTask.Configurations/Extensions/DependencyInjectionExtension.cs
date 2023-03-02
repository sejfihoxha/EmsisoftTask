using EmsisoftTask.Data.Repositories.Generics;
using EmsisoftTask.Data.Repositories.Hashes;
using EmsisoftTask.Services.RabitMQ;
using EmsisoftTask.Services.Services.Hashes;
using Microsoft.Extensions.DependencyInjection;

namespace EmsisoftTask.Configurations.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRabitMQProducer, RabitMQProducer>();

            services.AddScoped<IHashService, HashService>();
        }

        public static void RegisterApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IHashRepository, HashRepository>();
        }

    }
}
