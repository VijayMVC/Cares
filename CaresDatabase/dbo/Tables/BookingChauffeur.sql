CREATE TABLE [dbo].[BookingChauffeur] (
    [BookingChauffeurID] BIGINT   IDENTITY (1, 1) NOT NULL,
    [BookingMainID]      BIGINT   NOT NULL,
    [ChauffeurID]        BIGINT   NOT NULL,
    [StartDate]          DATETIME NOT NULL,
    [EndDate]            DATETIME NOT NULL,
    [DomainKey]          BIGINT   NOT NULL,
    CONSTRAINT [PK_BookingChauffeur] PRIMARY KEY CLUSTERED ([BookingChauffeurID] ASC),
    CONSTRAINT [FK_BookingChauffeur_BookingMain] FOREIGN KEY ([BookingMainID]) REFERENCES [dbo].[BookingMain] ([BookingMainID]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookingChauffeur_Employee] FOREIGN KEY ([ChauffeurID]) REFERENCES [dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE
);

