using EmsisoftTask.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmsisoftTask.Configurations.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            #region Connection String 

            services.AddDbContext<EmsisoftTaskDbContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("EmsisoftTaskConnectionString")));

            #endregion
        }
    }
}
