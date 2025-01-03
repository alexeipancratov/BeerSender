namespace BeerSender.QueryApi.Database.Models;

public class OpenBox
{
    public Guid BoxId { get; set; }
    public int Capacity { get; set; }
    public int NumberOfBottles { get; set; }
}