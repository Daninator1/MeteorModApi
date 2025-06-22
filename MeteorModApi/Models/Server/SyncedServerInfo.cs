using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace MeteorModApi.Models.Server;

[PublicAPI]
public record SyncedServerInfo(Guid Id, [MinLength(1)] string Name, [MinLength(1)] string Address);
