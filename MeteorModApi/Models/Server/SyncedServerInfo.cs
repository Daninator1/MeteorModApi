using System.ComponentModel.DataAnnotations;

namespace MeteorModApi.Models.Server;

public record SyncedServerInfo(Guid Id, [MinLength(1)] string Name, [MinLength(1)] string Address);
