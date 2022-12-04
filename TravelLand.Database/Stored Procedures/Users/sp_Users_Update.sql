CREATE PROCEDURE [dbo].[sp_Users_Update] @Id UNIQUEIDENTIFIER,
                                         @Username NVARCHAR(MAX),
                                         @FirstName NVARCHAR(MAX),
                                         @LastName NVARCHAR(MAX),
                                         @Role NVARCHAR(MAX),
                                         @PasswordHash binary(64),
                                         @PasswordSalt binary(128),
                                         @PhoneNumber NVARCHAR(MAX),
                                         @EmailAddress NVARCHAR(MAX)
AS
UPDATE [Users]
Set [FirstName]    = @FirstName,
    [LastName]     = @LastName,
    [PhoneNumber]  = @PhoneNumber,
    [EmailAddress] = @EmailAddress
WHERE [Id] = @Id