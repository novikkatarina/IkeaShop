using Microsoft.AspNetCore.Mvc;
using Notifier.Models;
using Notifier.Services;

namespace Notifier.Controllers
{
  /// <summary>
  /// API controller for sending email notifications.
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class EmailController : ControllerBase
  {
    private readonly PaymentDataService paymentDataService;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailController"/> class.
    /// </summary>
    /// <param name="paymentDataService">The service responsible for sending email notifications.</param>
    public EmailController(PaymentDataService paymentDataService)
    {
      this.paymentDataService = paymentDataService;
    }

    /// <summary>
    /// Sends an email notification based on the provided payment data.
    /// </summary>
    /// <param name="paymentData">The payment data and recipient information.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the email sending operation.</returns>
    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] PaymentData paymentData)
    {
      await paymentDataService.SentEmail(paymentData);
      return Ok();
    }
  }
}
