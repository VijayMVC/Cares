CREATE TABLE [dbo].[MeasurementUnit] (
    [MeasurementUnitID]          SMALLINT       NOT NULL,
    [MeasurementUnitCode]        NVARCHAR (100) NOT NULL,
    [MeasurementUnitName]        NVARCHAR (255) NULL,
    [MeasurementUnitDescription] NVARCHAR (500) NULL,
    [MeasurementUnitKey]         SMALLINT       NOT NULL,
    [RowVersion]                 BIGINT         CONSTRAINT [DF__Measureme__RowVe__35DCF99B] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]               DATETIME       NOT NULL,
    [RecLastUpdatedDt]           DATETIME       NOT NULL,
    [RecLastUpdatedBy]           NVARCHAR (100) NOT NULL,
    [RecCreatedBy]               NVARCHAR (100) NOT NULL,
    [IsActive]                   BIT            CONSTRAINT [DF__Measureme__IsAct__36D11DD4] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                  BIT            CONSTRAINT [DF__Measureme__IsDel__37C5420D] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                  BIT            CONSTRAINT [DF__Measureme__IsPri__38B96646] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                 BIT            CONSTRAINT [DF__Measureme__IsRea__39AD8A7F] DEFAULT ((0)) NOT NULL,
    [UserDomainKey]              BIGINT         NOT NULL,
    CONSTRAINT [PK78_1] PRIMARY KEY NONCLUSTERED ([MeasurementUnitID] ASC)
);

