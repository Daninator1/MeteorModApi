using System.ComponentModel.DataAnnotations;

namespace MeteorModApi.Models.PlayStatus;

public record PlayStatusEntry(
    [MinLength(1)] string Name,
    [MinLength(1)] string PlayerName,
    [MinLength(1)] string Server,
    PlayStatusPosition Position,
    [MinLength(1)] string Dimension)
{
    public DateTime Inserted { get; } = DateTime.Now;
}
