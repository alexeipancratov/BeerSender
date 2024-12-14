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
    public void Apply(BoxCreated @event)
    {
        Capacity = @event.BoxCapacity;
    }

    public void ShippingLabelAdded(ShippingLabelAdded @event)
    {
        ShippingLabel = @event.ShippingLabel;
    }

    public ShippingLabel? ShippingLabel { get; private set; }

    public BoxCapacity? Capacity { get; private set; }
}

// Commands
public record CreateBox(Guid BoxId, int DesiredNumberOfSpots);

// Events
public record BoxCreated(BoxCapacity BoxCapacity);

public record ShippingLabelAdded(ShippingLabel ShippingLabel);

public record ShippingLabelFailedToAdd(ShippingLabelFailedToAdd.FailReason Reason)
{
    public enum FailReason
    {
        TrackingCodeInvalid
    }
}

public enum Carrier
{
    Ups,
    FedEx,
    CanadaPost
}

public record ShippingLabel(Carrier Carrier, string TrackingCode)
{
    public bool IsValid()
    {
        return Carrier switch
        {
            Carrier.Ups => TrackingCode.StartsWith("ABC"),
            Carrier.FedEx => TrackingCode.StartsWith("DEF"),
            Carrier.CanadaPost => TrackingCode.StartsWith("GHI"),
            _ => throw new ArgumentOutOfRangeException(nameof(Carrier), Carrier, null)
        };
    }
}

public record BoxCapacity(int NumberOfSpots)
{
    public static BoxCapacity Create(int desiredNumberOfSpots)
    {
        return desiredNumberOfSpots switch
        {
            <= 6 => new BoxCapacity(6),
            <= 12 => new BoxCapacity(12),
            _ => new BoxCapacity(24)
        };
    }
}