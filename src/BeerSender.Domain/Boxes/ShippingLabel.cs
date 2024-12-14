namespace BeerSender.Domain.Boxes;

public record ShippingLabel(Carrier Carrier, string TrackingCode)
{
    public bool IsValid()
    {
        return Carrier switch
        {
            Carrier.Ups => TrackingCode.StartsWith("ABC"),
            Carrier.FedEx => TrackingCode.StartsWith("DEF"),
            Carrier.CanadaPost => TrackingCode.StartsWith("GHI"),
            _ => throw new ArgumentOutOfRangeException(nameof(Carrier), Carrier, null)
        };
    }
}