--Task 4
--------------------------------------------------
SELECT * FROM Departments;
--Task 5
--------------------------------------------------
SELECT Name FROM Departments;
--Task 6
--------------------------------------------------
SELECT Salary FROM Employees;
--Task 7
--------------------------------------------------
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full name] FROM Employees
--Task 8
--------------------------------------------------
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses] FROM Employees;
--Task 9
--------------------------------------------------
SELECT DISTINCT Salary FROM Employees;
--Task 10
--------------------------------------------------
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative';
--Task 11
--------------------------------------------------
SELECT * FROM Employees
WHERE FirstName LIKE 'SA%';
--Task 12
--------------------------------------------------
SELECT FirstName + ' ' + LastName FROM Employees
WHERE LastName LIKE '%ei%';
--Task 13
--------------------------------------------------
SELECT Salary FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
--Task 14
--------------------------------------------------
SELECT FirstName + ' ' + LastName AS [Full name], Salary FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600);
--Task 15
--------------------------------------------------
SELECT FirstName + ' ' + LastName AS [Full name], ManagerID FROM Employees
WHERE ManagerID IS NULL;
--Task 16
--------------------------------------------------
SELECT FirstName + ' ' + LastName AS [Full name], Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC;
--Task 17
--------------------------------------------------
SELECT * FROM Employees
ORDER BY Salary DESC
OFFSET 5 ROWS
FETCH NEXT 5 ROWS ONLY;
--Task 18
--------------------------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Full name], 
		a.AddressText
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID;
--Task 19
--------------------------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Full name],
		a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID;
--Task 20
--------------------------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Employee name], 
m.FirstName + ' ' + m.LastName AS [Manager name]
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID;
--Task 21
--------------------------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Employee name], 
m.FirstName + ' ' + m.LastName AS [Manager name],
a.AddressText
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID
JOIN Addresses a
ON e.AddressID = a.AddressID;
--Task 22
--------------------------------------------------
SELECT Name FROM Towns
UNION
SELECT Name FROM Departments;
--Task 23
--------------------------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Employee name],
m.FirstName + ' ' + m.LastName AS [Manager name]
FROM Employees e
--LEFT OUTER JOIN Employees m
RIGHT OUTER JOIN Employees m
ON m.ManagerID = e.ManagerID;
--Task 24
--------------------------------------------------
SELECT FirstName + ' ' + LastName AS [Employee name], DepartmentID, HireDate FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10) 
AND (HireDate > '1995-01-01 00:00:00' AND HireDate < '2005-12-31 00:00:00');