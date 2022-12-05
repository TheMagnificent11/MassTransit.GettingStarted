using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit.GettingStarted.Contracts;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MassTransit.GettingStarted.Worker;

public class RandomEventWorker : BackgroundService
{
    private readonly IBus bus;
    private readonly ILogger<RandomEventWorker> logger;

    public RandomEventWorker(IBus bus, ILogger<RandomEventWorker> logger)
    {
        this.bus = bus;
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var randomEvent = new RandomEvent { Value = $"The time is {DateTimeOffset.Now}" };

            await this.bus.Publish(randomEvent);
            this.logger.LogInformation("Event published with {Text}", randomEvent.Value);

            await Task.Delay(1000, stoppingToken);
        }
    }
}
