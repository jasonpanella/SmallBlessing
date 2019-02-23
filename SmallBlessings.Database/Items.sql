CREATE TABLE [dbo].[Items]
(
	[ItemId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Comments] VARCHAR(MAX) NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [Initials] VARCHAR(10) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [PersonID] INT NOT NULL, 
    [isActive] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Items_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID])
)
