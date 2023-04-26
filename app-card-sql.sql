USE [master]
GO

-- Creación de las bases de datos
CREATE DATABASE BirthdayCards
GO

CREATE DATABASE ChristmasCards
GO

USE [BirthdayCards]
GO

-- Creación de la tabla Cards en BirthdayCards
CREATE TABLE Cards (
Id UNIQUEIDENTIFIER PRIMARY KEY,
Title NVARCHAR(50) NOT NULL,
Description NVARCHAR(255) NOT NULL,
UrlImage NVARCHAR(255) NULL
)
GO

-- Insertar algunos datos de prueba en la tabla Cards de BirthdayCards
INSERT INTO Cards (Id, Title, Description, UrlImage)
VALUES
(NEWID(), 'Happy Birthday!', 'Have a great day!', '/img/bird.jpg'),
(NEWID(), 'Another year older', 'But still fabulous!', '/img/bridge.jpg'),
(NEWID(), 'Blowing out the candles', 'Make a wish!', '/img/cliff.jpg'),
(NEWID(), 'Party time!', 'Let''s celebrate!', '/img/clothe.jpg')
GO

USE [ChristmasCards]
GO

-- Creación de la tabla Cards en ChristmasCards
CREATE TABLE Cards (
Id UNIQUEIDENTIFIER PRIMARY KEY,
Title NVARCHAR(50) NOT NULL,
Description NVARCHAR(255) NOT NULL,
UrlImage NVARCHAR(255) NULL
)
GO

-- Insertar algunos datos de prueba en la tabla Cards de ChristmasCards
INSERT INTO Cards (Id, Title, Description, UrlImage)
VALUES
(NEWID(), 'Merry Christmas!', 'Wishing you joy and happiness this holiday season', '/img/colibri.jpg'),
(NEWID(), 'Warmest wishes', 'May your Christmas be filled with love and laughter', '/img/orange.jpg'),
(NEWID(), 'For the children', 'Merry Christmas little ones!', '/img/ninos.jpg'),
(NEWID(), 'Deck the halls', 'And have yourself a merry little Christmas!', '/img/shopping.jpg')
GO
