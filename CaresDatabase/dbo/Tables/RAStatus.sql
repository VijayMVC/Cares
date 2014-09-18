CREATE TABLE [dbo].[RAStatus] (
    [RAStatusID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [RAStatusCode]        NVARCHAR (100) NOT NULL,
    [RAStatusName]        NVARCHAR (255) NULL,
    [RAStatusDescription] NVARCHAR (500) NULL,
    [RAStatusKey]         SMALLINT       NULL,
    [RowVersion]          BIGINT         CONSTRAINT [DF__RAStatus__RowVer__379037E3] DEFAULT ((0)) NOT NULL,
    [IsActive]            BIT            CONSTRAINT [DF__RAStatus__IsActi__38845C1C] DEFAULT ((1)) NOT NULL,
    [IsDeleted]           BIT            CONSTRAINT [DF__RAStatus__IsDele__39788055] DEFAULT ((0)) NOT NULL,
    [IsPrivate]           BIT            CONSTRAINT [DF__RAStatus__IsPriv__3A6CA48E] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]          BIT            CONSTRAINT [DF__RAStatus__IsRead__3B60C8C7] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]        NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]    DATETIME       NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (100) NOT NULL,
    [IsRA]                BIT            CONSTRAINT [DF__RAStatus__IsRA__3C54ED00] DEFAULT ((1)) NOT NULL,
    [UserDomainKey]       BIGINT         NOT NULL,
    CONSTRAINT [PK89_1_4] PRIMARY KEY NONCLUSTERED ([RAStatusID] ASC)
);

