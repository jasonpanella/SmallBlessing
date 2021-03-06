﻿/*
Deployment script for SmallBlessings

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SmallBlessings"
:setvar DefaultFilePrefix "SmallBlessings"
:setvar DefaultDataPath "c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key 40ce795b-2ad1-4975-a743-612d6c8b3175 is skipped, element [dbo].[Items].[Id] (SqlSimpleColumn) will not be renamed to ItemId';


GO
PRINT N'Creating [dbo].[Dependents]...';


GO
CREATE TABLE [dbo].[Dependents] (
    [DependentID]  INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NOT NULL,
    [BirthDate]    DATE         NOT NULL,
    [Relationship] VARCHAR (50) NOT NULL,
    [LivesWith]    VARCHAR (50) NOT NULL,
    [PersonID]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([DependentID] ASC)
);


GO
PRINT N'Creating [dbo].[Items]...';


GO
CREATE TABLE [dbo].[Items] (
    [ItemId]      INT           NOT NULL,
    [Comments]    VARCHAR (MAX) NULL,
    [Description] VARCHAR (MAX) NOT NULL,
    [Initials]    VARCHAR (10)  NOT NULL,
    [Date]        DATETIME      NOT NULL,
    [PersonID]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ItemId] ASC)
);


GO
PRINT N'Creating [dbo].[Person]...';


GO
CREATE TABLE [dbo].[Person] (
    [PersonID]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]        VARCHAR (50)   NOT NULL,
    [MiddleInitial]    VARCHAR (1)    NULL,
    [LastName]         VARCHAR (50)   NOT NULL,
    [Address]          VARCHAR (50)   NOT NULL,
    [Phone]            VARCHAR (50)   NOT NULL,
    [ChurchHomeFlag]   BIT            NOT NULL,
    [ChurchHomeName]   VARCHAR (50)   NULL,
    [Opinion]          NVARCHAR (MAX) NULL,
    [BirthDate]        DATE           NOT NULL,
    [DateCreated]      DATETIME       NOT NULL,
    [DateUpdated]      DATETIME       NOT NULL,
    [PhoneContactFlag] BIT            NOT NULL,
    [City]             VARCHAR (50)   NOT NULL,
    [State]            VARCHAR (50)   NOT NULL,
    [Zip]              VARCHAR (5)    NOT NULL,
    PRIMARY KEY CLUSTERED ([PersonID] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Dependents_Person]...';


GO
ALTER TABLE [dbo].[Dependents] WITH NOCHECK
    ADD CONSTRAINT [FK_Dependents_Person] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID]);


GO
PRINT N'Creating [dbo].[FK_Items_Person]...';


GO
ALTER TABLE [dbo].[Items] WITH NOCHECK
    ADD CONSTRAINT [FK_Items_Person] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '40ce795b-2ad1-4975-a743-612d6c8b3175')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('40ce795b-2ad1-4975-a743-612d6c8b3175')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Dependents] WITH CHECK CHECK CONSTRAINT [FK_Dependents_Person];

ALTER TABLE [dbo].[Items] WITH CHECK CHECK CONSTRAINT [FK_Items_Person];


GO
PRINT N'Update complete.';


GO
