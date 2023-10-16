namespace SalesRadar.Domain.Values;
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

