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

        return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == 11;
    }

   
}
