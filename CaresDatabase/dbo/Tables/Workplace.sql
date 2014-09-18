CREATE TABLE [dbo].[Workplace] (
    [WorkplaceID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [WorkplaceCode]        NVARCHAR (100) NOT NULL,
    [WorkplaceName]        NVARCHAR (255) NULL,
    [WorkplaceDescription] NVARCHAR (500) NULL,
    [ParentWorkplaceID]    BIGINT         NULL,
    [WorkplaceTypeID]      SMALLINT       NOT NULL,
    [WorkLocationID]       BIGINT         NOT NULL,
    [RowVersion]           BIGINT         CONSTRAINT [DF_Workplace_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]             BIT            CONSTRAINT [DF__Workplace__IsAct__515009E6] DEFAULT ((1)) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF__Workplace__IsDel__52442E1F] DEFAULT ((0)) NOT NULL,
    [IsPrivate]            BIT            CONSTRAINT [DF__Workplace__IsPri__53385258] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]           BIT            CONSTRAINT [DF__Workplace__IsRea__542C7691] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]         DATETIME       NOT NULL,
    [RecCreatedBy]         NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]     DATETIME       NOT NULL,
    [RecLastUpdatedBy]     NVARCHAR (100) NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK88] PRIMARY KEY NONCLUSTERED ([WorkplaceID] ASC),
    CONSTRAINT [RefWorkLocation3031] FOREIGN KEY ([WorkLocationID]) REFERENCES [dbo].[WorkLocation] ([WorkLocationID]),
    CONSTRAINT [RefWorkplace2301] FOREIGN KEY ([ParentWorkplaceID]) REFERENCES [dbo].[Workplace] ([WorkplaceID]),
    CONSTRAINT [RefWorkplaceType1751] FOREIGN KEY ([WorkplaceTypeID]) REFERENCES [dbo].[WorkplaceType] ([WorkplaceTypeID])
);

