using AspireApp.ServiceDefaults.Models;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Hosting;

public static partial class ClickLoggerExtensions
{
    [LoggerMessage(
        EventId = 1,
        EventName = "",
        Level = LogLevel.Information,
        Message = "Button clicked")]
    public static partial void ClickButton(this ILogger logger, [LogProperties] Click click);
}
