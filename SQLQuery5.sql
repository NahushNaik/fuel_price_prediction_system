/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [UserId]
      ,[LoginId]
      ,[Password]
      ,[FullName]
      ,[Address1]
      ,[Address2]
      ,[City]
      ,[State]
      ,[ZipCode]
      ,[IsActive]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[NewUser]
  FROM [FUELSTATION].[UserManagementMaster].[User]


UPDATE [FUELSTATION].[UserManagementMaster].[User] set Password = '12345678' where UserId=2
UPDATE [FUELSTATION].[UserManagementMaster].[User] set Password = '12345678' where UserId=1
UPDATE [FUELSTATION].[UserManagementMaster].[User] set NewUser = 0 where UserId=1
UPDATE [FUELSTATION].[UserManagementMaster].[User] set NewUser = 1 where UserId=2
UPDATE [FUELSTATION].[UserManagementMaster].[User] set NewUser = 1 where UserId=3
UPDATE [FUELSTATION].[UserManagementMaster].[User] set NewUser = 1 where UserId=4
UPDATE [FUELSTATION].[UserManagementMaster].[User] set NewUser = 1 where UserId=105

UPDATE [FUELSTATION].[UserManagementMaster].[User] set Address1 = '4045, Linkwood Drive' where UserId=2

delete from  [FUELSTATION].[UserManagementMaster].[User] where UserId = 2
delete from  [FUELSTATION].[UserManagementMaster].[User] where UserId = 3
delete from  [FUELSTATION].[UserManagementMaster].[User] where UserId = 106