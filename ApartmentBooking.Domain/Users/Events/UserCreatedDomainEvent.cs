using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid id) : IDomainEvent;
