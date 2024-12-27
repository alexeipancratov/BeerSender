using BeerSender.Domain;

namespace BeerSender.EventStore;

public class EventStore(EventStoreConnectionFactory connectionFactory)
{
    private readonly EventStoreConnectionFactory _connectionFactory = connectionFactory;

    public IReadOnlyList<StoredEvent> GetEvents(Guid aggregateId)
    {
        throw new NotImplementedException();
    }
}