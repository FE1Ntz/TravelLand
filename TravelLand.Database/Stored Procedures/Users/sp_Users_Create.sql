CREATE PROCEDURE [dbo].[sp_Users_Create]
    @Id UNIQUEIDENTIFIER,
	@Username NVARCHAR(MAX),
    @FirstName NVARCHAR(MAX),
    @LastName NVARCHAR(MAX),
    @Role NVARCHAR(MAX),
	@PasswordHash binary(64),
	@PasswordSalt binary(128)
AS 
    INSERT INTO [Users] 
        ([Id],
		[FirstName], 
        [LastName], 
		[Username],
        [Role],
		[PasswordHash] ,
		[PasswordSalt]) 
    VALUES
        (@Id,
        @FirstName,
        @LastName,
		@Username,
        @Role,
		@PasswordHash, 
		@PasswordSalt)
