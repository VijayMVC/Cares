CREATE TABLE [dbo].[ServiceRt] (
    [ServiceRtID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [ServiceRtMainID]  BIGINT         NOT NULL,
    [ServiceItemID]    BIGINT         NOT NULL,
    [ChildServiceRtID] BIGINT         NULL,
    [ServiceRate]      FLOAT (53)     NOT NULL,
    [RevisionNumber]   BIGINT         NOT NULL,
    [StartDt]          DATETIME       NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF_ServiceRt_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF_ServiceRt_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF_ServiceRt_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF_ServiceRt_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [RowVersion]       BIGINT         NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK111_1] PRIMARY KEY NONCLUSTERED ([ServiceRtID] ASC),
    CONSTRAINT [RefServiceItem383] FOREIGN KEY ([ServiceItemID]) REFERENCES [dbo].[ServiceItem] ([ServiceItemID]),
    CONSTRAINT [RefServiceRt386] FOREIGN KEY ([ChildServiceRtID]) REFERENCES [dbo].[ServiceRt] ([ServiceRtID]),
    CONSTRAINT [RefServiceRtMain385] FOREIGN KEY ([ServiceRtMainID]) REFERENCES [dbo].[ServiceRtMain] ([ServiceRtMainID]) ON DELETE CASCADE
);



