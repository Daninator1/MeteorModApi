using System.ComponentModel.DataAnnotations;

namespace MeteorModApi;

public class PlayStatusEntry
{
    [MinLength(1)]
    public string Name { get; init; }

    public string PlayerName { get; init; }

    public string Server { get; init; }
    
    public DateTime Inserted { get; } = DateTime.Now;

}