/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [OrderId]
      ,[UserID]
      ,[GallonRequested]
      ,[DeliveryDate]
	  ,[DeliveryAddress]
      ,[SuggesetedPrice]
      ,[TotalAmountDue]
  FROM [FUELSTATION].[UserManagementMaster].[FuelQuoteForm]

  ALTER TABLE [FUELSTATION].[UserManagementMaster].[FuelQuoteForm]

  ALTER TABLE [FUELSTATION].[UserManagementMaster].[FuelQuoteForm] ALTER COLUMN [DeliveryDate] datetime;
  ALTER TABLE [FUELSTATION].[UserManagementMaster].[FuelQuoteForm] ALTER COLUMN [DeliveryDate] varchar(50);

  ALTER TABLE [FUELSTATION].[UserManagementMaster].[FuelQuoteForm] ADD [DeliveryAddress] varchar NULL;

  delete from  [FUELSTATION].[UserManagementMaster].[FuelQuoteForm]

    ALTER TABLE [FUELSTATION].[UserManagementMaster].[FuelQuoteForm] ALTER COLUMN [DeliveryAddress] varchar(250)