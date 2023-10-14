using System.Globalization;
using Notifier.Models;

namespace Notifier.Services;

using System.Net;
using System.Net.Mail;

/// <summary>
/// Provides methods to send email notifications related to payment data.
/// </summary>
public class PaymentDataService
{
  /// <summary>
  /// Sends an email notification to the customer with payment and order information.
  /// </summary>
  /// <param name="content">The payment data and customer information.</param>
  public async Task SentEmail(PaymentData content)
  {
    int i = 0;
    while (i != 5)
    {
      try
      {
        using (var client = new SmtpClient())
        {
          client.Host = "smtp.gmail.com";
          client.Port = 587;
          client.DeliveryMethod = SmtpDeliveryMethod.Network;
          client.UseDefaultCredentials = false;
          client.EnableSsl = true;
          client.Credentials =
            new NetworkCredential("novikkatarina@gmail.com",
              "vvvz cqya buro yexk");
          using (var message = new MailMessage(
                   from: new MailAddress("novikkatarina@gmail.com",
                     "Ikea-Shop"),
                   to: new MailAddress(content.Email, content.Name)
                 ))
          {
            message.Subject = "IkeaShop Delivery";

            // Format the date
            string formattedDate = content.EstimatedDeliveryTime
              .ToUniversalTime()
              .AddHours(4) // Adding 4 hours for GMT+4
              .ToString("dd.MM.yyyy HH:mm 'GMT+4'",
                CultureInfo.InvariantCulture);

            message.Body = "Hello, Dear Customer, " + content.Name +
                           ". We are happy to notify you about the status of your order." +
                           "As soon as it has been paid already and Total Price amounted to " +
                           content.Price +
                           ". Your Order is assembling now. The Estimated Delivery Time is " +
                           formattedDate;
            client.Send(message);
          }

          Console.WriteLine("Sent");
          break;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }

      i++;
    }
  }
}
