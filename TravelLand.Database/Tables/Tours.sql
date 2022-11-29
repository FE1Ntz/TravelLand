CREATE TABLE [dbo].[Tours]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Price] INT NOT NULL, 
    [Country] NVARCHAR(MAX) NOT NULL, 
    [Town] NVARCHAR(MAX) NOT NULL, 
    [PersonCount] INT NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    [Duration] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Logo] NVARCHAR(MAX) NULL
)
