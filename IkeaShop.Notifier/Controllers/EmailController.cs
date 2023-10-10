using Microsoft.AspNetCore.Mvc;
using Notifier.Services;

namespace Notifier.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
  private readonly PaymentDataService paymentDataService ;

  public EmailController(
    PaymentDataService paymentDataService
  )
  {
    this.paymentDataService = paymentDataService;
  }
  
  [HttpPost("send")]
  public async Task<IActionResult> SendEmail([FromBody]PaymentData paymentData)
  {
    await paymentDataService.SentEmail(paymentData);
    return Ok();
  }
}
