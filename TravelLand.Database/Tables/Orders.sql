CREATE TABLE [dbo].[Orders]
(
    [Id]
    UNIQUEIDENTIFIER
    NOT
    NULL
    PRIMARY
    KEY, [TourId]
    UNIQUEIDENTIFIER
    NOT
    NULL, [Username]
    NVARCHAR
(
    MAX
) NOT NULL,
    [IsPaid] BIT NOT NULL,
    [PaymentDate] DATETIME NOT NULL
    )
