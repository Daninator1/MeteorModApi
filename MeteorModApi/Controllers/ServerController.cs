using MeteorModApi.Models.Server;
using MeteorModApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorModApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ServerController(ISyncedServerService syncedServerService)
    : ControllerBase
{
    [HttpGet]
    public IEnumerable<SyncedServerInfo> Get() => syncedServerService.GetServers();

    [HttpPost]
    public void Post(SyncedServerInfo syncedServerInfo) => syncedServerService.AddOrUpdateServer(syncedServerInfo);

    [HttpDelete]
    [Route("{id:guid}")]
    public void Delete(Guid id) => syncedServerService.RemoveServer(id);
}
