﻿using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
