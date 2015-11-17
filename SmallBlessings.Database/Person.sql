CREATE TABLE [dbo].[Person]
(
	[PersonID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [MiddleInitial] VARCHAR NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(50) NOT NULL, 
    [Phone] VARCHAR(50) NOT NULL, 
    [ChurchHomeFlag] BIT NOT NULL, 
    [ChurchHomeName] VARCHAR(50) NULL, 
    [Opinion] NVARCHAR(MAX) NULL, 
    [BirthDate] DATE NOT NULL, 
    [DateCreated] DATETIME NOT NULL, 
    [DateUpdated] DATETIME NOT NULL, 
    [PhoneContactFlag] BIT NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [State] VARCHAR(50) NOT NULL, 
    [Zip] VARCHAR(5) NOT NULL, 
    [ExportFlag] BIT NOT NULL, 
    [ProofGuardianFlag] BIT NOT NULL, 
    [LockItemDate] DATETIME NULL, 
    [LockItemFlag] BIT NOT NULL
)
