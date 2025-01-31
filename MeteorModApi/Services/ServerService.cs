using MeteorModApi.Models.ServerSync;

namespace MeteorModApi.Services;

public interface IServerService
{
    IEnumerable<ServerInfo> GetServers();
    void AddOrUpdateServer(ServerInfo server);
    void RemoveServer(Guid id);
}

public class ServerService : IServerService
{
    private readonly Dictionary<Guid, ServerInfo> servers = new();

    public IEnumerable<ServerInfo> GetServers() => this.servers.Values;

    public void AddOrUpdateServer(ServerInfo server) => this.servers[server.Id] = server;

    public void RemoveServer(Guid id) => this.servers.Remove(id);
}
