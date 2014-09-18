CREATE TABLE [dbo].[InspectionReportType] (
    [InspectionReportTypeID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [InspectionReportTypeCode]        NVARCHAR (100) NOT NULL,
    [InspectionReportTypeName]        NVARCHAR (255) NULL,
    [InspectionReportTypeDescription] NVARCHAR (500) NULL,
    [InspectionReportTypeKey]         SMALLINT       NULL,
    [IsActive]                        BIT            CONSTRAINT [DF__Inspectio__IsAct__10AB74EC] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                       BIT            CONSTRAINT [DF__Inspectio__IsDel__119F9925] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                      BIT            CONSTRAINT [DF__Inspectio__IsRea__1293BD5E] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                       BIT            CONSTRAINT [DF__Inspectio__IsPri__1387E197] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                    DATETIME       NOT NULL,
    [RecCreatedBy]                    NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]                NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]                DATETIME       NOT NULL,
    [RowVersion]                      BIGINT         NOT NULL,
    [UserDomainKey]                   BIGINT         NOT NULL,
    CONSTRAINT [PK12_1_2_2_1] PRIMARY KEY NONCLUSTERED ([InspectionReportTypeID] ASC)
);

