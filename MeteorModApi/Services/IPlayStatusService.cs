using MeteorModApi.Models;

namespace MeteorModApi.Services;

public interface IPlayStatusService
{
    IEnumerable<PlayStatusEntry> GetEntries();
    void AddOrUpdateEntry(PlayStatusEntry entry);
    void RemoveEntry(string id);
}