# BeerSender - Event Sourcing Demo

This projects serves as a demo of the Event Sourcing pattern.

## Web API
This is a command API to execute various business operations.

### Events Database
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
)
```

## Projections background service
A background service which projects events from the main Events database to the Read Store for an easier
and quicker consumption.

## Query API
Reads data from the Read Store. Events are being placed here by the Projections background service.

### Read Store Database
SQL script to create the Read DB tables:

```
CREATE TABLE [dbo].[OpenBoxes](
	[BoxId] [uniqueidentifier] NOT NULL,
	[Capacity] [int] NOT NULL,
	[NumberOfBottles] [int] NOT NULL DEFAULT (0),
    CONSTRAINT [PK_OpenBoxes] PRIMARY KEY CLUSTERED
    (
        [BoxId] ASC
    )
) 

CREATE TABLE [dbo].[UnsentBoxes](
	[BoxId] [uniqueidentifier] NOT NULL,
	[Status] [varchar](64) NOT NULL,
    CONSTRAINT [PK_UnsentBoxes] PRIMARY KEY CLUSTERED
    (
        [BoxId] ASC
    )
) 

CREATE TABLE [dbo].[ProjectionCheckpoints](
	[ProjectionName] [varchar](256) NOT NULL,
	[EventVersion] [binary](8) NOT NULL DEFAULT 0x0000000000000000,
    CONSTRAINT [PK_ProjectionCheckpoints] PRIMARY KEY CLUSTERED 
    (
        [ProjectionName] ASC
    )
)
```

## License