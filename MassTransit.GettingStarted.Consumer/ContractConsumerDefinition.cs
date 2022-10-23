using MassTransit;

namespace MassTransit.GettingStarted.Consumer;

public class ContractConsumerDefinition : ConsumerDefinition<ContractConsumer>
{
    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator, 
        IConsumerConfigurator<ContractConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
    }
}
