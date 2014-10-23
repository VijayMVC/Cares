CREATE TABLE [dbo].[InsuranceRt] (
    [InsuranceRtID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [ChildInsuranceRtID] BIGINT         NULL,
    [InsuranceRtMainID]  BIGINT         NOT NULL,
    [InsuranceTypeID]    SMALLINT       NOT NULL,
    [HireGroupDetailID]  BIGINT         NOT NULL,
    [InsuranceRate]      FLOAT (53)     NOT NULL,
    [StartDt]            DATETIME       NOT NULL,
    [IsActive]           BIT            CONSTRAINT [DF_InsuranceRt_IsActive] DEFAULT ((1)) NOT NULL,
    [RevisionNumber]     BIGINT         NOT NULL,
    [IsDeleted]          BIT            CONSTRAINT [DF_InsuranceRt_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsPrivate]          BIT            CONSTRAINT [DF_InsuranceRt_IsPrivate] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]         BIT            CONSTRAINT [DF_InsuranceRt_IsReadOnly] DEFAULT ((0)) NOT NULL,
    [RowVersion]         BIGINT         NOT NULL,
    [RecCreatedDt]       DATETIME       NOT NULL,
    [RecLastUpdatedDt]   DATETIME       NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (100) NOT NULL,
    [RecCreatedBy]       NVARCHAR (100) NOT NULL,
    [UserDomainKey]      BIGINT         NOT NULL,
    CONSTRAINT [PK111_1_1] PRIMARY KEY NONCLUSTERED ([InsuranceRtID] ASC),
    CONSTRAINT [RefHireGroupDetail404] FOREIGN KEY ([HireGroupDetailID]) REFERENCES [dbo].[HireGroupDetail] ([HireGroupDetailID]) ON DELETE CASCADE,
    CONSTRAINT [RefInsuranceRt391] FOREIGN KEY ([ChildInsuranceRtID]) REFERENCES [dbo].[InsuranceRt] ([InsuranceRtID]),
    CONSTRAINT [RefInsuranceRtMain390] FOREIGN KEY ([InsuranceRtMainID]) REFERENCES [dbo].[InsuranceRtMain] ([InsuranceRtMainID]) ON DELETE CASCADE,
    CONSTRAINT [RefInsuranceType392] FOREIGN KEY ([InsuranceTypeID]) REFERENCES [dbo].[InsuranceType] ([InsuranceTypeID])
);



