using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MeteorModApi.Models;

public class PlayStatusEntry
{
    [MinLength(1)] public required string Name { get; init; }
    [MinLength(1)] public required string PlayerName { get; init; }
    [MinLength(1)] public required string Server { get; init; }
    public required double PosX { get; set; }
    public required double PosY { get; set; }
    public required double PosZ { get; set; }
    public DateTime Inserted { get; } = DateTime.Now;
}