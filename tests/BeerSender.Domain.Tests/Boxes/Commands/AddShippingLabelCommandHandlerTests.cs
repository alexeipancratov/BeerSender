using BeerSender.Domain.Boxes;
using BeerSender.Domain.Boxes.Commands;

namespace BeerSender.Domain.Tests.Boxes.Commands;

public class AddShippingLabelCommandHandlerTests : BoxCommandHandlerTests<AddShippingLabelCommand>
{
    protected override CommandHandler<AddShippingLabelCommand> Handler =>
        new AddShippingLabelCommandHandler(EventStore);

    [Fact]
    public void ShippingLabelIsValid_ShippingLabelAdded()
    {
        Given(
            Box_created_with_capacity(1));
        When(
            Add_shipping_label(Valid_shipping_label));
        Then(
            Shipping_label_added(Valid_shipping_label));
    }

    private AddShippingLabelCommand Add_shipping_label(ShippingLabel shippingLabel) => new(Box_ID, shippingLabel);
}