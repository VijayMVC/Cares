CREATE TABLE [dbo].[CreditLimit] (
    [CreditLimitID]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [IsIndividual]        BIT            NOT NULL,
    [Description]         NVARCHAR (500) NULL,
    [StandardCreditLimit] FLOAT (53)     NOT NULL,
    [BPRatingTypeID]      SMALLINT       NOT NULL,
    [BPSubTypeID]         SMALLINT       NOT NULL,
    [IsActive]            BIT            NOT NULL,
    [IsDeleted]           BIT            NOT NULL,
    [IsReadOnly]          BIT            NOT NULL,
    [IsPrivate]           BIT            NOT NULL,
    [RowVersion]          BIGINT         NOT NULL,
    [RecCreatedBy]        NVARCHAR (100) NOT NULL,
    [RecCreatedDt]        DATETIME       NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]    DATETIME       NOT NULL,
    [UserDomainKey]       BIGINT         NOT NULL,
    CONSTRAINT [PK245] PRIMARY KEY NONCLUSTERED ([CreditLimitID] ASC),
    CONSTRAINT [RefBPRatingType553] FOREIGN KEY ([BPRatingTypeID]) REFERENCES [dbo].[BPRatingType] ([BPRatingTypeID]),
    CONSTRAINT [RefBPSubType554] FOREIGN KEY ([BPSubTypeID]) REFERENCES [dbo].[BPSubType] ([BPSubTypeID])
);



