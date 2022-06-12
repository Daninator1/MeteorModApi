namespace MeteorModApi.Services;

public class PlayStatusService : IPlayStatusService
{
    private readonly int maxAgeInMinutes;
    private IDictionary<Guid, PlayStatusEntry> entries;

    public PlayStatusService(int maxAgeInMinutes)
    {
        this.maxAgeInMinutes = maxAgeInMinutes;
        this.entries = new Dictionary<Guid, PlayStatusEntry>();
    }

    public IEnumerable<PlayStatusEntry> GetEntries()
    {
        this.entries = this.FilterInactiveEntries(this.entries);
        return this.entries.Values;
    }

    public void AddOrUpdateEntry(PlayStatusEntry entry)
    {
        if (this.entries.ContainsKey(entry.PlayerId))
            this.entries[entry.PlayerId] = entry;
        else
            this.entries.Add(entry.PlayerId, entry);
    }

    public void RemoveEntry(Guid id)
    {
        if (this.entries.ContainsKey(id)) this.entries.Remove(id);
    }

    private IDictionary<Guid, PlayStatusEntry> FilterInactiveEntries(IDictionary<Guid, PlayStatusEntry> unfiltered)
        => unfiltered
            .Where(e => e.Value.Inserted.AddMinutes(this.maxAgeInMinutes) > DateTime.Now)
            .ToDictionary(e => e.Key, e => e.Value);
}