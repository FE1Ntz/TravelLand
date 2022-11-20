CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Username]     NVARCHAR (MAX)   NOT NULL,
    [FirstName]    NVARCHAR (MAX)   NOT NULL,
    [LastName]     NVARCHAR (MAX)   NOT NULL,
    [Role]         NVARCHAR (MAX)   NOT NULL,
    [PasswordHash] binary(64)   NOT NULL,
    [PasswordSalt] binary(128)  NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

