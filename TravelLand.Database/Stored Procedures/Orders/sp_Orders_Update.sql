CREATE PROCEDURE [dbo].[sp_Orders_Update]
	@Id UNIQUEIDENTIFIER,
	@TourId UNIQUEIDENTIFIER,
    @Username NVARCHAR(MAX),
    @IsPaid BIT,
    @PaymentDate DATETIME
   
AS
UPDATE [Orders]
SET
    [Id] = @Id, [TourId] = @TourId, [Username] = @Username, [IsPaid] = @IsPaid, [PaymentDate] = @PaymentDate
WHERE [Id] = @Id
