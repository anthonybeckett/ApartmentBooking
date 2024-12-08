namespace ApartmentBooking.Domain.Apartments;

public record Address(
    string AddressLine1,
    string AddressLine2,
    string City,
    string Postcode,
    string Country
);
