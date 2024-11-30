CREATE DATABASE LibraryDb 
USE LibraryDb

--01
CREATE TABLE Contacts (
	Id INT PRIMARY KEY IDENTITY
	,Email NVARCHAR(100)
	,PhoneNumber NVARCHAR(20)
	,PostAddress NVARCHAR(200)
	,Website NVARCHAR(50)
)
 
CREATE TABLE Authors (
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(100) NOT NULL
	,ContactId INT FOREIGN KEY REFERENCES Contacts (Id) NOT NULL
)
 
CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(30) NOT NULL
)
 
CREATE TABLE Books (
	Id INT PRIMARY KEY IDENTITY
	,Title NVARCHAR(100) NOT NULL
	,YearPublished INT NOT NULL
	,ISBN NVARCHAR(13) UNIQUE NOT NULL
	,AuthorId INT FOREIGN KEY REFERENCES Authors (Id) NOT NULL
	,GenreId INT FOREIGN KEY REFERENCES Genres (Id) NOT NULL
)
 
CREATE TABLE Libraries (
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
	,ContactId INT FOREIGN KEY REFERENCES Contacts (Id) NOT NULL
)
 
CREATE TABLE LibrariesBooks (
	LibraryId INT FOREIGN KEY REFERENCES Libraries (Id) NOT NULL
	,BookId INT FOREIGN KEY REFERENCES Books (Id) NOT NULL
	,PRIMARY KEY (LibraryId, BookId)
)

--02
INSERT INTO Contacts (Email,	PhoneNumber,	PostAddress,	Website)
VALUES (NULL,	NULL,	NULL,	NULL),
(NULL,	NULL,	NULL,	NULL),
('stephen.king@example.com',	'+4445556666',	'15 Fiction Ave, Bangor, ME',	'www.stephenking.com'),
('suzanne.collins@example.com',	'+7778889999',	'10 Mockingbird Ln, NY, NY',	'www.suzannecollins.com')

INSERT INTO Authors ([Name],	ContactId) 
VALUES ('George Orwell',	21),
('Aldous Huxley',	22),
('Stephen King',	23),
('Suzanne Collins',	24)

INSERT INTO Books(Title,	YearPublished,	ISBN,	AuthorId,	GenreId)
VALUES ('1984',	1949,	'9780451524935',	16,	2),
('Animal Farm',	1945,	'9780451526342',		16,	2),
('Brave New World',	1932,	'9780060850524',	17,	2),
('The Doors of Perception',	1954,	'9780060850531',	17,	2),
('The Shining',	1977,	'9780307743657',	18,	9),
('It',	1986,	'9781501142970',	18,9),
('The Hunger Games',	2008,	'9780439023481',	19,	7),
('Catching Fire',	2009,	'9780439023498',	19,	7),
('Mockingjay',	2010,	'9780439023511',	19,	7)

INSERT INTO LibrariesBooks(LibraryId,	BookId)
VALUES (1,	36),
(1,	37),
(2,	38),
(2,	39),
(3,	40),
(3,	41),
(4,	42),
(4,	43),
(5,	44)


--03
UPDATE Contacts
SET Website = CONCAT_WS('','www.', LOWER(REPLACE(a.[Name], ' ', '')), '.com')
FROM Authors AS a
LEFT JOIN Contacts AS c ON a.ContactId =c.Id
WHERE c.Website IS NULL

--04
DELETE LibrariesBooks 
FROM LibrariesBooks AS lb 
JOIN Books AS b ON lb.BookId=b.Id
WHERE b.AuthorId IN 
(
SELECT a.Id FROM Authors AS a
WHERE a.[Name]='Alex Michaelides'
)

DELETE Books
WHERE AuthorId IN 
(
SELECT a.Id FROM Authors AS a
WHERE a.[Name]='Alex Michaelides'
)

DELETE FROM Authors 
WHERE [Name] ='Alex Michaelides'


--05
SELECT Title,ISBN,YearPublished
FROM Books
ORDER BY YearPublished DESC, Title ASC

--06
SELECT b.Id,b.Title,b.ISBN,g.[Name]
FROM Books AS b
JOIN Genres AS g ON g.Id =b.GenreId
WHERE g.[Name] IN ('Biography', 'Historical Fiction')
ORDER BY g.[Name],b.Title ASC


--07
SELECT l.[Name], c.Email
FROM Libraries AS l
JOIN Contacts AS c ON l.ContactId =c.Id
JOIN LibrariesBooks AS lb ON l.Id =lb.LibraryId 
JOIN Books AS b ON lb.BookId =b.Id 
GROUP BY l.[Name],c.Email
HAVING SUM
(
CASE 
WHEN b.GenreId =1 THEN 1 ELSE 0
END
)=0
ORDER BY l.[Name] ASC

--08
SELECT TOP 3 b.Title,b.YearPublished AS [Year],g.[Name] AS Genre
FROM Books AS b
JOIN Genres AS g ON b.GenreId =g.Id
WHERE (b.YearPublished>2000 AND b.Title LIKE ('%a%')) OR 
(b.YearPublished<1950 AND G.[Name] LIKE ('Fantasy'))
ORDER BY b.Title,b.YearPublished DESC

--09
SELECT a.[Name] AS Author,c.Email,c.PostAddress
FROM Authors AS a
JOIN Contacts AS c ON a.ContactId =c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.[Name] ASC

--10
SELECT a.[Name] AS Author, b.Title, l.[Name] AS [Library], c.PostAddress AS [Library Address]
FROM Books AS b
JOIN Genres AS g ON b.GenreId =g.Id
JOIN LibrariesBooks AS lb ON b.Id =lb.BookId
JOIN Libraries AS l ON lb.LibraryId =l.Id
JOIN Contacts AS c ON l.ContactId =c.Id 
JOIN Authors AS a ON b.AuthorId =a.Id
WHERE g.[Name] LIKE 'Fiction%' AND C.PostAddress LIKE '%Denver%'
ORDER BY b.Title

--11
CREATE FUNCTION udf_AuthorsWithBooks(@name VARCHAR(50))
RETURNS INT
AS
BEGIN
    DECLARE @total_books INT;

    SELECT @total_books = COUNT(b.Id)
    FROM Authors a
    JOIN books b ON a.Id = b.AuthorId
    JOIN LibrariesBooks lb ON b.Id = lb.BookId
    WHERE a.[Name] = @name;

    RETURN @total_books;
END

--12
CREATE PROC usp_SearchByGenre(@genreName VARCHAR(50))
AS
BEGIN
    SELECT b.Title, b.YearPublished, b.ISBN, a.[Name] AS Author, g.[Name] AS Genre
    FROM Books AS b
	JOIN Authors AS a ON b.AuthorId =a.Id
	JOIN Genres AS g ON b.GenreId=g.Id 
    WHERE G.[Name] = @genreName
    ORDER BY b.Title
END