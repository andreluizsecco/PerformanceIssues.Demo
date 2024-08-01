using HighCPU.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HighCPU.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    [HttpPost("Generate")]
    public IActionResult Generate()
    {
        var reportService = new ReportService();
        var requestId = reportService.Generate();

        return Ok(new
        {
            requestId
        });
    }
}
