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
    public DateOnly Value { get; }

    public DateOfBirth(DateOnly dateOfBirth)
    {
        if (dateOfBirth > DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentOutOfRangeException(nameof(dateOfBirth));
        }

        Value = dateOfBirth;
    }

}

