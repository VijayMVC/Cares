CREATE TABLE [dbo].[FleetPool] (
    [FleetPoolID]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [ApproximateVehiclesAsgnd] INT            NOT NULL,
    [FleetPoolCode]            NVARCHAR (100) NOT NULL,
    [FleetPoolName]            NVARCHAR (255) NULL,
    [FleetPoolDescription]     NVARCHAR (500) NULL,
    [IsActive]                 BIT            CONSTRAINT [DF__FleetPool__IsAct__20CCCE1C] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                BIT            CONSTRAINT [DF__FleetPool__IsPri__21C0F255] DEFAULT ((0)) NULL,
    [IsReadOnly]               BIT            CONSTRAINT [DF__FleetPool__IsRea__22B5168E] DEFAULT ((0)) NOT NULL,
    [IsDeleted]                BIT            CONSTRAINT [DF__FleetPool__IsDel__23A93AC7] DEFAULT ((0)) NOT NULL,
    [OperationID]              BIGINT         NOT NULL,
    [RegionID]                 SMALLINT       NOT NULL,
    [RecCreatedDt]             DATETIME       NOT NULL,
    [RecCreatedBy]             NVARCHAR (100) CONSTRAINT [DF__FleetPool__RecCr__249D5F00] DEFAULT ((0)) NOT NULL,
    [RecLastUpdatedDt]         DATETIME       NULL,
    [RecLastUpdatedBy]         NVARCHAR (100) NOT NULL,
    [RowVersion]               BIGINT         CONSTRAINT [DF_FleetPool_RowVersion] DEFAULT ((0)) NOT NULL,
    [UserDomainKey]            BIGINT         NOT NULL,
    CONSTRAINT [PK7] PRIMARY KEY NONCLUSTERED ([FleetPoolID] ASC),
    CONSTRAINT [RefOperation207] FOREIGN KEY ([OperationID]) REFERENCES [dbo].[Operation] ([OperationID]),
    CONSTRAINT [RefRegion278] FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Region] ([RegionID])
);

