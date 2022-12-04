CREATE PROCEDURE [dbo].[sp_Users_Create]
    @Id UNIQUEIDENTIFIER,
	@Username NVARCHAR(MAX),
    @FirstName NVARCHAR(MAX),
    @LastName NVARCHAR(MAX),
    @Role NVARCHAR(MAX),
	@PasswordHash binary(64),
	@PasswordSalt binary(128),
    @PhoneNumber NVARCHAR(MAX),
    @EmailAddress NVARCHAR(MAX)
AS 
    INSERT INTO [Users] 
        ([Id],
		[FirstName], 
        [LastName], 
		[Username],
        [Role],
		[PasswordHash],
		[PasswordSalt],
        [PhoneNumber],
        [EmailAddress]) 
    VALUES
        (@Id,
        @FirstName,
        @LastName,
		@Username,
        @Role,
		@PasswordHash, 
		@PasswordSalt,
        @PhoneNumber,
        @EmailAddress)
