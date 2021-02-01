
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/23/2021 05:07:07
-- Generated from EDMX file: C:\Users\killiankraus\Documents\GitHub\ThriveTech\sb-admin-2.Web\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Registration];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Calendar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Calendar];
GO
IF OBJECT_ID(N'[dbo].[Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Members];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Calendars'
CREATE TABLE [dbo].[Calendars] (
    [EventID] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Start] datetime  NULL,
    [End] datetime  NULL,
    [ThemeColor] nvarchar(50)  NULL,
    [IsFullDay] bit  NOT NULL
);
GO

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [StudentId] int IDENTITY(1,1) NOT NULL,
    [Lastname] nvarchar(max)  NULL,
    [Firstname] nvarchar(max)  NULL,
    [Middlename] nvarchar(max)  NULL,
    [Sex] nchar(10)  NULL,
    [Age] nchar(10)  NULL,
    [Contact_number] nvarchar(20)  NULL,
    [Email] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EventID] in table 'Calendars'
ALTER TABLE [dbo].[Calendars]
ADD CONSTRAINT [PK_Calendars]
    PRIMARY KEY CLUSTERED ([EventID] ASC);
GO

-- Creating primary key on [StudentId] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([StudentId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------