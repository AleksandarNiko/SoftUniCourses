--02
Select*From Departments

--03
SELECT Name FROM Departments

--04
Select FirstName, LastName, Salary From Employees

--05
Select FirstName, MiddleName, LastName From Employees

--06
SELECT CONCAT(FirstName, '.', LastName, '@softuni.bg') AS email_address
FROM Employees

--07
SELECT DISTINCT Salary AS Salary
FROM Employees;

--08
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative';

--09
Select FirstName, LastName,JobTitle From Employees 
Where Salary between 20000 and 30000

--10
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS "Full Name"
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--11
Select FirstName, LastName
From Employees
Where ManagerID is null

--12
Select FirstName, LastName, Salary
From Employees 
Where Salary>50000 
Order by Salary Desc

--13
Select Top 5 FirstName,LastName 
From Employees
Order By Salary Desc

--14
Select FirstName, LastName
From Employees
Where DepartmentID != 4

--15
Select*From Employees
Order By Salary Desc,
         FirstName Asc,
         LastName Desc,
         MiddleName Asc
--16
Create view V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
From Employees

--17
Create view V_EmployeeNameJobTitle As
SELECT CONCAT(FirstName,' ',ISNULL(MiddleName, ''),' ',LastName) AS 'Full Name', JobTitle
From Employees

--18
SELECT DISTINCT JobTitle
From Employees

--19
SELECT TOP 10*
FROM Projects
ORDER BY StartDate,Name

--20
Select Top 7 FirstName, LastName, HireDate
From Employees
Order by HireDate Desc

--21
UPDATE
Employees
SET Salary = Salary * 1.12
WHERE DepartmentID IN (1, 2, 4, 11)
SELECT Salary FROM Employees

--22
Select PeakName From Peaks
Order By PeakName Asc

--23
SELECT TOP 30 CountryName, Population
FROM Countries
WHERE ContinentCode='EU'
  ORDER BY Population DESC, CountryName

--24
SELECT CountryName, CountryCode,
CASE 
WHEN CurrencyCode='EUR' THEN 'Euro'
  ELSE 'Not Euro'
    END AS Currency
FROM Countries
ORDER BY CountryName

--25
SELECT Name FROM Characters
Order By Name Asc