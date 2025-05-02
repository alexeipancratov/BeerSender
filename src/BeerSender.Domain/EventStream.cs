namespace BeerSender.Domain;

public class EventStream<TEntity>(IEventStore eventStore, Guid aggregateId) 
    where TEntity : AggregateRoot, new()
{
    private readonly IEventStore _eventStore = eventStore;
    private readonly Guid _aggregateId = aggregateId;
    
    private int _lastSequenceNumber;

    public TEntity GetEntity()
    {
        var events = _eventStore.GetEvents(_aggregateId);

        TEntity entity = new();
        foreach (var @event in events)
        {
            // NOTE: By casting it to dynamic we're forcing it to use the most specific method if one is available
            // instead of calling the base method which does nothing in our case.
            entity.Apply((dynamic)@event.EventData);
            _lastSequenceNumber = @event.SequenceNumber;
        }

        return entity;
    }
    
    public TEntity GetEntity(int version)
    {
        var events = _eventStore.GetEvents(_aggregateId);

        TEntity entity = new();
        foreach (var @event in events)
        {
            if (_lastSequenceNumber == version)
            {
                return entity;
            }
            
            // NOTE: By casting it to dynamic we're forcing it to use the most specific method if one is available
            // instead of calling the base method which does nothing in our case.
            entity.Apply((dynamic)@event.EventData);
            _lastSequenceNumber = @event.SequenceNumber;
        }

        return entity;
    }

    public void Append(object @event)
    {
        _lastSequenceNumber++;

        StoredEvent storedEvent = new(_aggregateId, _lastSequenceNumber, DateTime.UtcNow, @event);

        _eventStore.AppendEvent(storedEvent);
        _eventStore.SaveChanges();
    }
}