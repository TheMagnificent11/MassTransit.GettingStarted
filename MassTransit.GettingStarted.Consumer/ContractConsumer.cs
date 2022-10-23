using MassTransit.GettingStarted.Contracts;

namespace MassTransit.GettingStarted.Consumer;

public class ContractConsumer : IConsumer<Contract>
{
    public Task Consume(ConsumeContext<Contract> context)
    {
        return Task.CompletedTask;
    }
}
