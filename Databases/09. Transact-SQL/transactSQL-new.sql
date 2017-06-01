--1
USE master

CREATE DATABASE TransactSQLDb
GO

USE TransactSQLDb

CREATE TABLE Persons(
	[Id] int NOT NULL IDENTITY PRIMARY KEY,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[SSN] char(9)
)
GO

CREATE TABLE Accounts(
	[Id] int NOT NULL IDENTITY PRIMARY KEY,
	[PersonId] int NOT NULL,
	[Balance] money DEFAULT 0,
	CONSTRAINT FK_Accounts_Person FOREIGN KEY (PersonId) REFERENCES Persons(Id)
)
GO

INSERT INTO Persons VALUES
('Georgi', 'Petrov', '111222333'),
('John', 'Doe', '123456789'),
('Chris', 'Po', '445645654')
GO

INSERT INTO Accounts VALUES
(1, 300),
(2, 12),
(3, 5000)
GO

CREATE PROCEDURE usp_ShowFullNames
AS
	BEGIN
		SELECT FirstName + ' ' + LastName AS [Full name] FROM Persons
	END
GO

--Testing stored proc
EXEC usp_ShowFullNames;
GO
--2
CREATE PROCEDURE usp_ShowPeopleWealthierThan 
(@ammount money) AS
	BEGIN
		SELECT p.FirstName + ' ' + p.LastName AS [Full name], a.Balance FROM Persons p
		INNER JOIN Accounts a
			ON a.PersonId = p.Id
		WHERE a.Balance > @ammount
		ORDER BY a.Balance
	END
GO

--Testing USP
EXEC usp_ShowPeopleWealthierThan 3077;
GO

--3
--Math may be incorrect
ALTER FUNCTION ufn_calculateInterest 
(@sum money, @yearlyInterestRate int, @months int)
RETURNS money
AS
	BEGIN
		RETURN @sum * (POWER(1 + @yearlyInterestRate / 12, @months))
	END
GO

DECLARE @sum money = 300.00;
DECLARE @mon money = dbo.ufn_calculateInterest(@sum, 20, 5)
PRINT(@mon)
GO
--4
CREATE PROCEDURE usp_AddInterestToPersonBalance
(@accountId int, @interestRate int)
AS
	BEGIN
		UPDATE Accounts
		SET Balance = dbo.ufn_calculateInterest(Balance, @interestRate, 1)
		WHERE Id = @accountId;
	END
GO

EXEC usp_AddInterestToPersonBalance 2, 20;
GO

--5
CREATE PROCEDURE usp_WithdrawMoney
(@accountId int, @ammount money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @ammount
		WHERE Id = @accountId;
	COMMIT TRAN
GO

CREATE PROCEDURE usp_DepositMoney
(@accountId int, @ammount money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @ammount
		WHERE Id = @accountId;
	COMMIT TRAN
GO

EXEC usp_WithdrawMoney 1, 400;
EXEC usp_DepositMoney 2, 8000;
GO

--6
CREATE TABLE Logs(
	[Id] int NOT NULL IDENTITY PRIMARY KEY,
	[AccountId] int NOT NULL,
	[OldSum] money,
	[NewSum] money,
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
)
GO

ALTER TRIGGER tr_BalanceUpdate ON Accounts FOR UPDATE
AS
	BEGIN
		INSERT INTO Logs(AccountId, OldSum, NewSum)
		SELECT d.Id, d.Balance, i.Balance FROM deleted d
		INNER JOIN inserted i
			ON d.Id = i.Id
	END
GO

UPDATE Accounts
SET Balance = 50000
WHERE Id = 2
GO

EXEC usp_WithdrawMoney 2, 23000;
GO

--7
USE TelerikAcademy
GO

ALTER FUNCTION ufn_CheckNamesComprisedOFLetters (@letters nvarchar(50), @word nvarchar(50))
RETURNS bit
AS
	BEGIN 
		DECLARE @n int = 1;
		DECLARE @wordLength int = LEN(@word);
		DECLARE @substr nvarchar(1);

		WHILE(@n <= @wordLength)
			BEGIN
				SET @substr = SUBSTRING(LOWER(@word), @n, 1);

				IF (CHARINDEX(@substr, LOWER(@letters)) <= 0)
					RETURN 0;
				SET @n = @n + 1;
			END
		RETURN 1;
	END
GO

ALTER FUNCTION ufn_filterNamesWithLetters (@letters nvarchar(50))
RETURNS TABLE
AS
		RETURN (SELECT FirstName FROM Employees
				WHERE dbo.ufn_CheckNamesComprisedOFLetters(@letters, FirstName) > 0
				  UNION
			   SELECT Name FROM Towns
			   WHERE dbo.ufn_CheckNamesComprisedOFLetters(@letters, Name) > 0)
GO

SELECT * FROM ufn_filterNamesWithLetters('oistmiahf');

-----1
--CREATE AGGREGATE StrConcat(@input nvarchar(4000))
--AS
--	BEGIN

--	END
