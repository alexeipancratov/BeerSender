namespace BeerSender.Domain;

public record StoredEvent(Guid AggregateId, int SequenceNumber, DateTimeOffset Timestamp, object EventData);