using BeerSender.Domain.Boxes.Events;

namespace BeerSender.Domain.Boxes.Commands;

public record AddBeerBottleCommand(Guid BoxId, BeerBottle BeerBottle);

public class AddBeerBottleCommandHandler(IEventStore eventStore) : CommandHandler<AddBeerBottleCommand>(eventStore)
{
    public override void Handle(AddBeerBottleCommand command)
    {
        var boxStream = GetEventStream<Box>(command.BoxId);
        var box = boxStream.GetEntity();

        if (box.IsFull)
        {
            boxStream.Append(new BeerBottleFailedToAddEvent(BeerBottleFailedToAddEvent.FailReason.BoxWasFull));
        }
        else
        {
            boxStream.Append(new BeerBottleAddedEvent(command.BeerBottle));
        }
    }
}