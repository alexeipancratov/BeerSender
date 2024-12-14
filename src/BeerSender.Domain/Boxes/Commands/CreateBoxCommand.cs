using BeerSender.Domain.Boxes.Events;

namespace BeerSender.Domain.Boxes.Commands;

public record CreateBoxCommand(Guid BoxId, int DesiredNumberOfSpots);

public class CreateBoxCommandHandler(IEventStore eventStore) : CommandHandler<CreateBoxCommand>(eventStore)
{
    public override void Handle(CreateBoxCommand command)
    {
        var boxCapacity = BoxCapacity.Create(command.DesiredNumberOfSpots);
        
        var eventStream = GetEventStream<Box>(command.BoxId);
        eventStream.Append(new BoxCreatedEvent(boxCapacity));
    }
}