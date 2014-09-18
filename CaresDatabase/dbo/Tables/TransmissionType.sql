CREATE TABLE [dbo].[TransmissionType] (
    [TransmissionTypeID]   SMALLINT       IDENTITY (1, 1) NOT NULL,
    [TransmissionTypeName] NVARCHAR (255) NULL,
    [TransmissionTypeCode] NVARCHAR (100) NOT NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK151] PRIMARY KEY NONCLUSTERED ([TransmissionTypeID] ASC)
);

