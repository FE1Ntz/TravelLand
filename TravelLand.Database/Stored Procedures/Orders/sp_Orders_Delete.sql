CREATE PROCEDURE [dbo].[sp_Orders_Delete]
   @TourId UNIQUEIDENTIFIER,
   @Username NVARCHAR(MAX),
   @IsPaid BIT
AS
DELETE
FROM [Orders]
WHERE [TourId] = @TourId AND [Username] = @Username AND [IsPaid] =  @IsPaid 
