CREATE TABLE [dbo].[JobType] (
    [JobTypeID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [JobTypeCode]        NVARCHAR (100) NOT NULL,
    [JobTypeName]        NVARCHAR (255) NULL,
    [JobTypeDescription] NVARCHAR (500) NULL,
    [RowVersion]         BIGINT         CONSTRAINT [DF__JobType__RowVers__1FEDB87C] DEFAULT ((0)) NOT NULL,
    [IsActive]           BIT            CONSTRAINT [DF__JobType__IsActiv__20E1DCB5] DEFAULT ((1)) NOT NULL,
    [IsPrivate]          BIT            CONSTRAINT [DF__JobType__IsPriva__21D600EE] DEFAULT ((0)) NOT NULL,
    [IsDeleted]          BIT            CONSTRAINT [DF__JobType__IsDelet__22CA2527] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]         BIT            CONSTRAINT [DF__JobType__IsReadO__23BE4960] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]       DATETIME       NOT NULL,
    [RecCreatedBy]       NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]   DATETIME       NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (100) NOT NULL,
    [UserDomainKey]      BIGINT         NOT NULL,
    CONSTRAINT [PK43_1] PRIMARY KEY CLUSTERED ([JobTypeID] ASC)
);

