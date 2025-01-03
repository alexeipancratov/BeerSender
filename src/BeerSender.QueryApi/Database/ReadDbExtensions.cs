namespace BeerSender.QueryApi.Database;

public static class ReadDbExtensions
{
    public static void RegisterReadDatabase(this IServiceCollection services)
    {
        services.AddSingleton<ReadStoreConnectionFactory>();

        services.AddTransient<BoxQueryRepository>();
    }
}