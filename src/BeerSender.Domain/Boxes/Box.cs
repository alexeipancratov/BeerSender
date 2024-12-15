﻿using BeerSender.Domain.Boxes.Events;

namespace BeerSender.Domain.Boxes;

/// <summary>
/// Root entity of our Aggregate (the whole folder).
/// </summary>
public class Box : AggregateRoot
{
    /// <summary>
    /// Applies an event to the entity.
    /// </summary>
    /// <param name="event">An event to apply.</param>
    /// <remarks>We could also create this as an abstract method in the base class.
    /// Currently, however, we'll be relying on casting this object to dynamic to call the correct method
    /// which is just less work.</remarks>
    public void Apply(BoxCreatedEvent @event)
    {
        Capacity = @event.BoxCapacity;
        BoxContent = new BoxContent(Capacity, []);
    }

    public void ShippingLabelAdded(ShippingLabelAddedEvent @event)
    {
        ShippingLabel = @event.ShippingLabel;
    }

    public void BottleAdded(BeerBottleAddedEvent @event)
    {
        BoxContent = new BoxContent(Capacity!, [..BoxContent!.BeerBottles, @event.BeerBottle]);
    }

    public ShippingLabel? ShippingLabel { get; private set; }

    public BoxCapacity? Capacity { get; private set; }
    
    public BoxContent? BoxContent { get; private set; }
}
