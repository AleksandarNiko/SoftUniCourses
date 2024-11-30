--04
Insert into Towns
Values(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')


Insert into Minions (Id,[Name],Age,TownId)
Values (1,'Kevin',22,1),
       (2,'Bob',15,3),
	   (3,'Steward',NULL,2)
Select*From Towns

--07
Create Table People
(
Id int primary key identity,
[Name] NVARCHAR(200) NOT NULL, 
Picture VARBINARY(MAX),
Height decimal(3,2),
[Weight] decimal (5,2),
Gender char(1) NOT NULL
Check (Gender in ('m','f')),
Birthdate DATETIME2 NOT NULL,
Biography VARCHAR(max)
)

Insert into People([Name],Gender,Birthdate)
Values('Pesho','m','1999-06-06'),
      ('Gosho','m','1989-06-06'),
	  ('Amanda','f','1999-03-06'),
	  ('Joro','m','1979-06-06'),
	  ('Ivan','m','1999-06-09')

--08
Create Table Users
(
Id bigint primary key identity,
Username varchar(30) not null,
[Password] varchar(26) not null,
Picture varbinary(max),
LastLoginTime datetime2,
IsDeleted bit
Check (IsDeleted in ('true','false'))
)

Insert into Users(Username,[Password],IsDeleted)
Values('Pesho','peshoLudia','true'),
      ('Gosho','goshife','false'),
	  ('Amanda','creivnewv','true'),
	  ('Joro','cwijn','false'),
	  ('Ivan','c937rvs','false')

--13
CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY
	,DirectorName VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY
	,GenreName VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY
	,CategoryName VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY
	,Title VARCHAR(50) NOT NULL
	,DirectorId INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL
	,CopyrightYear INT NOT NULL
	,Length TIME NOT NULL
	,GenreId INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
	,Rating DECIMAL(2, 1) NOT NULL
	,Notes NVARCHAR(1000)
)

INSERT INTO Directors VALUES
	('Stanley Kubrick', NULL)
	,('Alfred Hitchcock', NULL)
	,('Quentin Tarantino', NULL)
	,('Steven Spielberg', NULL)
	,('Martin Scorsese', NULL)

INSERT INTO Genres VALUES
	('Action', NULL)
	,('Comedy', NULL)
	,('Drama', NULL)
	,('Fantasy', NULL)
	,('Horror', NULL)

INSERT INTO Categories VALUES
	('Short', NULL)
	,('Long', NULL)
	,('Biography', NULL)
	,('Documentary', NULL)
	,('TV', NULL)

INSERT INTO Movies VALUES
	('The Shawshank Redemption', 1, 1994, '02:22:00', 2, 3, 9.4, NULL)
	,('The Godfather', 2, 1972, '02:55:00', 3, 4, 9.2, NULL)
	,('Schindler`s List', 3, 1993, '03:15:00', 4, 5, 9.0, NULL)
	,('Pulp Fiction', 4, 1994, '02:34:00', 5, 1, 8.9, NULL)
	,('Fight Club', 5, 1999, '02:19:00', 1, 2, 8.8, NULL)

--14
Create table Categories
(
Id int primary key identity,
CategoryName VARCHAR(50),
DailyRate decimal(6,2),
WeeklyRate decimal (6,2),
MonthlyRate decimal(6,2),
WeekendRate decimal (6,2)
)

Create table Cars
(
Id int primary key identity,
PlateNumber varchar(30),
Manufacturer varchar(50),
Model varchar(50),
CarYear int,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors int,
Picture image,
Condition NVARCHAR(1000), 
Available bit
)

Create table Employees
(
Id int primary key identity,
FirstName varchar(30), 
LastName varchar(30),
Title varchar(30),
Notes nvarchar(1000)
)

Create table Customers 
(
Id int primary key identity, 
DriverLicenceNumber int, 
FullName varchar (50),
[Address] varchar(50),
City varchar(50), 
ZIPCode int,
Notes nvarchar(1000)
)

Create table RentalOrders 
(
Id int primary key identity, 
EmployeeId INT FOREIGN KEY REFERENCES [Employees](Id), 
CustomerId INT FOREIGN KEY REFERENCES [Customers](Id),
CarId INT FOREIGN KEY REFERENCES [Cars](Id),
TankLevel int,
KilometrageStart int,
KilometrageEnd int,
TotalKilometrage int,
StartDate date,
EndDate date,
TotalDays int, 
RateApplied decimal(6,2),
TaxRate decimal (6,2), 
OrderStatus varchar(50),
Notes nvarchar(1000)
)

INSERT INTO Categories 
VALUES
	('First category name', 10.00, 50.00, 150.00, 20.00),
	('Second category name', 50.00, 250.00, 750.00, 100.00),
	('Third category name', 100.00, 500.00, 1500.00, 200.00)

INSERT INTO Cars 
VALUES
	('PLN 0001', 'Ford', 'Model A', 1994, 1, 4, NULL, 'Good', 1),
	('PLN 0002', 'Tesla', 'Model B', 2021, 2, 4, NULL, 'Great', 1),
	('PLN 0003', 'Capsule Corp', 'Model C', 2054, 3, 10, NULL, 'Best', 0)

INSERT INTO Employees VALUES
	('Tyler', 'Durden', 'Edward Norton`s Alter Ego', NULL),
	('Plain', 'Jane', 'some gal', NULL),
	('Average', 'Joe', 'some dude', NULL)

INSERT INTO Customers 
VALUES
	('123456', 'Jimmy Carr', 'Britain', 'London', 1000, NULL),
	('654321', 'Bill Burr', 'USA', 'Washington', 2000, NULL),
	('999999', 'Louis CK', 'Mexico', 'Mexico City', 3000, NULL)

INSERT INTO RentalOrders 
VALUES
	(1, 1, 1, 70, 90000, 100000, 10000, '1994-10-01', '1994-10-21', 20, 100.00, 14.00, 'Pending', NULL),
	(2, 2, 2, 85, 250000, 2750000, 25000, '2011-11-12', '2011-11-24', 12, 150.00, 17.50, 'Canceled', NULL),
	(3, 3, 3, 90, 0, 120000, 120000, '2025-04-05', '2025-05-02', 27, 220.00, 21.25, 'Delivered', NULL)

--15
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY
	,FirstName VARCHAR(50) NOT NULL
	,LastName VARCHAR(50) NOT NULL
	,Title VARCHAR(50) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY
	,FirstName VARCHAR(50) NOT NULL
	,LastName VARCHAR(50) NOT NULL
	,PhoneNumber INT NOT NULL
	,EmergencyName VARCHAR(50)
	,EmergencyNumber INT
	,Notes NVARCHAR(1000)
)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(50) PRIMARY KEY NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(50) PRIMARY KEY NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE BedTypes
(
	BedType VARCHAR(50) PRIMARY KEY NOT NULL
	,Notes NVARCHAR(1000)
)


CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY IDENTITY
	,RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL
	,BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL
	,Rate DECIMAL(5,2) NOT NULL
	,RoomStatus VARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY
	,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
	,PaymentDate DATE NOT NULL
	,AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
	,FirstDateOccupied DATE NOT NULL
	,LastDateOccupied DATE NOT NULL
	,TotalDays INT NOT NULL
	,AmountCharged DECIMAL(6, 2) NOT NULL
	,TaxRate DECIMAL(4, 2) NOT NULL
	,TaxAmount DECIMAL(6, 2) NOT NULL
	,PaymentTotal DECIMAL(6, 2) NOT NULL
	,Notes NVARCHAR(1000)
)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY
	,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
	,DateOccupied DATE NOT NULL
	,AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
	,RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL
	,RateApplied DECIMAL(4, 2) NOT NULL
	,PhoneCharge DECIMAL(4, 2) NOT NULL
	,Notes NVARCHAR(1000)
)

INSERT INTO Employees VALUES
	('Jim', 'McJim', 'Supervisor', NULL)
	,('Jane', 'McJane', 'Cook', NULL)
	,('John', 'McJohn', 'Waiter', NULL)

INSERT INTO [Customers] VALUES
	('Mickey', 'Mouse', 12345678, 'Minnie', 11111111, NULL)
	,('Donald', 'Duck', 87654321, 'Daisy', 22222222, NULL)
	,('Scrooge', 'McDuck', 9999999, 'Richie', 33333333, NULL)

INSERT INTO [RoomStatus] VALUES
	('Free', NULL)
	,('Occupied', NULL)
	,('No idea', NULL)

INSERT INTO [RoomTypes] VALUES
	('Room', NULL)
	,('Studio', NULL)
	,('Apartment', NULL)

INSERT INTO [BedTypes] VALUES
	('Big', NULL)
	,('Small', NULL)
	,('Child', NULL)

INSERT INTO [Rooms] VALUES
	('Room', 'Big', 15.00, 'Free', NULL)
	,('Studio', 'Small', 12.50, 'Occupied', NULL)
	,('Apartment', 'Child', 10.25, 'No idea', NULL)

INSERT INTO [Payments] VALUES
	(1, '2023-02-01', 1, '2023-01-11', '2023-01-14', 3, 250.00, 20.00, 50.00, 300.00, NULL)
	,(2, '2023-02-02', 2, '2023-01-12', '2023-01-15', 3, 199.90, 20.00, 39.98, 239.88, NULL)
	,(3, '2023-02-03', 3, '2023-01-13', '2023-01-16', 3, 330.50, 20.00, 66.10, 396.60, NULL)

INSERT INTO [Occupancies] VALUES
	(1, '2023-01-01', 1, 1, 20.00, 15.00, NULL)
	,(2, '2023-01-02', 2, 2, 20.00, 12.50, NULL)
	,(3, '2023-01-03', 3, 3, 20.00, 18.90, NULL)

--19
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--20
Select * From Towns 
        Order By Name
Select * from Departments
         Order by Name
Select * from Employees
         Order by Salary desc

--21
Select [Name] From Towns Order by Name
Select [Name] From Departments Order by Name
Select FirstName,LastName,JobTitle,Salary From Employees Order by Salary desc

--22
Update Employees
 Set Salary *=1.1

 Select Salary from Employees

 --23
  Update Payments 
     Set TaxRate-=0.03
 Select TaxRate From Payments

 --24
  Delete Occupancies