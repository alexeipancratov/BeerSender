using BeerSender.Domain.Boxes;
using BeerSender.Domain.Boxes.Commands;

namespace BeerSender.Domain.Tests.Boxes.Commands;

public class AddBeerBottleCommandHandlerTests : BoxCommandHandlerTests<AddBeerBottleCommand>
{
    protected override CommandHandler<AddBeerBottleCommand> Handler =>
        new AddBeerBottleCommandHandler(eventStore);

    [Fact]
    public void BoxIsEmpty_BottleShouldBeAdded()
    {
        Given(
            Box_created_with_capacity(6));
        When(
            Add_beer_bottle(Carte_blanche));
        Then(
            Beer_bottle_added(Carte_blanche));
    }
    
    private AddBeerBottleCommand Add_beer_bottle(BeerBottle bottle)
    {
        return new AddBeerBottleCommand(Box_ID, bottle);
    }
}