CREATE TABLE [dbo].[BPRelationship] (
    [BPRelationshipID]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [BPMainID]             BIGINT         NOT NULL,
    [BPRelationshipTypeID] SMALLINT       NOT NULL,
    [SecondaryBPID]        BIGINT         NOT NULL,
    [RowVersion]           BIGINT         CONSTRAINT [DF__BPRelatio__RowVe__7DB89C09] DEFAULT ((0)) NOT NULL,
    [RecCreatedBy]         NVARCHAR (100) NOT NULL,
    [RecCreatedDt]         DATETIME       NOT NULL,
    [RecLastUpdatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]     DATETIME       NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK72] PRIMARY KEY CLUSTERED ([BPRelationshipID] ASC),
    CONSTRAINT [RefBPMain125] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefBPMain295] FOREIGN KEY ([SecondaryBPID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefBPRelationshipType127] FOREIGN KEY ([BPRelationshipTypeID]) REFERENCES [dbo].[BPRelationshipType] ([BPRelationshipTypeID])
);

