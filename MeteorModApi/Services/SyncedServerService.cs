using MeteorModApi.Models.Server;

namespace MeteorModApi.Services;

public interface ISyncedServerService
{
    IEnumerable<SyncedServerInfo> GetServers();
    void AddOrUpdateServer(SyncedServerInfo syncedServer);
    void RemoveServer(Guid id);
}

public class SyncedSyncedServerService : ISyncedServerService
{
    private readonly Dictionary<Guid, SyncedServerInfo> servers = new();

    public IEnumerable<SyncedServerInfo> GetServers() => this.servers.Values;

    public void AddOrUpdateServer(SyncedServerInfo syncedServer) => this.servers[syncedServer.Id] = syncedServer;

    public void RemoveServer(Guid id) => this.servers.Remove(id);
}
