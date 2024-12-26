using BeerSender.Domain.Boxes.Commands;

namespace BeerSender.Domain.Tests.Boxes.Commands;

public class CloseBoxCommandHandlerTests : BoxCommandHandlerTests<CloseBoxCommand>
{
    protected override CommandHandler<CloseBoxCommand> Handler => new CloseBoxCommandHandler(EventStore);

    [Fact]
    public void BoxIsNotEmpty_ShouldCloseBox()
    {
        Given(
            Box_created_with_capacity(6),
            Beer_bottle_added(Carte_blanche));
        When(
            Close_box());
        Then(
            Box_closed());
    }

    [Fact]
    public void BoxIsEmpty_ShouldFail()
    {
        Given(
            Box_created_with_capacity(6));
        When(
            Close_box());
        Then(
            Box_was_empty());
    }

    private CloseBoxCommand Close_box() => new(Box_ID);
}