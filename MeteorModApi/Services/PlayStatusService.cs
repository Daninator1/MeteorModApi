using MeteorModApi.Models.PlayStatus;

namespace MeteorModApi.Services;

public interface IPlayStatusService
{
    IEnumerable<PlayStatusEntry> GetEntries();
    void AddOrUpdateEntry(PlayStatusEntry entry);
    void RemoveEntry(string id);
}

public class PlayStatusService(int maxAgeInMinutes) : IPlayStatusService
{
    private Dictionary<string, PlayStatusEntry> entries = new();

    public IEnumerable<PlayStatusEntry> GetEntries()
    {
        this.entries = this.FilterInactiveEntries(this.entries);
        return this.entries.Values;
    }

    public void AddOrUpdateEntry(PlayStatusEntry entry) => this.entries[entry.Name] = entry;

    public void RemoveEntry(string name) => this.entries.Remove(name);

    private Dictionary<string, PlayStatusEntry> FilterInactiveEntries(IDictionary<string, PlayStatusEntry> unfiltered)
        => unfiltered
            .Where(e => e.Value.Inserted.AddMinutes(maxAgeInMinutes) > DateTime.Now)
            .ToDictionary(e => e.Key, e => e.Value);
}
