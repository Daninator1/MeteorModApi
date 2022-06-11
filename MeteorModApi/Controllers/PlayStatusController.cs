using MeteorModApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeteorModApi.Controllers;

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
    [Route("{id:guid}")]
    public void Delete(Guid id) => this.playStatusService.RemoveEntry(id);
}