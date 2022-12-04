CREATE PROCEDURE [dbo].[sp_Orders_GetById]
    @Id UNIQUEIDENTIFIER
AS
    SELECT * FROM [Orders] WHERE [Id] = @Id