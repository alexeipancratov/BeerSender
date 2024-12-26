using BeerSender.Domain.Boxes.Events;

namespace BeerSender.Domain.Boxes.Commands;

public record CloseBoxCommand(Guid BoxId);

public class CloseBoxCommandHandler(IEventStore eventStore) : CommandHandler<CloseBoxCommand>(eventStore)
{
    public override void Handle(CloseBoxCommand command)
    {
        var boxStream = GetEventStream<Box>(command.BoxId);
        var box = boxStream.GetEntity();

        if (box.IsEmpty)
        {
            boxStream.Append(new BoxFailedToCloseEvent(BoxFailedToCloseEvent.FailReason.BoxWasEmpty));
        }
        else
        {
            boxStream.Append(new BoxClosedEvent());
        }
    }
}