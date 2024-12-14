namespace BeerSender.Domain.Boxes.Commands;

public record AddShippingLabelCommand(Guid BoxId, ShippingLabel ShippingLabel);

public class AddShippingLabelCommandHandler(IEventStore eventStore) : CommandHandler<AddShippingLabelCommand>(eventStore)
{
    public override void Handle(AddShippingLabelCommand command)
    {
        var boxStream = GetEventStream<Box>(command.BoxId);
        var box = boxStream.GetEntity();

        if (command.ShippingLabel.IsValid())
        {
            boxStream.Append(new ShippingLabelAdded(command.ShippingLabel));
        }
        else
        {
            boxStream.Append(new ShippingLabelFailedToAdd(ShippingLabelFailedToAdd.FailReason.TrackingCodeInvalid));
        }
    }
}