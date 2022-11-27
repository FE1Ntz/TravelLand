CREATE PROCEDURE [dbo].[sp_Users_Update]
	@Id UNIQUEIDENTIFIER,
	@Username NVARCHAR(MAX),
    @FirstName NVARCHAR(MAX),
    @LastName NVARCHAR(MAX),
    @Role NVARCHAR(MAX),
	@PasswordHash binary(64),
	@PasswordSalt binary(128)
AS
    UPDATE [Users] Set
         [FirstName] = @FirstName,
         [LastName] = @LastName
WHERE [Id] = @Id