using ApartmentBooking.Application.Abstractions.Messaging;
using System.Windows.Input;

namespace ApartmentBooking.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate
) : ICommand<Guid>;
