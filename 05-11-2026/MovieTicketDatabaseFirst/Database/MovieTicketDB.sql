IF DB_ID('MovieTicketDB') IS NULL
    CREATE DATABASE MovieTicketDB;
GO

USE MovieTicketDB;
GO

IF OBJECT_ID('dbo.Movies', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Movies
    (
        Id              INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Movies PRIMARY KEY,
        Title           NVARCHAR(200)  NOT NULL CONSTRAINT CK_Movies_Title CHECK (LEN(Title) >= 2),
        BasePrice       DECIMAL(18,2)  NOT NULL CONSTRAINT CK_Movies_BasePrice CHECK (BasePrice >= 0),
        DurationMinutes INT            NOT NULL CONSTRAINT CK_Movies_Duration CHECK (DurationMinutes BETWEEN 30 AND 300),
        Genre           NVARCHAR(100)  NULL
    );

    CREATE TABLE dbo.Tickets
    (
        Id            INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Tickets PRIMARY KEY,
        ShowDate      DATETIME       NOT NULL,
        CustomerName  NVARCHAR(100)  NOT NULL CONSTRAINT CK_Tickets_Name CHECK (LEN(CustomerName) >= 3),
        CustomerPhone NVARCHAR(15)   NOT NULL,
        MovieId       INT            NOT NULL CONSTRAINT FK_Tickets_Movies REFERENCES dbo.Movies(Id),
        SeatQuantity  INT            NOT NULL CONSTRAINT CK_Tickets_Seat CHECK (SeatQuantity BETWEEN 1 AND 10)
    );

    INSERT INTO dbo.Movies (Title, BasePrice, DurationMinutes, Genre) VALUES
    (N'Mai',              90000, 131, N'Tâm lý'),
    (N'Avengers: Endgame', 120000, 181, N'Hành động'),
    (N'Inside Out 2',     100000, 96,  N'Hoạt hình');
END
GO
