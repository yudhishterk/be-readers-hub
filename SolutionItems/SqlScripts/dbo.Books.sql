USE [ReadersHub]
GO

/****** Object: Table [dbo].[Books] Script Date: 4/23/2023 2:00:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Books] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (100)  NULL,
    [Description] VARCHAR (2000) NULL,
    [Author]      VARCHAR (50)   NULL,
    [ImageUrl]    VARCHAR (200)  NULL
);


