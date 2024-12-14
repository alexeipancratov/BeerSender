namespace BeerSender.Domain;

public interface IEventStore
{
    IReadOnlyList<StoredEvent> GetEvents(Guid aggregateId);

    void AppendEvent(StoredEvent @event);

    void SaveChanges();
}