using MeteorModApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorModApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PlayStatusController : ControllerBase
{
    private readonly ILogger<PlayStatusController> logger;
    private readonly IPlayStatusService playStatusService;

    public PlayStatusController(ILogger<PlayStatusController> logger, IPlayStatusService playStatusService)
    {
        this.logger = logger;
        this.playStatusService = playStatusService;
    }

    [HttpGet]
    public IEnumerable<PlayStatusEntry> Get() => this.playStatusService.GetEntries();

    [HttpPost]
    public void Post(PlayStatusEntry playerEntry) => this.playStatusService.AddOrUpdateEntry(playerEntry);

    [HttpDelete]
    [Route("{name}")]
    public void Delete(string name) => this.playStatusService.RemoveEntry(name);
}