using BeerSender.Domain.Boxes.Events;

namespace BeerSender.Domain.Boxes.Commands;

public record ShipBoxCommand(Guid BoxId);

public class ShipBoxCommandHandler(IEventStore eventStore) : CommandHandler<ShipBoxCommand>(eventStore)
{
    public override void Handle(ShipBoxCommand command)
    {
        var boxStream = GetEventStream<Box>(command.BoxId);
        var box = boxStream.GetEntity();

        if (box.ShippingLabel == null)
        {
            boxStream.Append(new BoxFailedToShipEvent(BoxFailedToShipEvent.FailReason.ShippingLabelWasNotAdded));
        }
        if (!box.IsClosed)
        {
            boxStream.Append(new BoxFailedToShipEvent(BoxFailedToShipEvent.FailReason.BoxWasNotClosed));
        }
        else
        {
            boxStream.Append(new BoxShippedEvent());
        }
    }
}