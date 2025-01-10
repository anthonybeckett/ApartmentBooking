using ApartmentBooking.Application.Abstractions.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApartmentBooking.Infrastructure.Data;

internal sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    public SqlConnectionFactory() : this("")
    {
    }

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(connectionString);

        connection.Open();

        return connection;
    }
}
