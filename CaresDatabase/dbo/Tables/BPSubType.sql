CREATE TABLE [dbo].[BPSubType] (
    [BPSubTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BPSubTypeCode]        NVARCHAR (100) NOT NULL,
    [BPSubTypeKey]         SMALLINT       NULL,
    [BPSubTypeName]        NVARCHAR (255) NULL,
    [BPSubTypeDescription] NVARCHAR (500) NULL,
    [BPMainTypeID]         SMALLINT       NOT NULL,
    [RowVersion]           BIGINT         CONSTRAINT [DF__BPSubType__RowVe__10E07F16] DEFAULT ((0)) NOT NULL,
    [IsActive]             BIT            CONSTRAINT [DF__BPSubType__IsAct__11D4A34F] DEFAULT ((1)) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF__BPSubType__IsDel__12C8C788] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]           BIT            CONSTRAINT [DF__BPSubType__IsRea__13BCEBC1] DEFAULT ((0)) NOT NULL,
    [IsPrivate]            BIT            CONSTRAINT [DF__BPSubType__IsPri__14B10FFA] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]         DATETIME       NOT NULL,
    [RecCreatedBy]         NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]     DATETIME       NOT NULL,
    [RecLastUpdatedBy]     NVARCHAR (100) NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK68] PRIMARY KEY CLUSTERED ([BPSubTypeID] ASC),
    CONSTRAINT [RefBPMainType288] FOREIGN KEY ([BPMainTypeID]) REFERENCES [dbo].[BPMainType] ([BPMainTypeID])
);

