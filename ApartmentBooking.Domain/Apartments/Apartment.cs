﻿

using ApartmentBooking.Domain.Abstractions;
using ApartmentBooking.Domain.Shared;

namespace ApartmentBooking.Domain.Apartments;

public sealed class Apartment : Entity
{
    public Apartment(
        Guid id,
        Name name,
        Description description,
        Address address,
        Money price,
        Money cleaningFee,
        List<Amenity> amenities
    )
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        Amenities = amenities;
    }

    private Apartment()
    {
        //
    }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Money Price { get; private set; }

    public Money CleaningFee { get; private set; }

    public DateTime? LastBookedOnUtc { get; internal set; }

    public List<Amenity> Amenities { get; private set; } = new();
}
