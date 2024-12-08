namespace ApartmentBooking.Domain.Bookings;

public record DateRange
{ 
    private DateRange() { }

    public DateOnly Start { get; init; }

    public DateOnly End { get; init; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end) {
            throw new ApplicationException("Start Date cannot be greater than End Date");
        }

        return new DateRange() { Start = start, End = end };
    }
}
