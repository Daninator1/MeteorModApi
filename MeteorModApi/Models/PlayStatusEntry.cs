namespace MeteorModApi;

public class PlayStatusEntry
{
    public Guid PlayerId { get; init; }

    public string PlayerName { get; init; }

    public string Server { get; init; }
    
    public DateTime Inserted { get; } = DateTime.Now;

}