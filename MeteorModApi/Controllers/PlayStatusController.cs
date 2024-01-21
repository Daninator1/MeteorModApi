using MeteorModApi.Models;
using MeteorModApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorModApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PlayStatusController(IPlayStatusService playStatusService)
    : ControllerBase
{
    [HttpGet]
    public IEnumerable<PlayStatusEntry> Get() => playStatusService.GetEntries();

    [HttpPost]
    public void Post(PlayStatusEntry playerEntry) => playStatusService.AddOrUpdateEntry(playerEntry);

    [HttpDelete]
    [Route("{name}")]
    public void Delete(string name) => playStatusService.RemoveEntry(name);
}