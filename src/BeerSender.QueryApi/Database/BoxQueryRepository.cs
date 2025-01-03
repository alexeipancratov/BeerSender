using BeerSender.QueryApi.Database.Models;
using Dapper;

namespace BeerSender.QueryApi.Database;

public class BoxQueryRepository(ReadStoreConnectionFactory dbFactory)
{
    public IReadOnlyList<OpenBox> GetAllOpen()
    {
        var query =
            """
            SELECT BoxId ,Capacity, NumberOfBottles
            FROM dbo.OpenBoxes
            """;

        using var connection = dbFactory.Create();

        return connection.Query<OpenBox>(query).ToArray();
    }
    
    public IReadOnlyList<UnsentBox> GetAllUnsent()
    {
        var query =
            """
            SELECT BoxId, Status
            FROM dbo.UnsentBoxes
            """;

        using var connection = dbFactory.Create();

        return connection.Query<UnsentBox>(query).ToArray();
    }
}