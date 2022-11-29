CREATE PROCEDURE [dbo].[sp_Tours_GetById]
    @Id UNIQUEIDENTIFIER
AS
    SELECT * FROM [Tours] WHERE [Id] = @Id