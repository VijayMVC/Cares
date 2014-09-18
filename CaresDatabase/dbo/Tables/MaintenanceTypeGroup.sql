CREATE TABLE [dbo].[MaintenanceTypeGroup] (
    [MaintenanceTypeGroupID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [MaintenanceTypeGroupCode]        NVARCHAR (100) NOT NULL,
    [MaintenanceTypeGroupName]        NVARCHAR (255) NULL,
    [MaintenanceTypeGroupDescription] NVARCHAR (500) NULL,
    [IsActive]                        BIT            CONSTRAINT [DF__Maintenan__IsAct__2D47B39A] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                       BIT            CONSTRAINT [DF__Maintenan__IsDel__2E3BD7D3] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                      BIT            CONSTRAINT [DF__Maintenan__IsRea__2F2FFC0C] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                       BIT            CONSTRAINT [DF__Maintenan__IsPri__30242045] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                    DATETIME       NOT NULL,
    [RecCreatedBy]                    NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]                NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]                DATETIME       NOT NULL,
    [RowVersion]                      BIGINT         NOT NULL,
    [UserDomainKey]                   BIGINT         NOT NULL,
    CONSTRAINT [PK12_1_1] PRIMARY KEY NONCLUSTERED ([MaintenanceTypeGroupID] ASC)
);

