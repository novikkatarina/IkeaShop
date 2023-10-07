using Microsoft.AspNetCore.Mvc;

namespace Notifier.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
  [HttpPost("send")]
  public async Task<IActionResult> SendEmail()
  {
    return Ok();
  }
}
