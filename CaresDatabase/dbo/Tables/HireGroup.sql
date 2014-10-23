CREATE TABLE [dbo].[HireGroup] (
    [HireGroupID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [ParentHireGroupID]    BIGINT         NULL,
    [HireGroupName]        NVARCHAR (255) NULL,
    [HireGroupDescription] NVARCHAR (500) NULL,
    [HireGroupCode]        NVARCHAR (100) NOT NULL,
    [IsParent]             BIT            CONSTRAINT [DF_HireGroup_IsParent] DEFAULT ((1)) NOT NULL,
    [IsActive]             BIT            CONSTRAINT [DF__HireGroup__IsAct__681E60A5] DEFAULT ((1)) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF__HireGroup__IsDel__691284DE] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]           BIT            CONSTRAINT [DF__HireGroup__IsRea__6A06A917] DEFAULT ((0)) NOT NULL,
    [IsPrivate]            BIT            CONSTRAINT [DF__HireGroup__IsPri__6AFACD50] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]         DATETIME       NOT NULL,
    [RecCreatedBy]         NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]     DATETIME       NOT NULL,
    [CompanyID]            BIGINT         NULL,
    [RowVersion]           BIGINT         NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK12] PRIMARY KEY NONCLUSTERED ([HireGroupID] ASC),
    CONSTRAINT [FK_HireGroup_Company] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Company] ([CompanyID]),
    CONSTRAINT [RefHireGroup308] FOREIGN KEY ([ParentHireGroupID]) REFERENCES [dbo].[HireGroup] ([HireGroupID])
);



