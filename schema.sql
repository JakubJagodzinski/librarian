CREATE TABLE [Authors] (
    [AuthorId] int NOT NULL IDENTITY,
    [AuthorFullName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([AuthorId])
);
GO


CREATE TABLE [Employees] (
    [EmployeeId] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [HireDate] datetime2 NOT NULL,
    [TerminationDate] datetime2 NULL,
    [Photo] varbinary(max) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId])
);
GO


CREATE TABLE [Genres] (
    [GenreId] int NOT NULL IDENTITY,
    [GenreName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([GenreId])
);
GO


CREATE TABLE [Readers] (
    [ReaderId] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Photo] varbinary(max) NULL,
    CONSTRAINT [PK_Readers] PRIMARY KEY ([ReaderId])
);
GO


CREATE TABLE [Books] (
    [BookId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [AuthorId] int NOT NULL,
    [PublishedYear] int NOT NULL,
    [Pages] int NOT NULL,
    [InStock] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId]),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([AuthorId]) ON DELETE CASCADE
);
GO


CREATE TABLE [BlacklistedReaders] (
    [BlacklistedReaderId] int NOT NULL IDENTITY,
    [ReaderId] int NOT NULL,
    [Reason] nvarchar(max) NOT NULL,
    [BlacklistedDate] datetime2 NOT NULL,
    [RemovalDate] datetime2 NULL,
    CONSTRAINT [PK_BlacklistedReaders] PRIMARY KEY ([BlacklistedReaderId]),
    CONSTRAINT [FK_BlacklistedReaders_Readers_ReaderId] FOREIGN KEY ([ReaderId]) REFERENCES [Readers] ([ReaderId]) ON DELETE CASCADE
);
GO


CREATE TABLE [UserCredentials] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [ReaderId] int NULL,
    [EmployeeId] int NULL,
    CONSTRAINT [PK_UserCredentials] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserCredentials_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeId]),
    CONSTRAINT [FK_UserCredentials_Readers_ReaderId] FOREIGN KEY ([ReaderId]) REFERENCES [Readers] ([ReaderId])
);
GO


CREATE TABLE [BookGenres] (
    [BookId] int NOT NULL,
    [GenreId] int NOT NULL,
    CONSTRAINT [PK_BookGenres] PRIMARY KEY ([BookId], [GenreId]),
    CONSTRAINT [FK_BookGenres_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([BookId]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookGenres_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([GenreId]) ON DELETE CASCADE
);
GO


CREATE TABLE [Rentals] (
    [RentalId] int NOT NULL IDENTITY,
    [ReaderId] int NOT NULL,
    [BookId] int NOT NULL,
    [RentalDate] datetime2 NOT NULL,
    [PlannedReturnDate] datetime2 NOT NULL,
    [ReturnDate] datetime2 NULL,
    CONSTRAINT [PK_Rentals] PRIMARY KEY ([RentalId]),
    CONSTRAINT [FK_Rentals_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([BookId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rentals_Readers_ReaderId] FOREIGN KEY ([ReaderId]) REFERENCES [Readers] ([ReaderId]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_BlacklistedReaders_ReaderId] ON [BlacklistedReaders] ([ReaderId]);
GO


CREATE INDEX [IX_BookGenres_GenreId] ON [BookGenres] ([GenreId]);
GO


CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
GO


CREATE INDEX [IX_Rentals_BookId] ON [Rentals] ([BookId]);
GO


CREATE INDEX [IX_Rentals_ReaderId] ON [Rentals] ([ReaderId]);
GO


CREATE UNIQUE INDEX [IX_UserCredentials_EmployeeId] ON [UserCredentials] ([EmployeeId]) WHERE [EmployeeId] IS NOT NULL;
GO


CREATE UNIQUE INDEX [IX_UserCredentials_ReaderId] ON [UserCredentials] ([ReaderId]) WHERE [ReaderId] IS NOT NULL;
GO


