CREATE TABLE [dbo].[BPRelationshipType] (
    [BPRelationshipTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BPRelationshipTypeCode]        NVARCHAR (100) NOT NULL,
    [BPRelationshipTypeName]        NVARCHAR (255) NULL,
    [BPRelationshipTypeDescription] NVARCHAR (500) NULL,
    [RowVersion]                    BIGINT         CONSTRAINT [DF__BPRelatio__RowVe__0C1BC9F9] DEFAULT ((0)) NOT NULL,
    [IsActive]                      BIT            CONSTRAINT [DF__BPRelatio__IsAct__0D0FEE32] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                     BIT            CONSTRAINT [DF__BPRelatio__IsDel__0E04126B] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                     BIT            CONSTRAINT [DF__BPRelatio__IsPri__0EF836A4] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                    BIT            CONSTRAINT [DF__BPRelatio__IsRea__0FEC5ADD] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                  DATETIME       NOT NULL,
    [RecCreatedBy]                  NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]              DATETIME       NOT NULL,
    [RecLastUpdatedBy]              NVARCHAR (100) NOT NULL,
    [UserDomainKey]                 BIGINT         NOT NULL,
    CONSTRAINT [PK73] PRIMARY KEY CLUSTERED ([BPRelationshipTypeID] ASC)
);

