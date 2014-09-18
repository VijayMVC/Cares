CREATE TABLE [dbo].[BPRatingType] (
    [BPRatingTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BPRatingTypeCode]        NVARCHAR (100) NOT NULL,
    [BPRatingTypeName]        NVARCHAR (255) NULL,
    [BPRatingTypeDescription] NVARCHAR (500) NULL,
    [RowVersion]              BIGINT         CONSTRAINT [DF__BPRatingT__RowVe__770B9E7A] DEFAULT ((0)) NOT NULL,
    [IsActive]                BIT            CONSTRAINT [DF__BPRatingT__IsAct__77FFC2B3] DEFAULT ((1)) NOT NULL,
    [IsDeleted]               BIT            CONSTRAINT [DF__BPRatingT__IsDel__78F3E6EC] DEFAULT ((0)) NOT NULL,
    [IsPrivate]               BIT            CONSTRAINT [DF__BPRatingT__IsPri__79E80B25] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]              BIT            CONSTRAINT [DF__BPRatingT__IsRea__7ADC2F5E] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]            DATETIME       NOT NULL,
    [RecCreatedBy]            NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]        DATETIME       NOT NULL,
    [RecLastUpdatedBy]        NVARCHAR (100) NOT NULL,
    [UserDomainKey]           BIGINT         NOT NULL,
    CONSTRAINT [PK144] PRIMARY KEY CLUSTERED ([BPRatingTypeID] ASC)
);

