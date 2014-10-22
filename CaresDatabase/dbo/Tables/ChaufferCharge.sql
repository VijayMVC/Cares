CREATE TABLE [dbo].[ChaufferCharge] (
    [ChaufferChargeID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [ChildChaufferChargeID] BIGINT         NULL,
    [ChaufferChargeMainID]  BIGINT         NOT NULL,
    [DesigGradeID]          BIGINT         NOT NULL,
    [ChaufferChargeRate]    FLOAT (53)     NOT NULL,
    [RevisionNumber]        BIGINT         NOT NULL,
    [IsActive]              BIT            CONSTRAINT [DF__ChaufferC__IsAct__2022C2A6] DEFAULT ((1)) NOT NULL,
    [IsDeleted]             BIT            CONSTRAINT [DF__ChaufferC__IsDel__2116E6DF] DEFAULT ((0)) NOT NULL,
    [IsPrivate]             BIT            CONSTRAINT [DF__ChaufferC__IsPri__220B0B18] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]            BIT            CONSTRAINT [DF__ChaufferC__IsRea__22FF2F51] DEFAULT ((0)) NOT NULL,
    [RowVersion]            BIGINT         NOT NULL,
    [RecCreatedDt]          DATETIME       NOT NULL,
    [RecLastUpdatedDt]      DATETIME       NOT NULL,
    [RecCreatedBy]          NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]      NVARCHAR (100) NOT NULL,
    [StartDt]               DATETIME       NOT NULL,
    [UserDomainKey]         BIGINT         NOT NULL,
    CONSTRAINT [PK80_1] PRIMARY KEY NONCLUSTERED ([ChaufferChargeID] ASC),
    CONSTRAINT [RefChaufferCharge397] FOREIGN KEY ([ChildChaufferChargeID]) REFERENCES [dbo].[ChaufferCharge] ([ChaufferChargeID]),
    CONSTRAINT [RefChaufferChargeMain399] FOREIGN KEY ([ChaufferChargeMainID]) REFERENCES [dbo].[ChaufferChargeMain] ([ChaufferChargeMainID]) ON DELETE CASCADE,
    CONSTRAINT [RefDesigGrade528] FOREIGN KEY ([DesigGradeID]) REFERENCES [dbo].[DesigGrade] ([DesigGradeID])
);



