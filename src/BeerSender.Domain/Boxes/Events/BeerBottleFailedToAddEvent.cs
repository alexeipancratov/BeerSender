namespace BeerSender.Domain.Boxes.Events;

public record BeerBottleFailedToAddEvent(BeerBottleFailedToAddEvent.FailReason Reason)
{
    public enum FailReason
    {
        BoxWasFull
    }
}