namespace MeteorModApi.Models.ServerSync;

public class ServerInfo
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Address { get; init; }
}
