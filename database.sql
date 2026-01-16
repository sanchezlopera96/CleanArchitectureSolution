CREATE DATABASE OrderDb;
GO

USE OrderDb;
GO

CREATE TABLE Customers (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL
);
GO

CREATE TABLE Orders (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    CustomerId UNIQUEIDENTIFIER NOT NULL,
    Description NVARCHAR(200) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    IsCanceled BIT NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),

    CONSTRAINT FK_Orders_Customers
        FOREIGN KEY (CustomerId)
        REFERENCES Customers(Id)
        ON DELETE CASCADE
);
GO

CREATE INDEX IX_Orders_CustomerId
ON Orders(CustomerId);
GO

INSERT INTO Customers (Id, Name, Email)
VALUES (
    NEWID(),
    'Santiago',
    'santiago@test.com'
);

DECLARE @CustomerId UNIQUEIDENTIFIER;

SELECT TOP 1 @CustomerId = Id FROM Customers;

INSERT INTO Orders (Id, CustomerId, Description, Amount, IsCanceled)
VALUES (
    NEWID(),
    @CustomerId,
    'Compra de Laptop',
    3000.00,
    0
);

SELECT * FROM Customers;
SELECT * FROM Orders;

