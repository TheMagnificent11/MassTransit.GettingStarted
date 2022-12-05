namespace MassTransit.GettingStarted.Contracts;

public record RandomEvent
{
    public string Value { get; init; } = string.Empty;
}