﻿CREATE DATABASE TouristAgency
USE TouristAgency

--01
CREATE TABLE Countries
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Rooms
(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(40) NOT NULL,
Price DECIMAL(18,2) NOT NULL,
BedCount INT NOT NULL
CHECK(BedCount BETWEEN 0 AND 10)
)

CREATE TABLE Hotels
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
DestinationId INT FOREIGN KEY REFERENCES Destinations(Id) NOT NULL
)

CREATE TABLE Tourists
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(80) NOT NULL,
[PhoneNumber] VARCHAR(20) NOT NULL,
Email VARCHAR(80) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Bookings
(
Id INT PRIMARY KEY IDENTITY,
ArrivalDate DATETIME2 NOT NULL,
DepartureDate DATETIME2 NOT NULL,
AdultsCount INT NOT NULL
CHECK(AdultsCount BETWEEN 1 AND 10),
ChildrenCount INT NOT NULL
CHECK(ChildrenCount BETWEEN 0 AND 9),
TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
)

CREATE TABLE HotelsRooms
(
HotelId INT NOT NULL,
RoomId INT NOT NULL,
CONSTRAINT PK_HotelRooms PRIMARY KEY(HotelId,RoomId),
CONSTRAINT FK_HotelRooms_Hotels FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
CONSTRAINT FK_HotelRooms_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(Id),
)

--02
INSERT INTO Tourists([Name],PhoneNumber,Email,CountryId)
VALUES('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO Bookings(ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
('2023-11-15', '2023-11-20',1, 2, 23, 19, 7),
('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)

--03
UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1,DepartureDate)
WHERE ArrivalDate BETWEEN '2023-12-01' AND '2023-12-31'

UPDATE Tourists
SET Email = NULL
WHERE [Name] LIKE '%MA%'

--04
DECLARE @TouristsToDatele TABLE (Id INT)

INSERT INTO @TouristsToDatele(Id)
SELECT Id
FROM Tourists 
WHERE [Name] LIKE '%Smith%'

DELETE FROM Bookings
WHERE TouristId IN (SELECT Id FROM @TouristsToDatele) 

DELETE FROM Tourists 
WHERE Id IN (SELECT Id FROM @TouristsToDatele) 

--05
SELECT FORMAT (b.ArrivalDate,'yyyy-MM-dd') AS ArrivalDate,b.AdultsCount,b.ChildrenCount 
FROM Bookings AS b
JOIN Rooms AS r ON b.RoomId=r.Id
ORDER BY Price DESC,ArrivalDate ASC

--06
SELECT h.Id,h.[Name] FROM Hotels AS h
JOIN HotelsRooms AS hr ON h.Id=hr.HotelId
JOIN Rooms AS r ON hr.RoomId =r.Id 
JOIN Bookings AS b ON h.Id=b.HotelId
AND r.Type='VIP Apartment'
GROUP BY h.Id,h.[Name]
ORDER BY COUNT(*) DESC

--07
SELECT t.Id,t.[Name],t.PhoneNumber
FROM Tourists AS t
WHERE Id NOT IN (SELECT TouristId FROM Bookings) 
ORDER BY t.[Name] ASC

--08
SELECT TOP 10 h.[Name] AS HotelName, d.[Name] AS DestinationName,c.[Name] AS CountryName
FROM Bookings AS b
JOIN Hotels AS h ON b.HotelId=h.Id
JOIN Destinations AS d ON d.Id =h.DestinationId
JOIN Countries AS c ON c.Id=d.CountryId
WHERE ArrivalDate<'2023-12-31' AND h.Id%2!=0
ORDER BY c.[Name],ArrivalDate

--09
SELECT h.[Name] AS HotelName, r.Price AS RoomPrice
FROM Tourists AS t
JOIN Bookings AS b ON b.TouristId=t.Id
JOIN Rooms AS r ON r.Id=b.RoomId
JOIN Hotels AS h ON h.Id=b.HotelId
WHERE t.[Name] NOT LIKE '%EZ'
ORDER BY Price DESC

--10
SELECT h.[Name] AS HotelName, SUM(r.Price * DATEDIFF(day, b.ArrivalDate, b.DepartureDate)) AS HotelRevenue
FROM Bookings b
JOIN Hotels h ON b.HotelId = h.Id
JOIN Rooms r ON b.RoomId = r.Id
GROUP BY h.[Name]
ORDER BY HotelRevenue DESC

--11
CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(50))
RETURNS INT
AS
BEGIN
DECLARE @totalTourists INT
SELECT @totalTourists = SUM(AdultsCount + ChildrenCount)
    FROM Bookings AS b
	JOIN Rooms AS r ON b.RoomId=r.Id
    WHERE r.[Type] = @name;
RETURN @totalTourists
END
GO

--12
CREATE PROC usp_SearchByCountry(@country VARCHAR(50))
AS
BEGIN
    SELECT t.[Name], t.PhoneNumber, t.Email, COUNT(b.Id) AS CountOfBookings
    FROM Tourists AS t
	JOIN Bookings AS b ON b.TouristId=t.Id
	JOIN Countries AS c ON t.CountryId=c.Id
    WHERE c.[Name] = @country
    GROUP BY t.[Name], t.PhoneNumber, t.Email
    ORDER BY t.[Name] ASC, CountOfBookings DESC
END