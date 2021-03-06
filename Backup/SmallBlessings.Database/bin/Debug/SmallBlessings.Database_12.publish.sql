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
PRINT N'Rename refactoring operation with key 5070bec1-6158-48c3-9781-d1482e9cc083 is skipped, element [dbo].[Dependents].[ChildLivesWith] (SqlSimpleColumn) will not be renamed to LivesWith';


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
PRINT N'Creating [dbo].[FK_Dependents_Person]...';


GO
ALTER TABLE [dbo].[Dependents] WITH NOCHECK
    ADD CONSTRAINT [FK_Dependents_Person] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5070bec1-6158-48c3-9781-d1482e9cc083')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5070bec1-6158-48c3-9781-d1482e9cc083')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Dependents] WITH CHECK CHECK CONSTRAINT [FK_Dependents_Person];


GO
PRINT N'Update complete.';


GO
