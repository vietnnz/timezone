using Microsoft.AspNetCore.Mvc;

namespace TimeZone.Controllers;

[ApiController]
[Route("")]
public class TimeZoneController : ControllerBase
{
    [HttpGet]
    public Task<IEnumerable<TimeZoneInfo>> Get()
    {
        return Task.FromResult<IEnumerable<TimeZoneInfo>>(TimeZoneInfo.GetSystemTimeZones());
    }
}
