CREATE TABLE [dbo].[VehicleInsuranceInfo] (
    [VehicleID]        BIGINT         NOT NULL,
    [InsuranceAgent]   NVARCHAR (100) NULL,
    [CoverageLimit]    INT            NULL,
    [RenewalDate]      DATETIME       NULL,
    [Premium]          FLOAT (53)     NULL,
    [InsuranceDate]    DATETIME       NULL,
    [InsuredValue]     MONEY          NULL,
    [InsuredFrom]      VARCHAR (255)  NULL,
    [BPMainID]         BIGINT         NULL,
    [InsuranceTypeID]  SMALLINT       NOT NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF__VehicleIn__RowVe__17E28260] DEFAULT ((0)) NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK98] PRIMARY KEY NONCLUSTERED ([VehicleID] ASC),
    CONSTRAINT [RefBPMain285] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefInsuranceType315] FOREIGN KEY ([InsuranceTypeID]) REFERENCES [dbo].[InsuranceType] ([InsuranceTypeID]),
    CONSTRAINT [RefVehicle211] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID])
);

