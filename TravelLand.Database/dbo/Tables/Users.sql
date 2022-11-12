CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Username]     NVARCHAR (MAX)   NOT NULL,
    [Firstname]    NVARCHAR (MAX)   NOT NULL,
    [Lastname]     NVARCHAR (MAX)   NOT NULL,
    [PasswordHash] NVARCHAR (MAX)   NOT NULL,
    [PasswordSalt] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

