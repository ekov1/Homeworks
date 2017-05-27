USE TelerikAcademy

--4
SELECT * FROM Departments

--5
SELECT Name FROM Departments

--6
SELECT Salary FROM Employees

--7
SELECT FirstName + ' ' + LastName as [Full name] FROM Employees

--8
SELECT FirstName + ' ' + LastName AS [Full name],
 FirstName + '.' + LastName + '@telerik.com' AS [Full Email Adresses]
  FROM Employees

--9 Unique salaries
SELECT DISTINCT Salary FROM Employees

--10
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

--11
SELECT FirstName + ' ' + LastName AS [Full name]
FROM Employees
WHERE FirstName LIKE 'SA%'

--12
SELECT FirstName + ' ' + LastName AS [Full name]
FROM Employees
WHERE LastName LIKE '%ei%'

--13
SELECT FirstName + ' ' + LastName AS [Full name], Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--14
SELECT FirstName + ' ' + LastName AS [Full name], Salary
FROM Employees
WHERE Salary IN(25000, 14000, 12500, 23600)


--15
SELECT FirstName + ' ' + LastName AS [Full name], ManagerID
FROM Employees
WHERE ManagerID IS NULL

--16
SELECT FirstName + ' ' + LastName AS [Full name], Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--17
SELECT TOP 5 FirstName + ' ' + LastName AS [Full name], Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--18
SELECT FirstName + ' ' + LastName AS [Full name], a.AddressText
FROM Employees e
INNER JOIN Addresses a
ON e.AddressID = a.AddressID

--19
SELECT FirstName + ' ' + LastName AS [Full name], a.AddressText
	FROM Employees e, Addresses a
	WHERE e.AddressID = a.AddressID

--20
SELECT e.FirstName + ' ' + e.LastName AS [Employee name],
m.FirstName + ' ' + m.LastName AS [Manager name]
FROM Employees e
INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

--21
SELECT e.Firstname AS [Employee Name], 
m.FirstName AS [Manager name],
 a.AddressText AS [Manager adress]
FROM Employees e
INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses a
	ON m.AddressID = a.AddressID

--22 Prints disctinct values into one list
SELECT Name FROM Departments
UNION
SELECT Name FROM Towns

--Prints all values into one list
SELECT FirstName FROM Employees
UNION ALL
SELECT Name FROM Departments

--23.1
SELECT e.FirstName + ' ' + e.LastName AS [Employee name],
m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees m
RIGHT OUTER JOIN Employees e
	ON e.ManagerID = m.EmployeeID

--23.2
SELECT e.FirstName + ' ' + e.LastName AS [Employee name],
m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

--24
SELECT e.FirstName + ' ' + e.LastName AS [Employee name]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE (d.Name IN('Sales', 'Finance'))  AND (YEAR(e.HireDate) BETWEEN 1995 AND 2005)


