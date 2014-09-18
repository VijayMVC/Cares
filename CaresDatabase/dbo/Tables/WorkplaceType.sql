CREATE TABLE [dbo].[WorkplaceType] (
    [WorkplaceTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [WorkplaceTypeCode]        NVARCHAR (100) NULL,
    [WorkplaceTypeName]        NVARCHAR (255) NULL,
    [WorkplaceTypeDescription] NVARCHAR (500) NULL,
    [WorkplaceTypeCat]         SMALLINT       NULL,
    [WorkplaceTypeNature]      NVARCHAR (100) NULL,
    [RowVersion]               BIGINT         CONSTRAINT [DF_WorkplaceType_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]                 BIT            CONSTRAINT [DF__Workplace__IsAct__5708E33C] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                BIT            CONSTRAINT [DF__Workplace__IsDel__57FD0775] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                BIT            CONSTRAINT [DF__Workplace__IsPri__58F12BAE] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]               BIT            CONSTRAINT [DF__Workplace__IsRea__59E54FE7] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]             DATETIME       NOT NULL,
    [RecCreatedBy]             NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]         DATETIME       NOT NULL,
    [RecLastUpdatedBy]         NVARCHAR (100) NOT NULL,
    [UserDomainKey]            BIGINT         NOT NULL,
    CONSTRAINT [PK22] PRIMARY KEY NONCLUSTERED ([WorkplaceTypeID] ASC)
);

