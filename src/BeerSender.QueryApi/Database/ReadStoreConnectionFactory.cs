using System.Data;
using Microsoft.Data.SqlClient;

namespace BeerSender.QueryApi.Database;

public class ReadStoreConnectionFactory(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;
    
    public IDbConnection Create() 
        => new SqlConnection(_configuration.GetConnectionString("ReadStore"));
}