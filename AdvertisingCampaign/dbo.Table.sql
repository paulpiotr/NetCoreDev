CREATE TABLE [dbo].[AdvertisingCampaign]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(128) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [PricePerClick] MONEY NULL, 
    [NumberOfClicks] INT NULL, 
    [TotalCost] MONEY NULL, 
    [Created] DATETIME NULL
)
