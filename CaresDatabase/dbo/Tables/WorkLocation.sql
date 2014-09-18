CREATE TABLE [dbo].[WorkLocation] (
    [WorkLocationID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [WorkLocationCode]        NVARCHAR (100) NOT NULL,
    [WorkLocationName]        NVARCHAR (255) NULL,
    [WorkLocationDescription] NVARCHAR (500) NULL,
    [CompanyID]               BIGINT         NOT NULL,
    [RowVersion]              BIGINT         CONSTRAINT [DF_WorkLocation_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]                BIT            CONSTRAINT [DF__WorkLocat__IsAct__4B973090] DEFAULT ((1)) NOT NULL,
    [IsDeleted]               BIT            CONSTRAINT [DF__WorkLocat__IsDel__4C8B54C9] DEFAULT ((0)) NOT NULL,
    [IsPrivate]               BIT            CONSTRAINT [DF__WorkLocat__IsPri__4D7F7902] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]              BIT            CONSTRAINT [DF__WorkLocat__IsRea__4E739D3B] DEFAULT ((0)) NULL,
    [RecCreatedDt]            DATETIME       NOT NULL,
    [RecCreatedBy]            NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]        DATETIME       NOT NULL,
    [RecLastUpdatedBy]        NVARCHAR (100) NOT NULL,
    [UserDomainKey]           BIGINT         NOT NULL,
    [AddressID]               BIGINT         NULL,
    CONSTRAINT [PK131] PRIMARY KEY NONCLUSTERED ([WorkLocationID] ASC),
    CONSTRAINT [RefAddress] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Address] ([AddressID]),
    CONSTRAINT [RefCompany3011] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Company] ([CompanyID])
);

