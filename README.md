# BeerSender - Event Sourcing Demo

This projects serves as a demo of the Event Sourcing pattern.

## Database
SQL script to create the Events DB table:

```
CREATE TABLE [dbo].[Events](
    [AggregateId] [uniqueidentifier] NOT NULL,
    [SequenceNumber] [int] NOT NULL,
    [Timestamp] [datetime2](7) NOT NULL,
    [EventTypeName] [varchar](256) NOT NULL,
    [EventBody] [nvarchar](max) NOT NULL,
    [RowVersion] [timestamp] NOT NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED
    (
        [AggregateId] ASC,
        [SequenceNumber] ASC
    )
)```