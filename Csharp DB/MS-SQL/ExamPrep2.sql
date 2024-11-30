CREATE DATABASE RailwaysDb
USE RailwaysDb

--01
CREATE TABLE Passengers
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Trains
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
HourOfDeparture VARCHAR(5) NOT NULL,
HourOfArrival VARCHAR(5) NOT NULL,
DepartureTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
ArrivalTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE TrainsRailwayStations
(
TrainId INT NOT NULL,
RailwayStationId INT NOT NULL,
PRIMARY KEY (TrainId,RailwayStationId),
FOREIGN KEY (TrainId) REFERENCES Trains(Id),
FOREIGN KEY (RailwayStationId) REFERENCES RailwayStations(Id)
)

CREATE TABLE MaintenanceRecords
(
Id INT PRIMARY KEY IDENTITY,
DateOfMaintenance DATETIME2 NOT NULL,
Details VARCHAR(2000) NOT NULL,
TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
)

CREATE TABLE Tickets
(
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL(18,2) NOT NULL,
DateOfDeparture DATETIME2 NOT NULL,
DateOfArrival DATETIME2 NOT NULL,
TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

--02
INSERT INTO Trains(HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES ('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7), 
('10:15', '12:15', 15,5)

INSERT INTO TrainsRailwayStations(TrainId, RailwayStationId)
VALUES (36, 1),
(36, 4),
(36, 31),
(36, 57),
(36, 7),
(37,13),
(37,54),
(37,60),
(37,16),
(38,10),
(38,50),
(38,52),
(38,22),
(39,68),
(39,3),
(39,31),
(39,19),
(40,41),
(40,7),
(40,52),
(40,13)

INSERT INTO Tickets(Price,DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES (90.00, '2023-12-01', '2023-12-01', 36, 1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22)

--03
UPDATE Tickets
SET DateOfDeparture = DATEADD(day, 7, DateOfDeparture),
    DateOfArrival = DATEADD(day, 7, DateOfArrival)
WHERE DATEPART(MONTH,DateOfDeparture) > 10

--04
DELETE 
FROM TrainsRailwayStations
WHERE TrainId=7

DELETE 
FROM Tickets
WHERE TrainId=7

DELETE 
FROM MaintenanceRecords
WHERE TrainId=7

DELETE 
FROM Trains
WHERE DepartureTownId IN (SELECT Id FROM Towns WHERE [Name] = 'Berlin')

--05
SELECT DateOfDeparture, Price
FROM Tickets
ORDER BY Price ASC,DateOfDeparture DESC

--06
SELECT p.[Name], t.Price, DateOfDeparture, TrainID
FROM Tickets AS t
JOIN Passengers AS p ON p.Id=t.PassengerId
ORDER BY t.Price DESC, p.[Name]

--07
SELECT t.[Name] AS Town, rs.[Name] AS RailwayStation
FROM RailwayStations AS rs
JOIN Towns AS t ON rs.TownId =t.Id
WHERE rs.Id NOT IN 
(
SELECT RailwayStationId FROM TrainsRailwayStations)
ORDER BY t.[Name] ASC, rs.[Name] ASC

--08
SELECT TOP 3 tr.Id AS TrainId,tr.HourOfDeparture,t.Price AS TicketsPrice,ts.[Name] AS Destination
FROM Trains AS tr
JOIN Towns AS ts ON tr.ArrivalTownId=ts.Id
JOIN Tickets AS t ON tr.Id =t.TrainId
WHERE  CAST (tr.HourOfDeparture AS TIME) BETWEEN '8:00' AND '08:50' AND t.Price>50
ORDER BY t.Price ASC

--09
SELECT ts.[Name] AS TownName, COUNT(p.Id) AS PassengersCount
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId=p.Id
JOIN Trains As tr ON t.TrainId=tr.Id
JOIN Towns AS ts ON tr.ArrivalTownId=ts.Id
WHERE t.Price > 76.99
GROUP BY ts.[Name]
ORDER BY ts.[Name] ASC

--10
SELECT tr.Id AS TrainID,t.[Name] AS DepartureTown,Details
FROM Trains AS tr
JOIN Towns As t ON t.Id=tr.DepartureTownId 
JOIN MaintenanceRecords AS mr  ON mr.TrainId =tr.Id
WHERE mr.Details LIKE '%inspection%'
ORDER BY tr.Id ASC

--11
CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(50))
RETURNS INT
AS 
BEGIN
DECLARE @totalCount INT
SELECT @totalCount = COUNT(tr.Id)
FROM Trains AS tr
JOIN Towns AS t ON tr.ArrivalTownId=t.Id 
JOIN Towns AS ts ON tr.DepartureTownId=ts.Id 
WHERE t.[Name]=@name OR ts.[Name]=@name
RETURN @totalCount
END

--12
CREATE PROC usp_SearchByTown(@townName VARCHAR(50))
AS
BEGIN
SELECT p.[Name] AS PassengerName, ts.DateOfDeparture AS DateOfDeparture, tr.HourOfDeparture AS HourOfDeparture
FROM Passengers AS p
JOIN Tickets AS ts ON p.Id= ts.PassengerId
JOIN Trains AS tr ON ts.TrainId =tr.Id
JOIN Towns AS t ON t.Id = tr.ArrivalTownId
WHERE t.[Name]=@townName
ORDER BY DateOfDeparture DESC, PassengerName ASC
END
