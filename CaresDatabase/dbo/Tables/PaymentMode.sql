CREATE TABLE [dbo].[PaymentMode] (
    [PaymentModeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [PaymentModeCode]        NVARCHAR (100) NOT NULL,
    [PaymentModeName]        NVARCHAR (255) NULL,
    [PaymentModeDescription] NVARCHAR (500) NULL,
    [PaymentModeKey]         SMALLINT       NULL,
    [RowVersion]             BIGINT         CONSTRAINT [DF__PaymentMo__RowVe__6F1576F7] DEFAULT ((0)) NOT NULL,
    [IsActive]               BIT            CONSTRAINT [DF__PaymentMo__IsAct__70099B30] DEFAULT ((1)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF__PaymentMo__IsDel__70FDBF69] DEFAULT ((0)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF__PaymentMo__IsPri__71F1E3A2] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF__PaymentMo__IsRea__72E607DB] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK89_1_2_1] PRIMARY KEY NONCLUSTERED ([PaymentModeID] ASC)
);

