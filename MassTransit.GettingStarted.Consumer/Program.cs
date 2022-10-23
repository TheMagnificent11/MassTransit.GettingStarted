using Microsoft.Extensions.Hosting;

namespace MassTransit.GettingStarted.Consumer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddMassTransit(x =>
                {
                    x.AddConsumer<ContractConsumer>();

                    x.UsingInMemory((context, cfg) =>
                    {
                        cfg.ConfigureEndpoints(context);
                    });
                });
            })
            .Build()
            .RunAsync();
    }
}
