namespace BeerSender.Domain.Tests;

public class TestStore : IEventStore
{
    /// <summary>
    /// Stores events which happened in the past.
    /// </summary>
    public List<StoredEvent> PreviousEvents = [];

    /// <summary>
    /// To be used to verify the new raised events.
    /// </summary>
    public List<StoredEvent> NewEvents = [];
    
    /// <summary>
    /// Retrieves events from the <see cref="PreviousEvents"/> collection.
    /// </summary>
    /// <param name="aggregateId"></param>
    /// <returns></returns>
    public IReadOnlyList<StoredEvent> GetEvents(Guid aggregateId)
    {
        return PreviousEvents
            .Where(e => e.AggregateId == aggregateId)
            .ToArray();
    }

    /// <summary>
    /// Appends an event to the <see cref="NewEvents"/> collection.
    /// </summary>
    /// <param name="event"></param>
    public void AppendEvent(StoredEvent @event)
    {
        NewEvents.Add(@event);
    }

    /// <summary>
    /// Not used is command handler tests.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void SaveChanges()
    {
    }
}