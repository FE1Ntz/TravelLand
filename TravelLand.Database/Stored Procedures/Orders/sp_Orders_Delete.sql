﻿CREATE PROCEDURE [dbo].[sp_Orders_Delete]
   @Id UNIQUEIDENTIFIER
AS
DELETE
FROM [Orders]
WHERE [Id] = @Id
