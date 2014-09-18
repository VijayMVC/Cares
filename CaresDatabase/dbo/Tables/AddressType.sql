CREATE TABLE [dbo].[AddressType] (
    [AddressTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [AddressTypeCode]        NVARCHAR (100) NULL,
    [AddressTypeName]        NVARCHAR (255) NULL,
    [AddressTypeDescription] NVARCHAR (500) NULL,
    [IsActive]               BIT            CONSTRAINT [DF__AddressTy__IsAct__08D548FA] DEFAULT ((1)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF__AddressTy__IsDel__09C96D33] DEFAULT ((0)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF__AddressTy__IsPri__0ABD916C] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF__AddressTy__IsRea__0BB1B5A5] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK94] PRIMARY KEY NONCLUSTERED ([AddressTypeID] ASC)
);

