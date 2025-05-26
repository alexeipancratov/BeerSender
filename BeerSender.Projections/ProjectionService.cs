using BeerSender.Projections.Database;
using BeerSender.Projections.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BeerSender.Projections;

public class ProjectionService<TProjection>(IServiceProvider serviceProvider, EventStoreRepository eventStoreRepository) : BackgroundService
    where TProjection : class, IProjection
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly EventStoreRepository _eventStoreRepository = eventStoreRepository;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var checkpoint = GetCheckpoint();

        while (!stoppingToken.IsCancellationRequested)
        {
            // We create a new scope to ensure that we don't keep DB connections open for too long.
            using var scope = _serviceProvider.CreateScope();
            
            var connection = scope.ServiceProvider.GetRequiredService<ReadStoreConnection>();
            var transaction = connection.GetTransaction();
            
            // fetch a batch of events
            var projection = scope.ServiceProvider.GetRequiredService<TProjection>();

            var events =
                _eventStoreRepository.GetEvents(projection.RelevantEventTypes, checkpoint, projection.BatchSize);

            if (!events.Any())
            {
                await Task.Delay(projection.WaitTime, stoppingToken);
            }
            else
            {
                projection.Project(events);
                checkpoint = events.Last().RowVersion;
                
                var checkpointRepository = scope.ServiceProvider.GetRequiredService<CheckpointRepository>();
                checkpointRepository.SetCheckpoint(
                    typeof(TProjection).Name, checkpoint);
            }
            
            transaction.Commit();
        }
    }

    private byte[] GetCheckpoint()
    {
        using var scope = _serviceProvider.CreateScope();
        var checkpointService = scope.ServiceProvider.GetRequiredService<CheckpointRepository>();

        var checkpoint = checkpointService.GetCheckpoint(typeof(TProjection).Name);
        
        return checkpoint;
    }
}