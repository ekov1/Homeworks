USE TelerikAcademy

--1
SELECT FirstName + ' ' + LastName AS [Employee name], Salary
FROM Employees
WHERE Salary = 
(SELECT MIN(Salary) FROM Employees)

--2
SELECT FirstName + ' ' + LastName AS [Employee name], Salary
FROM Employees
WHERE Salary <=
1.1 * (SELECT MIN(Salary) FROM Employees)

--3
SELECT e.FirstName + ' ' + e.LastName  AS [Full employee name], e.Salary, d.Name
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
	(SELECT MIN(Salary) FROM Employees
		WHERE DepartmentID = d.DepartmentID)

--3.1(Checking if it works correctly)
SELECT MIN(e.Salary) FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Tool Design'

--4
SELECT AVG(Salary) AS [Average department Salary]
FROM Employees
WHERE DepartmentID = 1;

--5
SELECT AVG(e.Salary) AS [Average Salary]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--6
SELECT COUNT(*) AS [Employee count]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--7
SELECT COUNT(*) AS [Employee count]
FROM Employees
WHERE ManagerID IS NOT NULL;

--8
SELECT COUNT(*) AS [Employee count]
FROM Employees
WHERE ManagerID IS NULL;

--9
SELECT d.Name AS [Department Name], AVG(e.Salary) AS [Average department salary]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name;

--10
SELECT d.Name AS [Department Name], t.Name AS [Town], COUNT(*) AS [Employee count]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
		INNER JOIN Addresses a
			ON e.AddressID = a.AddressID
				INNER JOIN Towns t
					ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY d.Name

--11
SELECT m.FirstName + ' ' + m.LastName AS [Manager name]
FROM Employees e
INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(m.EmployeeID) = 5

--12
SELECT e.FirstName + ' ' + e.LastName AS [Employee name], 
ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager name]
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID;

--13
SELECT FirstName + ' ' + LastName AS [Employee name]
FROM Employees
WHERE LEN(LastName) = 5;

--14
SELECT CONVERT(varchar(24), GETDATE(), 113) AS [Current date]

--15
CREATE TABLE Users(
[Id] int NOT NULL IDENTITY PRIMARY KEY,
[Username] nvarchar(25) NOT NULL UNIQUE,
[Password] nvarchar(50) NOT NULL,
[LastLogin] datetime,
CONSTRAINT Chk_Password CHECK (LEN(Password) >= 5)
)
GO

--16, 19
INSERT INTO Users VALUES
('mitko98', '123123', GETDATE()),
('gosho11', 'goshka', GETDATE()),
('shefa123', 'dada123', CONVERT(datetime, '11.04.1998 00:00:00'))
GO

CREATE VIEW [Todays_Users] AS
SELECT Username FROM Users
WHERE DATEDIFF(day, LastLogin, GETDATE()) = 0;
GO 

SELECT * FROM Todays_Users;
GO

--17
CREATE TABLE Groups(
[Id] int NOT NULL IDENTITY PRIMARY KEY,
[Name] nvarchar(50) NOT NULL UNIQUE
)
GO

--Will not add a new Foreign key id if it is null
ALTER TABLE Users
ADD [GroupId] int NOT NULL DEFAULT 1;

--19
INSERT INTO Groups VALUES
('First group'),
('Second group'),
('Third group'),
('Fourth group'),
('Fifth group');

GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups 
FOREIGN KEY (GroupId) REFERENCES Groups(Id);

GO

--20
--Change not all GroupIds to be set to 1
UPDATE Users
SET GroupId = 3
WHERE Username = 'mitko98';

UPDATE Groups SET Name = 'Peta grupa' WHERE Name = 'Fifth group'
GO

DELETE FROM Groups
WHERE Name = 'Peta grupa';

--22
--Had to remove unique constraint and password constraint..
INSERT INTO Users (Username, Password)
SELECT LOWER(LEFT(FirstName, 1) + LastName) AS [Username],
 LOWER(LEFT(FirstName, 1) + LastName) AS [Password] FROM Employees;

 --25
 SELECT d.Name, e.JobTitle, AVG(e.Salary) AS [Average salary]
 FROM Employees e
 INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
 GROUP BY d.Name, e.JobTitle
 ORDER BY d.Name;

 --26
 -- Taking some of the people by taking MIN(Full name)
 SELECT d.Name, e.JobTitle, 
	MIN(e.FirstName + ' ' + e.LastName) AS [Employee name], MIN(e.Salary) AS [Minimal salary]
 FROM Employees e
 INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name;

--27
SELECT TOP 1 t.Name, COUNT(*) AS [People in town]
FROM Employees e
INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
		INNER JOIN Towns t
			ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [People in town] DESC;

--28
SELECT t.Name, COUNT(*) AS [Managers in town]
FROM Employees m
INNER JOIN Addresses a
	ON m.AddressID = a.AddressID
		INNER JOIN Towns t
			ON a.TownID = t.TownID
WHERE m.ManagerID IS NULL
GROUP BY t.Name
ORDER BY [Managers in town] DESC;

--29
CREATE TABLE WorkHours(
[Id] int NOT NULL IDENTITY PRIMARY KEY,
[EmployeeId] int NOT NULL,
[Date] datetime,
[Task] nvarchar(100),
[Hours] int,
[Comments] nvarchar(200),
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY (EmployeeId)
	REFERENCES Employees(EmployeeID)
)

GO

INSERT INTO WorkHours VALUES
(4, GETDATE(), 'Writing SQL queries', 5, 'It was okay.'),
(23, GETDATE(), 'Looking at a wall', 12, 'Very interesting.'),
(11, GETDATE(), 'Washing the dishes', 1, 'It was hard but I did it.');

GO

CREATE TABLE WorkHoursLogs(
[Id] int NOT NULL IDENTITY PRIMARY KEY,
[EmployeeId] int NOT NULL,
[Date] datetime,
[Task] nvarchar(100),
[Hours] int,
[Comments] nvarchar(200),
[CommandPerformed] nvarchar(25)
)

GO

--30
CREATE TRIGGER TR_WorkHours_INSERT ON WorkHours FOR INSERT
	AS
	BEGIN
		INSERT INTO WorkHoursLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [CommandPerformed])
		SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'INSERT' FROM 
	    inserted
	END
GO

CREATE TRIGGER TR_WorkHours_Delete ON WorkHours FOR DELETE
	AS
	BEGIN
		INSERT INTO WorkHoursLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [CommandPerformed])
		SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'DELETE' FROM 
	    deleted
	END
GO

CREATE TRIGGER TR_WorkHours_UPDATE ON WorkHours FOR UPDATE
	AS
	BEGIN
		INSERT INTO WorkHoursLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [CommandPerformed])
		SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'UPDATE' FROM 
	    inserted
	END
GO

INSERT INTO WorkHours 
VALUES(55, GETDATE(), 'Testing triggers', 2, 'Hope it works!');

GO

UPDATE WorkHours 
SET Comments += ' PS: It worked!'
WHERE EmployeeId = 55;

GO

DELETE FROM WorkHours
WHERE EmployeeId = 55

GO

--30
BEGIN TRAN
	DELETE FROM Employees
		WHERE DepartmentID = 
			(SELECT TOP 1 DepartmentID FROM Departments 
				WHERE Name = 'Sales')
ROLLBACK TRAN

--31
-- As long as the changes stay uncommited, its okay :D
BEGIN TRAN
	DROP TABLE EmployeesProjects
ROLLBACK TRAN

--32
--Creating temporary table
CREATE TABLE #TempTable(
[EmployeeID] int NOT NULL,
[ProjectID] int NOT NULL
)

GO

--Inserting the records from EmployeesProjects table
INSERT INTO #TempTable (EmployeeID, ProjectID)
	SELECT EmployeeID, ProjectID FROM EmployeesProjects
GO

DROP TABLE EmployeesProjects;
GO 

--Recreating the table EmployeesProjects
CREATE TABLE EmployeesProjects(
[EmployeeID] int NOT NULL,
[ProjectID] int NOT NULL,
CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EmployeesProjects_Projects FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
)
GO

--Recovering the records
INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
	SELECT EmployeeID, ProjectID FROM #TempTable;

GO

--Droping the temporary table
DROP TABLE #TempTable;
GO

