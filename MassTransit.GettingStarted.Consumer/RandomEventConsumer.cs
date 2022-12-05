using MassTransit.GettingStarted.Contracts;
using Microsoft.Extensions.Logging;

namespace MassTransit.GettingStarted.Consumer;

public class RandomEventConsumer : IConsumer<RandomEvent>
{
    private readonly ILogger<RandomEventConsumer> logger;

    public RandomEventConsumer(ILogger<RandomEventConsumer> logger)
    {
        this.logger = logger;
    }
    
    public Task Consume(ConsumeContext<RandomEvent> context)
    {
        this.logger.LogInformation("Received Text: {Text}", context.Message.Value);

        return Task.CompletedTask;
    }
}
