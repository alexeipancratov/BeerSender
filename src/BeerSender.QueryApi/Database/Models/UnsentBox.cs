namespace BeerSender.QueryApi.Database.Models;

public class UnsentBox
{
    public Guid BoxId { get; set; }
    public string? Status { get; set; }
}