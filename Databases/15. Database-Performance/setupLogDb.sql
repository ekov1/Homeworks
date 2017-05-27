--Generating database
----------------------------------------------------
USE master
CREATE DATABASE PerformanceTestDb
GO

USE PerformanceTestDb

CREATE TABLE Logs(
	[Id] int IDENTITY PRIMARY KEY,
	[Content] nvarchar(50) NOT NULL,
	[Date] datetime NOT NULL
)
GO

-- Filling database with records 
--(takes a lot of resources and time to make 10 million records)
--(made it to 3.5 million records)
----------------------------------------------------
DECLARE @i int = 0;
DECLARE @initialDate datetime = '1999-01-01 00:00:00';

WHILE(@i < 10000000)
BEGIN
	INSERT INTO Logs
	VALUES ('Some random log text' + CAST(@i AS nvarchar), @initialDate)
	
	SET @i = @i + 1;
	SET @initialDate = @initialDate + 1;
END

-- Manipulating database
----------------------------------------------------
--Task 1.1
----------------------------------------------------
SET STATISTICS TIME ON
SET STATISTICS IO ON

-- To clear query cache
DBCC DROPCLEANBUFFERS
GO

SELECT * FROM Logs
WHERE Date BETWEEN '2005-05-05 00:00:00' AND '2010-02-02 00:00:00'
GO

--Task 2
----------------------------------------------------
CREATE INDEX DateIndex
ON Logs (Date)
GO

--Task 3
----------------------------------------------------
-- Should first install Fulltext Index ( problems with installing / feature not avaliable to install )
CREATE FULLTEXT CATALOG TextSearch
GO

--To get unique key id
SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
GO

CREATE FULLTEXT INDEX ON Logs
	(Content LANGUAGE 1033)
	KEY INDEX PK__Logs__3214EC07636FE39A
	ON TextSearch
