using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRadar.Domain.Values;
public class PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string phoneNumber)
    {
        if (!IsValidPhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Invalid phone number format.");
        }

        Value = phoneNumber;
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        // Implement your phone number validation logic here, e.g., using regular expressions.
        // This can vary depending on your specific requirements.
        // For example, you can use regular expressions or libraries like libphonenumber.
        // For this example, we'll use a simple format check.
        return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length >= 10;
    }

    // You can add additional methods or behaviors related to phone numbers if needed.
}
