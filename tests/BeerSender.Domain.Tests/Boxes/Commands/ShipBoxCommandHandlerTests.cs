using BeerSender.Domain.Boxes.Commands;

namespace BeerSender.Domain.Tests.Boxes.Commands;

public class ShipBoxCommandHandlerTests : BoxCommandHandlerTests<ShipBoxCommand>
{
    protected override CommandHandler<ShipBoxCommand> Handler => new ShipBoxCommandHandler(EventStore);

    [Fact]
    public void ShippingLabelAttachedAndBoxIsClosed_Succeeds()
    {
        Given(
            Box_created_with_capacity(6),
            Beer_bottle_added(Carte_blanche),
            Box_closed(),
            Shipping_label_added(Valid_shipping_label));
        When(
            Ship_box());
        Then(
            Box_shipped());
    }
    
    [Fact]
    public void ShippingLabelAttachedAndBoxIsNotClosed_Fails()
    {
        Given(
            Box_created_with_capacity(6),
            Beer_bottle_added(Carte_blanche),
            Shipping_label_added(Valid_shipping_label));
        When(
            Ship_box());
        Then(
            Box_failed_to_ship_box_not_closed());
    }
    
    [Fact]
    public void BoxIsClosedButShippingLabelNotAttached_Fails()
    {
        Given(
            Box_created_with_capacity(6),
            Beer_bottle_added(Carte_blanche),
            Box_closed());
        When(
            Ship_box());
        Then(
            Box_failed_to_ship_shipping_label_not_added());
    }

    private ShipBoxCommand Ship_box()
    {
        return new ShipBoxCommand(Box_ID);
    }
}