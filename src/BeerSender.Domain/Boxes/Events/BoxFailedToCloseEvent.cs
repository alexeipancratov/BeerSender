namespace BeerSender.Domain.Boxes.Events;

public record BoxFailedToCloseEvent(BoxFailedToCloseEvent.FailReason Reason)
{
    public enum FailReason
    {
        BoxWasEmpty
    }
};