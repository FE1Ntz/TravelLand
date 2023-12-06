CREATE PROCEDURE [dbo].[sp_Orders_GetUserHistoryByUserUsername]
	@Username NVARCHAR(MAX),
	@IsPaid BIT
AS
	SELECT Tours.Id, 
	Tours.Country, 
	Tours.[Description], 
	Tours.Duration, 
	Tours.EndDate, 
	Tours.IsHot, 
	Tours.Logo, 
	Tours.[Name], 
	Tours.PersonCount, 
	Tours.Price, 
	Tours.StartDate, 
	Tours.Town  
	
	From Tours
	INNER Join Orders ON Orders.TourId = Tours.Id AND Orders.IsPaid = @IsPaid AND Orders.Username = @Username
RETURN 0
