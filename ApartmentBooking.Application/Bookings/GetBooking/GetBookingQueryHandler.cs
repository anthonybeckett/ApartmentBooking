using ApartmentBooking.Application.Abstractions.Data;
using ApartmentBooking.Application.Abstractions.Messaging;
using ApartmentBooking.Domain.Abstractions;
using Dapper;

namespace ApartmentBooking.Application.Bookings.GetBooking;

internal sealed class GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    : IQueryHandler<GetBookingQuery, BookingResponse>
{
    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        using var connection = sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id as Id,
                apartment_id as ApartmentId,
                user_id as UserId,
                status as Status,
                price_for_period_amount as PriceAmount,
                price_for_period_currency as PriceCurrency,
                cleaning_fee_amount as CleaningFeeAmount,
                cleaning_fee_currency as CleaningFeeCurrency,
                amenities_up_charge_amount as AnmenitiesUpChargeAmount,
                amenities_up_charge_currency as AnmenitiesUpChargeCurrency,
                total_price_amount as TotalPriceAmount,
                total_price_currency as TotalPriceCurrency,
                duration_start as DurationStart,
                duration_end as DurationEnd,
                created_on_utc as CreatedOnUtc
            FROM bookings
            WHERE id = @BookingId
            """;

        var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
            sql,
            new { 
                request.BookingId
            }
        );

        return booking;
    }
}
