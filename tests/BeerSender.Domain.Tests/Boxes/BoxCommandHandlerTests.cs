using BeerSender.Domain.Boxes;
using BeerSender.Domain.Boxes.Events;

namespace BeerSender.Domain.Tests.Boxes;

public abstract class BoxCommandHandlerTests<TCommand> : CommandHandlerTests<TCommand>
{
    protected Guid Box_ID => AggregateId;

    #region Events

    protected BoxCreatedEvent Box_created_with_capacity(int capacity) => new(new BoxCapacity(capacity));

    protected BeerBottleAddedEvent Beer_bottle_added(BeerBottle bottle) => new(bottle);

    protected BeerBottleFailedToAddEvent Beer_bottle_failed_to_add_box_full(BeerBottle bottle) =>
        new(BeerBottleFailedToAddEvent.FailReason.BoxWasFull);

    protected ShippingLabelAddedEvent Shipping_label_added(ShippingLabel shippingLabel) => new(shippingLabel);

    #endregion

    #region Test Data

    protected BeerBottle Carte_blanche = new("Wolf", "Carte Blanche", 8.5, BeerBottle.BeerType.Triple);

    protected ShippingLabel Valid_shipping_label = new(Carrier.Ups, "ABC");

    #endregion
}