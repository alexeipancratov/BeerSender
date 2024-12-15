using BeerSender.Domain.Boxes;
using BeerSender.Domain.Boxes.Events;

namespace BeerSender.Domain.Tests.Boxes;

public abstract class BoxCommandHandlerTests<TCommand> : CommandHandlerTests<TCommand>
{
    protected Guid Box_ID => AggregateId;

    #region Events

    protected BoxCreatedEvent Box_created_with_capacity(int capacity) => new(new BoxCapacity(capacity));

    protected BeerBottleAddedEvent Beer_bottle_added(BeerBottle bottle) => new(bottle);

    #endregion

    #region Test Data

    protected BeerBottle Carte_blanche = new("Wolf", "Carte Blanche", 8.5, BeerBottle.BeerType.Triple);

    #endregion
}