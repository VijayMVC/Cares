CREATE TABLE [dbo].[BPMainType] (
    [BPMainTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BPMainTypeCode]        NVARCHAR (100) NOT NULL,
    [BPMainTypeKey]         SMALLINT       NULL,
    [BPMainTypeName]        NVARCHAR (255) NULL,
    [BPMainTypeDescription] NVARCHAR (500) NULL,
    [RowVersion]            BIGINT         CONSTRAINT [DF__BPMainTyp__RowVe__00AA174D] DEFAULT ((0)) NOT NULL,
    [IsActive]              BIT            CONSTRAINT [DF__BPMainTyp__IsAct__019E3B86] DEFAULT ((1)) NOT NULL,
    [IsDeleted]             BIT            CONSTRAINT [DF__BPMainTyp__IsDel__02925FBF] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]            BIT            CONSTRAINT [DF__BPMainTyp__IsRea__038683F8] DEFAULT ((0)) NOT NULL,
    [IsPrivate]             BIT            CONSTRAINT [DF__BPMainTyp__IsPri__047AA831] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]          DATETIME       NOT NULL,
    [RecCreatedBy]          NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]      NVARCHAR (100) NOT NULL,
    [UserDomainKey]         BIGINT         NOT NULL,
    CONSTRAINT [PK124] PRIMARY KEY CLUSTERED ([BPMainTypeID] ASC)
);

