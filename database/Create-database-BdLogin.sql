-- Drop DataBase Login
CREATE DATABASE [BdLogin]
GO
USE BdLogin
CREATE TABLE [dbo].[TabelaLogin](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL
) ON [PRIMARY]
