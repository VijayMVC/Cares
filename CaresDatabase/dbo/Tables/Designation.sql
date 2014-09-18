CREATE TABLE [dbo].[Designation] (
    [DesignationID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [DesignationCode]        NVARCHAR (100) NOT NULL,
    [DesignationName]        NVARCHAR (255) NULL,
    [DesignationDescription] NVARCHAR (500) NULL,
    [DesignationKey]         BIGINT         NULL,
    [RowVersion]             BIGINT         CONSTRAINT [DF__Designati__RowVe__17ED6F58] DEFAULT ((0)) NOT NULL,
    [IsActive]               BIT            CONSTRAINT [DF__Designati__IsAct__18E19391] DEFAULT ((1)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF__Designati__IsPri__19D5B7CA] DEFAULT ((0)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF__Designati__IsDel__1AC9DC03] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF__Designati__IsRea__1BBE003C] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    CONSTRAINT [PK43] PRIMARY KEY CLUSTERED ([DesignationID] ASC)
);

