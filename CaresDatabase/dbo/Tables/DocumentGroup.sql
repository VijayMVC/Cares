CREATE TABLE [dbo].[DocumentGroup] (
    [DocumentGroupID]          INT            IDENTITY (1, 1) NOT NULL,
    [DocumentGroupCode]        NVARCHAR (100) NOT NULL,
    [DocumentGroupName]        NVARCHAR (255) NULL,
    [DocumentGroupDescription] NVARCHAR (500) NULL,
    [RowVersion]               BIGINT         CONSTRAINT [DF__DocumentG__RowVe__5A4F643B] DEFAULT ((0)) NOT NULL,
    [IsActive]                 BIT            CONSTRAINT [DF__DocumentG__IsAct__5B438874] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                BIT            CONSTRAINT [DF__DocumentG__IsDel__5C37ACAD] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                BIT            CONSTRAINT [DF__DocumentG__IsPri__5D2BD0E6] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]               BIT            CONSTRAINT [DF__DocumentG__IsRea__5E1FF51F] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]             DATETIME       NOT NULL,
    [RecCreatedBy]             NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]         DATETIME       NOT NULL,
    [RecLastUpdatedBy]         NVARCHAR (100) NOT NULL,
    [UserDomainKey]            BIGINT         NOT NULL,
    CONSTRAINT [PK129] PRIMARY KEY CLUSTERED ([DocumentGroupID] ASC)
);

