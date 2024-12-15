namespace BeerSender.Domain.Boxes;

public record BoxContent(BoxCapacity BoxCapacity, IReadOnlyList<BeerBottle> BeerBottles)
{
    public bool IsFull() => BeerBottles.Count == BoxCapacity.NumberOfSpots;
}