namespace MeteorModApi.Services;

public class PlayStatusService : IPlayStatusService
{
    private readonly int maxAgeInMinutes;
    private IDictionary<string, PlayStatusEntry> entries;

    public PlayStatusService(int maxAgeInMinutes)
    {
        this.maxAgeInMinutes = maxAgeInMinutes;
        this.entries = new Dictionary<string, PlayStatusEntry>();
    }

    public IEnumerable<PlayStatusEntry> GetEntries()
    {
        this.entries = this.FilterInactiveEntries(this.entries);
        return this.entries.Values;
    }

    public void AddOrUpdateEntry(PlayStatusEntry entry)
    {
        if (this.entries.ContainsKey(entry.Name))
            this.entries[entry.Name] = entry;
        else
            this.entries.Add(entry.Name, entry);
    }

    public void RemoveEntry(string name)
    {
        if (this.entries.ContainsKey(name)) this.entries.Remove(name);
    }

    private IDictionary<string, PlayStatusEntry> FilterInactiveEntries(IDictionary<string, PlayStatusEntry> unfiltered)
        => unfiltered
            .Where(e => e.Value.Inserted.AddMinutes(this.maxAgeInMinutes) > DateTime.Now)
            .ToDictionary(e => e.Key, e => e.Value);
}