using System.ComponentModel.DataAnnotations;

namespace MeteorModApi.Models;

public class PlayStatusEntry
{
    [MinLength(1)] public required string Name { get; init; }

    [MinLength(1)] public required string PlayerName { get; init; }

    [MinLength(1)] public required string Server { get; init; }

    public DateTime Inserted { get; } = DateTime.Now;
}