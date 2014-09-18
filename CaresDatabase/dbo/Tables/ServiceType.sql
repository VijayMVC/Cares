CREATE TABLE [dbo].[ServiceType] (
    [ServiceTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [ServiceTypeCode]        NVARCHAR (100) NOT NULL,
    [ServiceTypeName]        NVARCHAR (255) NOT NULL,
    [ServiceTypeDescription] NVARCHAR (500) NULL,
    [RowVersion]             BIGINT         CONSTRAINT [DF__ServiceTy__RowVe__3568C3A6] DEFAULT ((0)) NOT NULL,
    [IsActive]               BIT            CONSTRAINT [DF__ServiceTy__IsAct__365CE7DF] DEFAULT ((1)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF__ServiceTy__IsDel__37510C18] DEFAULT ((0)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF__ServiceTy__IsPri__38453051] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF__ServiceTy__IsRea__3939548A] DEFAULT ((0)) NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK168] PRIMARY KEY NONCLUSTERED ([ServiceTypeID] ASC)
);

