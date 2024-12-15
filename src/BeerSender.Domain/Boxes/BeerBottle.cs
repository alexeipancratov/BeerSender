namespace BeerSender.Domain.Boxes;

public record BeerBottle(string Manufacturer, string Name, double Volume, BeerBottle.BeerType Type)
{
    public enum BeerType
    {
        Ipa,
        Triple
    }
}