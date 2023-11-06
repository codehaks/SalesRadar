using SalesRadar.Domain.Values;

namespace SalesRadar.Domain;
public class Customer
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public required DateOfBirth DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }

    public bool IsActive { get; set; }
    public Subscription? CustomerSubscription { get; set; }
}

public class Subscription
{
    public SubscriptionType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Subscription(SubscriptionType type, DateTime startDate, DateTime endDate)
    {
        // Validate input data here
        if (endDate < startDate)
        {
            throw new ArgumentException("End date cannot be earlier than start date.");
        }

        Type = type;
        StartDate = startDate;
        EndDate = endDate;
    }
}

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public GenreType Genre { get; set; }
    public int ReleaseYear { get; set; }
    public TimeSpan Duration { get; set; }
    public SubscriptionType RequiredSubscription { get; set; }

}

public enum GenreType
{
    Action,
    Drama,
    Comedy,
    ScienceFiction,
    Fantasy,
    Horror,
    Romance,
    Thriller,
    Animation,
    Documentary,
    Other
}

public enum SubscriptionType
{
    Basic,
    Premium
}

public class MovieService
{
    public bool CanWatchMovie(Customer customer, Movie movie)
    {
        if (customer.CustomerSubscription?.Type >= movie.RequiredSubscription)
        {
            return true;
        }
        return false;
    }
}
