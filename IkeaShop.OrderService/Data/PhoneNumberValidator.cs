using System.Text.RegularExpressions;

namespace IkeaShop.OrderService.Data;

/// <summary>
/// Utility class for validating phone numbers using regular expressions.
/// </summary>
public class PhoneNumberValidator
{
  /// <summary>
  /// Validates a phone number using a regular expression pattern.
  /// </summary>
  /// <param name="number">The phone number to validate.</param>
  /// <returns>True if the phone number is valid; otherwise, false.</returns>
  /// <exception cref="ArgumentException">Thrown when the phone number is invalid.</exception>
  public static bool Validate(string number)
  {
    var regex = new Regex(@"^(?:\+7|8)(?:\s?\(\d{3}\)\s?|\s?\d{3}-)\d{3}-\d{2}-\d{2}$");
    var isValid = regex.IsMatch(number);
    if (!isValid)
      throw new ArgumentException("Phone number is invalid");
    else
    {
      return true;
    }
  }
}