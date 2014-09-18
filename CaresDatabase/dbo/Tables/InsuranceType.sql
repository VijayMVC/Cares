CREATE TABLE [dbo].[InsuranceType] (
    [InsuranceTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [InsuranceTypeCode]        NVARCHAR (100) NOT NULL,
    [InsuranceTypeName]        NVARCHAR (255) NULL,
    [InsuranceTypeDescription] NVARCHAR (500) NULL,
    [IsActive]                 BIT            CONSTRAINT [DF__Insurance__IsAct__1C1D2798] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                BIT            CONSTRAINT [DF__Insurance__IsDel__1D114BD1] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]               BIT            CONSTRAINT [DF__Insurance__IsRea__1E05700A] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                BIT            CONSTRAINT [DF__Insurance__IsPri__1EF99443] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]             DATETIME       NOT NULL,
    [RecCreatedBy]             NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]         NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]         DATETIME       NOT NULL,
    [RowVersion]               BIGINT         NOT NULL,
    [UserDomainKey]            BIGINT         NOT NULL,
    CONSTRAINT [PK12_1_2] PRIMARY KEY NONCLUSTERED ([InsuranceTypeID] ASC)
);

