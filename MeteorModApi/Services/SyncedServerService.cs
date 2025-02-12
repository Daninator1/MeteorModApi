using System.Text.Json;
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
    private const string ServersFilePath = "data/servers.json";

    private readonly Dictionary<Guid, SyncedServerInfo> servers = LoadServers();

    public IEnumerable<SyncedServerInfo> GetServers() => this.servers.Values;

    public void AddOrUpdateServer(SyncedServerInfo syncedServer)
    {
        this.servers[syncedServer.Id] = syncedServer;
        SaveServers(this.servers);
    }

    public void RemoveServer(Guid id)
    {
        this.servers.Remove(id);
        SaveServers(this.servers);
    }

    private static Dictionary<Guid, SyncedServerInfo> LoadServers()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(ServersFilePath) ??
                                  throw new InvalidOperationException("Invalid servers file path"));

        if (!File.Exists(ServersFilePath))
        {
            return new Dictionary<Guid, SyncedServerInfo>();
        }

        var serversJson = File.ReadAllText(ServersFilePath);
        return JsonSerializer.Deserialize<Dictionary<Guid, SyncedServerInfo>>(serversJson) ??
               new Dictionary<Guid, SyncedServerInfo>();
    }

    private static void SaveServers(Dictionary<Guid, SyncedServerInfo> servers)
    {
        var serversJson = JsonSerializer.Serialize(servers);
        File.WriteAllText(ServersFilePath, serversJson);
    }
}
