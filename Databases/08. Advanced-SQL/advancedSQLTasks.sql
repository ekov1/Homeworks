--Task 1
--------------------------------------------------
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees);
--Task 2
--------------------------------------------------
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary <=
 (SELECT MIN(Salary) FROM Employees) + (SELECT MIN(Salary) FROM Employees) * 0.1;
--Task 3
--------------------------------------------------
SELECT e.FirstName, e.LastName, e.Salary, d.Name
 FROM Employees e, Departments d
WHERE Salary = 
(SELECT MIN(Salary) FROM Employees WHERE e.DepartmentID = d.DepartmentID);
--Task 4
--------------------------------------------------
SELECT AVG(Salary) AS [Average salary] FROM Employees
WHERE DepartmentID = 1;
--Task 5
--------------------------------------------------
SELECT AVG(Salary) AS [Average salary] FROM Employees e
JOIN Departments d
ON (e.DepartmentID = d.DepartmentID AND d.Name = 'Sales');
--Task 6
--------------------------------------------------
SELECT COUNT(*) AS [Sales Empl Count] FROM Employees e
JOIN Departments d
ON(e.DepartmentID = d.DepartmentID AND d.Name = 'Sales');
--Task 7	
--------------------------------------------------
SELECT COUNT(*) AS [Empl with manager count] FROM Employees
WHERE ManagerID IS NOT NULL;
--Task 8
--------------------------------------------------
SELECT COUNT(*) AS [Empl without manager count] FROM Employees
WHERE ManagerID IS NULL;
--Task 9
--------------------------------------------------
SELECT d.Name, AVG(Salary) FROM Employees e
JOIN Departments d
ON(e.DepartmentID = d.DepartmentID)
GROUP BY d.Name;
--Task 10
--------------------------------------------------
SELECT d.Name AS [Department], t.Name [Town], COUNT(e.EmployeeID) AS [Employees count] FROM Employees e
JOIN Departments d
ON(e.DepartmentID = d.DepartmentID)
JOIN Addresses a
ON(e.AddressID = a.AddressID)
JOIN Towns t
ON(a.TownID = t.TownID)
GROUP BY d.Name, t.Name, a.TownID;
--Task 11
--------------------------------------------------
--Works
SELECT m.FirstName, m.LastName , m.EmployeeID
FROM Employees e JOIN Employees m
ON(e.ManagerID = m.EmployeeID)
GROUP BY m.FirstName, m.LastName, m.EmployeeID
HAVING COUNT(m.EmployeeID) = 5;
--Task 12
--------------------------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Employee name], 
ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager name]
FROM Employees e 
LEFT OUTER JOIN Employees m
ON(m.EmployeeID = e.ManagerID);

--Task 13
--------------------------------------------------
SELECT FirstName + ' ' + LastName AS [Full name] FROM Employees
WHERE LEN(LastName) = 5;
--Task 14
--------------------------------------------------
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy hh:mm:ss:fff');
--Task 15
--------------------------------------------------
CREATE TABLE Users (
id int IDENTITY,
Username nvarchar(50) NOT NULL UNIQUE,
FullName nvarchar(50) NOT NULL,
Password nvarchar(50) NOT NULL UNIQUE,
LastLogin smalldatetime,
CONSTRAINT PK_Users PRIMARY KEY(id),
CONSTRAINT chk_Password CHECK (LEN(Password) >= 5)
)
GO
--Task 16
--------------------------------------------------
--Works only when records are set to current day
CREATE VIEW [Logged users today] AS
SELECT * FROM Users
WHERE DAY(CONVERT(DATETIME, LastLogin)) = DAY(GETDATE());
--Task 17
--------------------------------------------------
CREATE TABLE Groups(
id int IDENTITY,
name nvarchar(50) NOT NULL UNIQUE,
CONSTRAINT PK_Groups PRIMARY KEY(id)
)
GO
--Task 18
--------------------------------------------------
ALTER TABLE Users ADD GroupID int NOT NULL;

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups 
FOREIGN KEY(GroupID)
REFERENCES Groups(id);
--Task 19
--------------------------------------------------
INSERT INTO Groups Values('FourthGroup')
INSERT INTO Groups Values('FifthGroup')
INSERT INTO Users Values('insert1', 'Gosho Goshov', 'ggg555', '2017-01-10 09:09:09', 4)
--Task 20
--------------------------------------------------

--Task 21
--------------------------------------------------
DELETE FROM Users
WHERE Username = 'test1';

DELETE FROM Groups
WHERE name = 'FifthGroup';
--Task 22
--------------------------------------------------
--Doesnt work because usernames must be unique
INSERT INTO Users
([Username], [FullName], [Password], [LastLogin], [GroupID])
SELECT LOWER(LEFT(e.FirstName, 1) + e.LastName),
	   e.FirstName + ' ' + e.LastName,
	   e.FirstName + ' ' + e.LastName,
	   NULL,
	   1
	   FROM Employees e
	   
--Task 23
--------------------------------------------------
ALTER TABLE Users
ALTER COLUMN [Password] nvarchar(50) NULL
GO

UPDATE Users
SET Password = NULL
WHERE LastLogin <= '2010-03-10 00:00:00';
--Task 24
--------------------------------------------------
DELETE FROM Users
WHERE Password IS NULL;
--Task 25
--------------------------------------------------
SELECT e.JobTitle, d.Name AS [Department], AVG(Salary) AS [Average salary] FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name;
--Task 26
--------------------------------------------------
SELECT e.FirstName, e.LastName, e.JobTitle, d.Name AS [Department], MIN(e.Salary) AS [Min salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName;

--Task 27
--------------------------------------------------
--Not finished
SELECT t.Name, MAX(e.EmployeeID) FROM Employees e
JOIN Addresses a
ON(e.AddressID = a.AddressID)
JOIN Towns t
ON(a.TownID = t.TownID)
GROUP BY t.Name;

--Task 28
--------------------------------------------------
SELECT t.Name, COUNT(DISTINCT e.ManagerID) AS [Manager count] FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name;
--Task 29
--------------------------------------------------
--1.1
CREATE TABLE WorkHours(
id int IDENTITY,
EmployeeID int NOT NULL,
Date DATETIME,
Task nvarchar(100),
Hours int NOT NULL,
Comments varchar(200),
CONSTRAINT PK_WorkHours PRIMARY KEY(id),
CONSTRAINT FK_WorkHours_Employees 
FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID)
)
GO

--1.2
INSERT INTO WorkHours 
Values(20, '2017-02-02 00:00:00', 'Cleaning', 4)
INSERT INTO WorkHours 
Values(20, '2017-03-12 01:01:00', 'Programming', 2)
GO

--1.3
CREATE TABLE WorkHoursLogs(
id int IDENTITY,
EmployeeID int NOT NULL,
Date DATETIME,
Task nvarchar(100),
Hours int NOT NULL,
Comments varchar(200),
Command varchar(50),
CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(id)
)
GO

CREATE TRIGGER trg_WorkHours_Insert ON WorkHours
    FOR INSERT 
    AS
    INSERT INTO WorkHoursLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [Command])
        SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'INSERT'
        FROM inserted
    GO

CREATE TRIGGER trg_WorkHours_Delete ON WorkHours
    FOR INSERT 
    AS
    INSERT INTO WorkHoursLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [Command])
        SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'DELETE'
        FROM deleted
    GO

CREATE TRIGGER trg_WorkHours_Update ON WorkHours
    FOR INSERT 
    AS
    INSERT INTO WorkHoursLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [Command])
        SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'UPDATE'
        FROM inserted
    GO
