using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRadar.Domain.Values;

[ComplexType]
public class DateOfBirth
{
    public DateTime Value { get; }

    public DateOfBirth(DateTime dateOfBirth)
    {
        if (dateOfBirth.Date > DateTime.UtcNow.Date)
        {
            throw new ArgumentOutOfRangeException(nameof(dateOfBirth));
        }

        Value = dateOfBirth;
    }

}

