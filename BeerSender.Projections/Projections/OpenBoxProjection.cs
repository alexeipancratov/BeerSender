using BeerSender.Domain.Boxes.Events;
using BeerSender.Projections.Database.Repositories;

namespace BeerSender.Projections.Projections;

public class OpenBoxProjection(OpenBoxRepository openBoxRepository) : IProjection
{
    private readonly OpenBoxRepository _openBoxRepository = openBoxRepository;

    public List<Type> RelevantEventTypes =>
        [typeof(BoxCreatedEvent), typeof(BeerBottleAddedEvent), typeof(BoxClosedEvent)];

    public int BatchSize => 50;
    
    /// <summary>
    /// Defines how long can we tolerate the stale data.
    /// </summary>
    public int WaitTime => 5000;
    
    public void Project(IReadOnlyCollection<StoredEventWithVersion> events)
    {
        foreach (var storedEvent in events)
        {
            var boxId = storedEvent.AggregateId;

            switch (storedEvent.EventData)
            {
                case BoxCreatedEvent boxCreatedEvent:
                    var capacity = boxCreatedEvent.BoxCapacity.NumberOfSpots;
                    _openBoxRepository.CreateOpenBox(boxId, capacity);
                    break;
                case BeerBottleAddedEvent:
                    _openBoxRepository.AddBottleToBox(boxId);
                    break;
                case BoxClosedEvent:
                    _openBoxRepository.RemoveOpenBox(boxId);
                    break;
            }
        }
    }
}