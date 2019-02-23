CREATE TABLE [dbo].[Dependents]
(
	[DependentID] INT NOT NULL IDENTITY , 
    [Name] VARCHAR(50) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [Relationship] VARCHAR(50) NOT NULL, 
    [LivesWith] VARCHAR(50) NOT NULL, 
    [PersonID] INT NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 0, 
    PRIMARY KEY ([DependentID]), 
    CONSTRAINT [FK_Dependents_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID])
)
