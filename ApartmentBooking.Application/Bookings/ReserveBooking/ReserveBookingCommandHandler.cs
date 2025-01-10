using ApartmentBooking.Application.Abstractions.Clock;
using ApartmentBooking.Application.Abstractions.Messaging;
using ApartmentBooking.Application.Exceptions;
using ApartmentBooking.Domain.Abstractions;
using ApartmentBooking.Domain.Apartments;
using ApartmentBooking.Domain.Bookings;
using ApartmentBooking.Domain.Users;

namespace ApartmentBooking.Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler(
    IUserRepository userRepository,
    IApartmentRepository apartmentRepository,
    IBookingRepository bookingRepository,
    IUnitOfWork unitOfWork,
    PricingService pricingService,
    IDateTimeProvider dateTimeProvider)
    : ICommandHandler<ReserveBookingCommand, Guid>
{
    public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user == null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var apartment = await apartmentRepository.GetByIdAsync(request.ApartmentId, cancellationToken);

        if (apartment == null) {
            return Result.Failure<Guid>(ApartmentErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        if (await bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken)) {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }

        try {
            var booking = Booking.Reserve(
                apartment,
                user.Id,
                duration,
                dateTimeProvider.UtcNow,
                pricingService
            );

            bookingRepository.Add(booking);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return booking.Id;
        }
        catch (ConcurrencyException) 
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }
        
    }
}
