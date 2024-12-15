using BeerSender.Domain.Boxes;
using BeerSender.Domain.Boxes.Commands;
using BeerSender.Domain.Boxes.Events;

namespace BeerSender.Domain.Tests.Boxes.Commands;

public class AddBeerBottleCommandHandlerTests : CommandHandlerTest<AddBeerBottleCommand>
{
    protected override CommandHandler<AddBeerBottleCommand> Handler =>
        new AddBeerBottleCommandHandler(eventStore);

    [Fact]
    public void BoxIsEmpty_BottleShouldBeAdded()
    {
        var newBottle = new BeerBottle("Wolf", "Carte Blanche", 8.5, BeerBottle.BeerType.Triple);
        
        Given(new BoxCreatedEvent(new BoxCapacity(6)));
        When(new AddBeerBottleCommand(_aggregateId, newBottle));
        Then(new BeerBottleAddedEvent(newBottle));
    }
}