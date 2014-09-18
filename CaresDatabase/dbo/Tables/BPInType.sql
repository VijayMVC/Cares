CREATE TABLE [dbo].[BPInType] (
    [BPInTypeID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [BPInTypeDescription] NVARCHAR (500) NULL,
    [FromDate]            DATETIME       NULL,
    [ToDate]              DATETIME       NULL,
    [BPMainID]            BIGINT         NOT NULL,
    [BPSubTypeID]         SMALLINT       NOT NULL,
    [RowVersion]          BIGINT         CONSTRAINT [DF__BPInType__RowVer__63F8CA06] DEFAULT ((0)) NOT NULL,
    [BPRatingTypeID]      SMALLINT       NULL,
    [UserDomainKey]       BIGINT         NOT NULL,
    CONSTRAINT [PK67] PRIMARY KEY CLUSTERED ([BPInTypeID] ASC),
    CONSTRAINT [RefBPMain119] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefBPRatingType552] FOREIGN KEY ([BPRatingTypeID]) REFERENCES [dbo].[BPRatingType] ([BPRatingTypeID]),
    CONSTRAINT [RefBPSubType120] FOREIGN KEY ([BPSubTypeID]) REFERENCES [dbo].[BPSubType] ([BPSubTypeID])
);

