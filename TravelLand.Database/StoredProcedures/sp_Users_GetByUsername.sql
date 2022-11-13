CREATE PROCEDURE [dbo].[sp_Users_GetByUsername]
    @Username NVARCHAR(MAX)
AS
SELECT*FROM [Users]
WHERE Users.Username = @Username