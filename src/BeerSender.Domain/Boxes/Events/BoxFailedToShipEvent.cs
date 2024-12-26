namespace BeerSender.Domain.Boxes.Events;

public record BoxFailedToShipEvent(BoxFailedToShipEvent.FailReason Reason)
{
    public enum FailReason
    {
        BoxWasNotClosed,
        ShippingLabelWasNotAdded
    }
}