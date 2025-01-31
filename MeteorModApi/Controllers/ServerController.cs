using MeteorModApi.Models.ServerSync;
using MeteorModApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorModApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ServerController(IServerService serverService)
    : ControllerBase
{
    [HttpGet]
    public IEnumerable<ServerInfo> Get() => serverService.GetServers();

    [HttpPost]
    public void Post(ServerInfo serverInfo) => serverService.AddOrUpdateServer(serverInfo);

    [HttpDelete]
    [Route("{id:guid}")]
    public void Delete(Guid id) => serverService.RemoveServer(id);
}
