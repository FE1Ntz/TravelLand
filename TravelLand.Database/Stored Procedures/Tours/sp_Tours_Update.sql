CREATE PROCEDURE [dbo].[sp_Tours_Update]
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
     UPDATE [Tours] SET
          [Name] = @Name,
          [Price] = @Price,
          [Country] = @Country,
          [Town] = @Town,
          [PersonCount] = @PersonCount,
          [StartDate] = @StartDate,
          [EndDate] = @EndDate,
          [Duration] = @Duration,
          [Description] = @Description
     WHERE [Id] = @Id