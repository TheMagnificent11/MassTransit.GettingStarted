namespace MassTransit.GettingStarted.Contracts;

public record Contract
{
    public string Value { get; init; } = string.Empty;
}