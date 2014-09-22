CREATE TABLE [dbo].[OperationsWorkplace] (
    [OperationsWorkplaceID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [LocationCode]          NVARCHAR (100) NULL,
    [WorkplaceID]           BIGINT         NOT NULL,
    [OperationID]           BIGINT         NOT NULL,
    [FleetPoolID]           BIGINT         NULL,
    [CostCenter]            NVARCHAR (100) NOT NULL,
    [RowVersion]            BIGINT         CONSTRAINT [DF_OperationsWorkplace_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]              BIT            CONSTRAINT [DF__Operation__IsAct__34B3CB38] DEFAULT ((1)) NOT NULL,
    [IsDeleted]             BIT            CONSTRAINT [DF__Operation__IsDel__35A7EF71] DEFAULT ((0)) NOT NULL,
    [IsPrivate]             BIT            CONSTRAINT [DF__Operation__IsPri__369C13AA] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]            BIT            CONSTRAINT [DF__Operation__IsRea__379037E3] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]          DATETIME       NOT NULL,
    [RecCreatedBy]          NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]      NVARCHAR (100) NOT NULL,
    [UserDomainKey]         BIGINT         NOT NULL,
    CONSTRAINT [PK90] PRIMARY KEY NONCLUSTERED ([OperationsWorkplaceID] ASC),
    CONSTRAINT [RefFleetPool1913] FOREIGN KEY ([FleetPoolID]) REFERENCES [dbo].[FleetPool] ([FleetPoolID]),
    CONSTRAINT [RefOperation2561] FOREIGN KEY ([OperationID]) REFERENCES [dbo].[Operation] ([OperationID]),
    CONSTRAINT [RefWorkplace1811] FOREIGN KEY ([WorkplaceID]) REFERENCES [dbo].[Workplace] ([WorkplaceID]) ON DELETE CASCADE
);



