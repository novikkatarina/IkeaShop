namespace Notifier.Services;

using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;

public class PaymentDataService
{
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
            message.Body = "Hello, Dear Customer, " + content.Name +
                           ". We are happy to notify you about the status of your order." +
                           "As soon as it has been payed already and Total Price amounted to " +
                           content.Price +
                           ". Your Order is assembling now. The Estimated Delivery Time is " +
                           content.EstimatedDeliveryTime;
            client.Send(message);
          }

          Console.WriteLine("skxol");
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
