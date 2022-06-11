namespace MeteorModApi.Services;

public class PlayStatusService : IPlayStatusService
{
    private readonly IDictionary<Guid, PlayStatusEntry> entries;

    public PlayStatusService()
    {
        this.entries = new Dictionary<Guid, PlayStatusEntry>();
    }

    public IEnumerable<PlayStatusEntry> GetEntries() => this.entries.Values;

    public void AddOrUpdateEntry(PlayStatusEntry entry)
    {
        if (this.entries.ContainsKey(entry.PlayerId))
        {
            this.entries[entry.PlayerId] = entry;
        }
        else
        {
            this.entries.Add(entry.PlayerId, entry);
        }
    }

    public void RemoveEntry(Guid id)
    {
        if (this.entries.ContainsKey(id))
        {
            this.entries.Remove(id);
        }
    }
}