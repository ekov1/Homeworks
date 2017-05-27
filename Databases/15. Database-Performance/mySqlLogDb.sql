USE master
CREATE DATABASE performancetestdb

USE PerformanceTestDb

CREATE TABLE logs(
	[Id] int IDENTITY PRIMARY KEY,
	[Content] nvarchar(50) NOT NULL,
	[Date] datetime NOT NULL
)
GO

DECLARE @i int = 0;
DECLARE @initialDate datetime = '1999-01-01 00:00:00';

WHILE(@i < 1000000)
BEGIN
	INSERT INTO Logs
	VALUES ('Some random log text' + CAST(@i AS nvarchar), @initialDate)
	
	SET @i = @i + 1;
	SET @initialDate = @initialDate + 1;
END

SET STATISTICS TIME ON
SET STATISTICS IO ON

DBCC DROPCLEANBUFFERS
GO