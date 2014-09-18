CREATE TABLE [dbo].[MaintenanceType] (
    [MaintenanceTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [MaintenanceTypeGroupID]     SMALLINT       NOT NULL,
    [MaintenanceTypeCode]        NVARCHAR (100) NOT NULL,
    [MaintenanceTypeName]        NVARCHAR (255) NULL,
    [MaintenanceTypeDescription] NVARCHAR (500) NULL,
    [IsActive]                   BIT            CONSTRAINT [DF__Maintenan__IsAct__297722B6] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                  BIT            CONSTRAINT [DF__Maintenan__IsDel__2A6B46EF] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                 BIT            CONSTRAINT [DF__Maintenan__IsRea__2B5F6B28] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                  BIT            CONSTRAINT [DF__Maintenan__IsPri__2C538F61] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]               DATETIME       NOT NULL,
    [RecCreatedBy]               NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]           DATETIME       NOT NULL,
    [RowVersion]                 BIGINT         NOT NULL,
    [UserDomainKey]              BIGINT         NOT NULL,
    CONSTRAINT [PK12_1_1_1] PRIMARY KEY NONCLUSTERED ([MaintenanceTypeID] ASC),
    CONSTRAINT [RefMaintenanceTypeGroup313] FOREIGN KEY ([MaintenanceTypeGroupID]) REFERENCES [dbo].[MaintenanceTypeGroup] ([MaintenanceTypeGroupID])
);

