using ApartmentBooking.Domain.Shared;

namespace ApartmentBooking.Domain.Bookings;

public record PricingDetails(Money PriceForPeriod, Money CleaningFee, Money AmenitiesUpCharge, Money TotalPrice);
