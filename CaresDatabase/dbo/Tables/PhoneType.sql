CREATE TABLE [dbo].[PhoneType] (
    [PhoneTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [PhoneTypeCode]        NVARCHAR (100) NULL,
    [PhoneTypeName]        NVARCHAR (255) NULL,
    [PhoneTypeKey]         SMALLINT       NULL,
    [PhoneTypeDescription] NVARCHAR (500) NULL,
    [IsActive]             BIT            CONSTRAINT [DF__PhoneType__IsAct__45DE573A] DEFAULT ((1)) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF__PhoneType__IsDel__46D27B73] DEFAULT ((0)) NOT NULL,
    [IsPrivate]            BIT            CONSTRAINT [DF__PhoneType__IsPri__47C69FAC] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]           BIT            CONSTRAINT [DF__PhoneType__IsRea__48BAC3E5] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]         DATETIME       NOT NULL,
    [RecCreatedBy]         NVARCHAR (100) NOT NULL,
    [RecLastUpdateDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]     NVARCHAR (100) NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK93] PRIMARY KEY NONCLUSTERED ([PhoneTypeID] ASC)
);

