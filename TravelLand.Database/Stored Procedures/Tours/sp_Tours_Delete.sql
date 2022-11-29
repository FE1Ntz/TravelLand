CREATE PROCEDURE [dbo].[sp_Tours_Delete]
   @Id UNIQUEIDENTIFIER
AS
    DELETE FROM [Tours] WHERE [Id] = @Id