using DBManager.Worker;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<KeyValuePairsContext>(options =>
        options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));
    })
    .Build();

host.Run();
