CREATE TABLE [dbo].[DesigGrade] (
    [DesigGradeID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [DesigGradeCode]        NVARCHAR (100) NOT NULL,
    [DesigGradeName]        NVARCHAR (255) NULL,
    [DesigGradeDescription] NVARCHAR (500) NULL,
    [RowVersion]            BIGINT         CONSTRAINT [DF__DesigGrad__RowVe__114071C9] DEFAULT ((0)) NOT NULL,
    [IsActive]              BIT            CONSTRAINT [DF__DesigGrad__IsAct__12349602] DEFAULT ((1)) NOT NULL,
    [IsPrivate]             BIT            CONSTRAINT [DF__DesigGrad__IsPri__1328BA3B] DEFAULT ((0)) NOT NULL,
    [IsDeleted]             BIT            CONSTRAINT [DF__DesigGrad__IsDel__141CDE74] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]            BIT            CONSTRAINT [DF__DesigGrad__IsRea__151102AD] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]          DATETIME       NOT NULL,
    [RecCreatedBy]          NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]      NVARCHAR (100) NOT NULL,
    [UserDomainKey]         BIGINT         NOT NULL,
    CONSTRAINT [PK43_2] PRIMARY KEY CLUSTERED ([DesigGradeID] ASC)
);

