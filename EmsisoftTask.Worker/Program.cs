

using EmsisoftTask.Data.Repositories.Hashes;
using EmsisoftTask.Worker.Consumer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<RabitMqConsumer>();
        services.AddScoped<IHashRepository, HashRepository>();
    })
    .Build()
    .Run();
