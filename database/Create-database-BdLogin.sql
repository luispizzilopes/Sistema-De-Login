-- Drop DataBase Login
CREATE DATABASE [BdLogin]
GO
USE BdLogin
CREATE TABLE [dbo].[TabelaLogin](
	[Login] [varchar](50) NOT NULL,
	[Senha] [varchar](50) NOT NULL
) ON [PRIMARY]
