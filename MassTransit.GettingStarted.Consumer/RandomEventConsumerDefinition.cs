using MassTransit;

namespace MassTransit.GettingStarted.Consumer;

public class RandomEventConsumerDefinition : ConsumerDefinition<RandomEventConsumer>
{
    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator, 
        IConsumerConfigurator<RandomEventConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
    }
}
