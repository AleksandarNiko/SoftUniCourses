--01
SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, AddressText 
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY AddressID

--02
SELECT TOP 50 e.FirstName,e.LastName,t.Name,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID=e.AddressID
JOIN Towns AS t ON a.TownID=t.TownID
ORDER BY FirstName,LastName

--03
SELECT EmployeeID, FirstName,LastName,[Name]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
WHERE [Name]='Sales'
ORDER BY EmployeeID ASC

--04
SELECT TOP 5 EmployeeID, FirstName,Salary, [Name]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
WHERE e.Salary>15000
  ORDER BY d.DepartmentID ASC

--05
SELECT TOP 3 EmployeeID, FirstName
FROM Employees
WHERE EmployeeID NOT IN (SELECT DISTINCT EmployeeID FROM EmployeesProjects)

--06
SELECT e.FirstName,e.LastName,e.HireDate,d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID
WHERE e.HireDate > '1-1-1999' AND d.[Name] IN ('Sales','Finance')
  ORDER BY e.HireDate ASC

--07
SELECT TOP 5 e.EmployeeID,e.FirstName,[Name] AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID=e.EmployeeID
JOIN Projects AS p ON ep.ProjectID =p.ProjectID
WHERE StartDate> '2002-08-13' AND EndDate IS NULL
ORDER BY e.EmployeeID

--08
SELECT TOP 5 e.EmployeeID,e.FirstName,[Project Name] =
CASE
	WHEN DATEPART(YEAR, StartDate) > 2004 THEN NULL
	ELSE [Name]
END
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID=e.EmployeeID
JOIN Projects AS p ON ep.ProjectID =p.ProjectID
WHERE e.EmployeeID=24

--09
SELECT e.EmployeeID, e.FirstName,m.EmployeeID,m.FirstName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID=m.EmployeeID
WHERE e.ManagerID IN (3,7)
  ORDER BY e.EmployeeID ASC

--10
SELECT TOP 50 e.EmployeeID,
 CONCAT_WS(' ',e.FirstName,e.LastName) AS EmployeeName,
CONCAT_WS(' ',m.FirstName,m.LastName) AS ManagerName,
d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID=m.EmployeeID
JOIN Departments AS d ON d.DepartmentID=e.DepartmentID
ORDER BY e.EmployeeID ASC

--11
SELECT TOP 1 AVG(Salary) MinAvarageSalary
FROM Employees 
GROUP BY DepartmentID
ORDER BY MinAvarageSalary

--12
SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation
FROM MountainsCountries AS mc
JOIN Countries AS c ON c.CountryCode=mc.CountryCode
JOIN Mountains AS m ON m.ID=mc.MountainID
JOIN Peaks AS p ON p.MountainID=m.ID
WHERE c.CountryName='Bulgaria' AND p.Elevation>2835
  ORDER BY p.Elevation DESC

--13
SELECT CountryCode,COUNT(MountainID) AS MountainRanges
FROM MountainsCountries WHERE CountryCode IN
(
SELECT CountryCode 
FROM Countries
WHERE CountryName IN ('United States','Russia','Bulgaria')
)
GROUP BY CountryCode

--14
SELECT TOP 5 c.CountryName,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode=c.CountryCode
LEFT JOIN Rivers AS r ON r.ID=cr.RiverID
WHERE c.ContinentCode =
(
SELECT ContinentCode 
FROM Continents
WHERE ContinentName='Africa'
)
  ORDER BY c.CountryName

--16
SELECT COUNT(c.CountryCode) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode =c.CountryCode
WHERE mc.MountainId IS NULL

--17
SELECT TOP 5 c.CountryName,MAX(p.Elevation)
AS [HighestPeakElevation],
MAX(r.[Length]) 
AS [LongestRiverLength]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
LEFT JOIN Mountains AS m ON m.ID=mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId =m.Id
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode=c.CountryCode
LEFT JOIN Rivers AS r ON r.Id=cr.RiverId
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.CountryName ASC