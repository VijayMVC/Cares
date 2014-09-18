CREATE TABLE [dbo].[FuelType] (
    [FuelTypeID]    SMALLINT       IDENTITY (1, 1) NOT NULL,
    [FuelTypeCode]  NVARCHAR (100) NOT NULL,
    [FuelTypeName]  NVARCHAR (255) NULL,
    [UserDomainKey] BIGINT         NOT NULL,
    CONSTRAINT [PK150] PRIMARY KEY NONCLUSTERED ([FuelTypeID] ASC)
);

