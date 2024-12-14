namespace BeerSender.Domain.Boxes.Events;

public record ShippingLabelFailedToAddEvent(ShippingLabelFailedToAddEvent.FailReason Reason)
{
    public enum FailReason
    {
        TrackingCodeInvalid
    }
}