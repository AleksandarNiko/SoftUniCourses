USE SoftUni
GO

--01
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT e.FirstName,e.LastName
FROM Employees AS e
WHERE e.Salary>35000
GO

--02
CREATE PROC usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
AS 
SELECT e.FirstName,e.LastName
FROM Employees AS e
WHERE e.Salary>=@Number
GO

--03
CREATE PROC usp_GetTownsStartingWith @Letter VARCHAR(10)
AS
SELECT t.[Name]
FROM Towns AS t
WHERE t.Name LIKE @Letter +'%'
GO

--04
CREATE PROC usp_GetEmployeesFromTown @TownName VARCHAR(50)
AS
SELECT e.FirstName,e.LastName
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID=a.AddressID
JOIN Towns AS t ON a.TownID=t.TownID
WHERE @TownName=t.[Name]
GO

--05
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @salaryLevel VARCHAR(10)
IF(@salary < 30000)
SET @salaryLevel='Low'
ELSE IF (@salary BETWEEN 30000 AND 50000)
SET @salaryLevel='Average'
ELSE
SET @salaryLevel='High'
 RETURN @salaryLevel
END
GO

--06
CREATE PROC usp_EmployeesBySalaryLevel @LevelOfSalary VARCHAR(10)
AS
SELECT 
FirstName AS [First Name],
LastName AS [Last Name]
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary)=@LevelOfSalary
GO

--07
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(40), @word VARCHAR (40))
RETURNS BIT
AS
BEGIN
 DECLARE @wordIndex INT = 1
  WHILE (@wordIndex<=LEN(@word))
  BEGIN
  DECLARE @curChar CHAR =SUBSTRING(@word,@wordIndex,1)
  IF(CHARINDEX(@curChar,@setOfLetters)=0)
  RETURN 0
  ELSE
  SET @wordIndex+=1
  END
    RETURN 1
END
GO

--08
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE 
FROM EmployeesProjects
WHERE EmployeeID IN
(
SELECT EmployeeID
FROM Employees
WHERE DepartmentID=@departmentId
)

UPDATE Employees
SET ManagerID =NULL
WHERE ManagerID IN
(
SELECT EmployeeID
FROM Employees
WHERE DepartmentID =@departmentId
)

    UPDATE Departments
	   SET ManagerID = NULL
	 WHERE DepartmentID = @departmentId

    DELETE 
	FROM Employees 
	WHERE DepartmentId = @departmentId

    DELETE 
	FROM Departments 
	WHERE DepartmentId = @departmentId

    SELECT COUNT(*) AS NumberOfEmployees 
	FROM Employees 
	WHERE DepartmentId = @departmentId
END
GO

USE Bank
GO
--09
CREATE PROC usp_GetHoldersFullName
AS
SELECT CONCAT(FirstName,' ',LastName)
FROM AccountHolders
GO

--10
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Number DECIMAL(18,4))
AS
SELECT ah.FirstName,ah.LastName
FROM AccountHolders AS ah

JOIN (
		SELECT AccountHolderId,
		SUM(Balance) AS TotalMoney
        FROM Accounts
		GROUP BY AccountHolderId
	) 
	AS ac ON ah.Id = ac.AccountHolderId
WHERE ac.TotalMoney>@Number
ORDER BY ah.FirstName,ah.LastName
GO

--11
CREATE FUNCTION ufn_CalculateFutureValue (@sum decimal(18,4), @YearlyInterestRate float, @NumberOfYears int)
RETURNS DECIMAL(18,4)
AS
BEGIN
    RETURN @sum * POWER(1 + @YearlyInterestRate, @NumberOfYears)
	END
GO

--12
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT,@annualRate FLOAT)
AS
SELECT
ac.Id AS [Account Id],
ah.FirstName AS [First Name],
ah.LastName AS [Last Name],
ac.Balance AS [Current Balance],
dbo.ufn_CalculateFutureValue(ac.Balance,@annualRate,5)
AS [Balance in 5 years]
FROM Accounts as ac
JOIN AccountHolders AS ah ON ac.Id =ah.Id
WHERE ac.Id=@accountId
GO

USE Diablo
GO
--13
CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(50))
RETURNS TABLE
AS
RETURN
(
SELECT SUM(Cash)
AS [SumCash]
FROM 
(
SELECT g.[Name],
ug.Cash,
ROW_NUMBER() OVER(ORDER BY ug.Cash DESC)
AS [RowNumber]
FROM UsersGames
AS ug
JOIN Games
AS g
ON ug.GameId = g.Id
WHERE g.[Name] = @gameName
) 
AS [RankingSubQuery]
WHERE RowNumber % 2 <> 0
)