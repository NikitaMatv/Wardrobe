
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/15/2023 11:13:13
-- Generated from EDMX file: C:\Users\Пользователь\source\repos\Wardrobe\Wardrobe\Component\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [wardrobe_selection];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Clothes_CollorId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clothes] DROP CONSTRAINT [FK_Clothes_CollorId];
GO
IF OBJECT_ID(N'[dbo].[FK_Clothes_Type]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clothes] DROP CONSTRAINT [FK_Clothes_Type];
GO
IF OBJECT_ID(N'[dbo].[FK_Type_Weather]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Type] DROP CONSTRAINT [FK_Type_Weather];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Gender]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Gender];
GO
IF OBJECT_ID(N'[dbo].[FK_User_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_RoleId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clothes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clothes];
GO
IF OBJECT_ID(N'[dbo].[Collor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Collor];
GO
IF OBJECT_ID(N'[dbo].[Gender]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gender];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Type];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Weather]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Weather];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clothes'
CREATE TABLE [dbo].[Clothes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [TypeId] int  NOT NULL,
    [ColourId] int  NOT NULL,
    [Size] nvarchar(255)  NOT NULL,
    [Photo] varbinary(max)  NULL
);
GO

-- Creating table 'Collor'
CREATE TABLE [dbo].[Collor] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titile] nvarchar(50)  NULL
);
GO

-- Creating table 'Gender'
CREATE TABLE [dbo].[Gender] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titile] nvarchar(50)  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Type'
CREATE TABLE [dbo].[Type] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(255)  NOT NULL,
    [Description] nvarchar(255)  NOT NULL,
    [WeatherId] int  NULL,
    [TemperatureMin] int  NULL,
    [TemperatureMax] int  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Surname] nvarchar(255)  NOT NULL,
    [GenderId] int  NOT NULL,
    [Age] int  NOT NULL,
    [Login] nvarchar(255)  NOT NULL,
    [Password] nvarchar(255)  NOT NULL,
    [Сode_Word] nvarchar(50)  NULL,
    [DateReg] datetime  NULL,
    [RoleId] int  NULL
);
GO

-- Creating table 'Weather'
CREATE TABLE [dbo].[Weather] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titile] nvarchar(250)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Clothes'
ALTER TABLE [dbo].[Clothes]
ADD CONSTRAINT [PK_Clothes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Collor'
ALTER TABLE [dbo].[Collor]
ADD CONSTRAINT [PK_Collor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Gender'
ALTER TABLE [dbo].[Gender]
ADD CONSTRAINT [PK_Gender]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'Type'
ALTER TABLE [dbo].[Type]
ADD CONSTRAINT [PK_Type]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Weather'
ALTER TABLE [dbo].[Weather]
ADD CONSTRAINT [PK_Weather]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ColourId] in table 'Clothes'
ALTER TABLE [dbo].[Clothes]
ADD CONSTRAINT [FK_Clothes_CollorId]
    FOREIGN KEY ([ColourId])
    REFERENCES [dbo].[Collor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Clothes_CollorId'
CREATE INDEX [IX_FK_Clothes_CollorId]
ON [dbo].[Clothes]
    ([ColourId]);
GO

-- Creating foreign key on [TypeId] in table 'Clothes'
ALTER TABLE [dbo].[Clothes]
ADD CONSTRAINT [FK_Clothes_Type]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[Type]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Clothes_Type'
CREATE INDEX [IX_FK_Clothes_Type]
ON [dbo].[Clothes]
    ([TypeId]);
GO

-- Creating foreign key on [GenderId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Gender]
    FOREIGN KEY ([GenderId])
    REFERENCES [dbo].[Gender]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Gender'
CREATE INDEX [IX_FK_User_Gender]
ON [dbo].[User]
    ([GenderId]);
GO

-- Creating foreign key on [RoleId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_RoleId]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_RoleId'
CREATE INDEX [IX_FK_User_RoleId]
ON [dbo].[User]
    ([RoleId]);
GO

-- Creating foreign key on [WeatherId] in table 'Type'
ALTER TABLE [dbo].[Type]
ADD CONSTRAINT [FK_Type_Weather]
    FOREIGN KEY ([WeatherId])
    REFERENCES [dbo].[Weather]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Type_Weather'
CREATE INDEX [IX_FK_Type_Weather]
ON [dbo].[Type]
    ([WeatherId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------