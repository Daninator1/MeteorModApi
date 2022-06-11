namespace MeteorModApi.Services;

public interface IPlayStatusService
{
    IEnumerable<PlayStatusEntry> GetEntries();
    void AddOrUpdateEntry(PlayStatusEntry entry);
    void RemoveEntry(Guid id);
}