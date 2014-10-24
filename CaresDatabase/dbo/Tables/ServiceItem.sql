CREATE TABLE [dbo].[ServiceItem] (
    [ServiceItemID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [ServiceItemCode]        NVARCHAR (100) NOT NULL,
    [ServiceItemName]        NVARCHAR (255) NOT NULL,
    [ServiceItemDescription] NVARCHAR (500) NULL,
    [RowVersion]             BIGINT         NOT NULL,
    [IsActive]               BIT            CONSTRAINT [DF_ServiceItem_IsActive] DEFAULT ((1)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF_ServiceItem_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF_ServiceItem_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF_ServiceItem_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [ServiceTypeID]          BIGINT         NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK79_1] PRIMARY KEY NONCLUSTERED ([ServiceItemID] ASC),
    CONSTRAINT [RefServiceType382] FOREIGN KEY ([ServiceTypeID]) REFERENCES [dbo].[ServiceType] ([ServiceTypeID])
);



