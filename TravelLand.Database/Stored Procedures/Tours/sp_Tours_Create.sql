CREATE PROCEDURE [dbo].[sp_Tours_Create]
    @Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(MAX),
    @Price INT,
    @Country NVARCHAR(MAX),
    @Town NVARCHAR(MAX),
    @PersonCount INT,
    @StartDate DATE,
    @EndDate Date,
    @Duration INT,
    @Description NVARCHAR(MAX)
AS 
    INSERT INTO [Tours] 
        ([Id],
		[Name], 
        [Price], 
		[Country],
        [Town],
		[PersonCount],
		[StartDate],
        [EndDate],
        [Duration],
        [Description]) 
    VALUES
        (@Id,
        @Name,
        @Price,
		@Country,
        @Town,
		@PersonCount, 
		@StartDate,
        @EndDate,
        @Duration,
        @Description)
