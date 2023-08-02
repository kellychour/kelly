USE [kelly]
GO

/****** Object: Table [dbo].[Order] Script Date: 3/08/2023 10:59:55 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Order];


GO
CREATE TABLE [dbo].[Order] (
    [OrderID]      INT            IDENTITY (1, 1) NOT NULL,
    [CustomerName] NVARCHAR (MAX) NOT NULL,
    [OrderTime]    DATETIME2 (7)  NOT NULL,
    [PickupTime]   DATETIME2 (7)  NOT NULL,
    [OrderStatus]  NVARCHAR (10)     NOT NULL
);


