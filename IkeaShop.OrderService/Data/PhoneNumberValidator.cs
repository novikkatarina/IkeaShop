using System.Text.RegularExpressions;

namespace IkeaShop.OrderService.Data;

public class PhoneNumberValidator
{
    public static void Validate(string number)
    {
        var regex = new Regex(@"^(?:\+7|8)(?:\s?\(\d{3}\)\s?|\s?\d{3}-)\d{3}-\d{2}-\d{2}$");
        var isValid  = regex.IsMatch(number);
        if (!isValid)
            throw new ArgumentException("Phone number is invalid");
    }
}