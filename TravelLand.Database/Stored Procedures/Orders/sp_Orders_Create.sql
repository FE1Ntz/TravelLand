CREATE PROCEDURE [dbo].[sp_Orders_Create]
    @Id UNIQUEIDENTIFIER,
	@TourId UNIQUEIDENTIFIER,
    @Username NVARCHAR(MAX),
    @IsPaid BIT,
    @PaymentDate DATETIME
AS 
    INSERT INTO [Orders] 
        ([Id],
		[TourId],
        [Username],
        [IsPaid],
        [PaymentDate]) 
    VALUES
        (@Id,
        @TourId,
        @Username,
		@IsPaid,
        @PaymentDate)
