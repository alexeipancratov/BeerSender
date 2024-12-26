using BeerSender.Domain.Boxes.Commands;

namespace BeerSender.Domain.Tests.Boxes.Commands;

public class CreateBoxCommandHandlerTests : BoxCommandHandlerTests<CreateBoxCommand>
{
    protected override CommandHandler<CreateBoxCommand> Handler => new CreateBoxCommandHandler(EventStore);
    
    [InlineData(-1, 6)]
    [InlineData(0, 6)]
    [InlineData(6, 6)]
    [InlineData(7, 12)]
    [InlineData(12, 12)]
    [InlineData(13, 24)]
    [InlineData(100, 24)]
    [Theory]
    public void ShippingLabelIsValid_ShippingLabelAdded(int desiredNumberOfSpots, int actualNumberOfSpots)
    {
        Given();
        When(
            Create_box(desiredNumberOfSpots));
        Then(
            Box_created_with_capacity(actualNumberOfSpots));
    }

    private CreateBoxCommand Create_box(int numberOfSpots) => new(Box_ID, numberOfSpots);
}