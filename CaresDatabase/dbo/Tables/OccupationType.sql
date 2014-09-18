CREATE TABLE [dbo].[OccupationType] (
    [OccupationTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [OccupationTypeCode]        NVARCHAR (100) NOT NULL,
    [OccupationTypeName]        NVARCHAR (255) NULL,
    [OccupationTypeDescription] NVARCHAR (500) NULL,
    [RowVersion]                BIGINT         CONSTRAINT [DF__Occupatio__RowVe__5832119F] DEFAULT ((0)) NOT NULL,
    [IsActive]                  BIT            CONSTRAINT [DF__Occupatio__IsAct__592635D8] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                 BIT            CONSTRAINT [DF__Occupatio__IsDel__5A1A5A11] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                 BIT            CONSTRAINT [DF__Occupatio__IsPri__5B0E7E4A] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                BIT            CONSTRAINT [DF__Occupatio__IsRea__5C02A283] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]              DATETIME       NOT NULL,
    [RecCreatedBy]              NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]          DATETIME       NOT NULL,
    [RecLastUpdatedBy]          NVARCHAR (100) NOT NULL,
    [UserDomainKey]             BIGINT         NOT NULL,
    CONSTRAINT [PK127] PRIMARY KEY CLUSTERED ([OccupationTypeID] ASC)
);

