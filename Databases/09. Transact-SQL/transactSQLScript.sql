--Task 1
---------------------------------------------------
CREATE DATABASE TransactSQLDB
GO

USE TransactSQLDB

CREATE TABLE Persons(
	[Id] int NOT NULL IDENTITY PRIMARY KEY,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[SSN] varchar(9)
)
GO

CREATE TABLE Accounts(
	[Id] int NOT NULL IDENTITY PRIMARY KEY,
	[PersonId] int NOT NULL,
	[Balance] money NOT NULL,
	CONSTRAINT FK_Accounts_Persons 
		FOREIGN KEY (PersonId)
		REFERENCES Persons(Id)
)
GO

INSERT INTO Persons
	VALUES ('John', 'Doe', '111222333'),
		   ('Michael', 'Phelps', '123456789'),
		   ('Chris', 'Chan', '607080543')
GO

INSERT INTO Accounts
	VALUES (1, 5000),
		   (2, 3400),
		   (3, 9100)

GO

CREATE PROC usp_SelectFullEmployeeNames
AS
	SELECT FirstName + ' ' + LastName AS [Full name]
    FROM Persons
GO

EXEC('usp_SelectFullEmployeeNames')
GO

--Task 2
---------------------------------------------------

CREATE PROC usp_usersWithSpecificBalance(@money money)
AS
	SELECT p.FirstName, p.LastName, a.Balance FROM Persons p
	JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE a.Balance > @money
GO

EXEC('usp_usersWithSpecificBalance 4000')

--Task 3
---------------------------------------------------
CREATE FUNCTION fn_calculateNewSum
( @sum money, @annualInterestRate int, @numberOfMonths int )
	RETURNS money
AS
BEGIN
	RETURN @sum * (POWER(1 + @annualInterestRate / 12, @numberOfMonths))
END

DECLARE @sum money = (SELECT SUM(Balance) FROM Accounts)
DECLARE @newSum int = dbo.fn_calculateNewSum(@sum, 2, 6)

PRINT(@newSum)

--Task 4
---------------------------------------------------
CREATE PROC usp_applyInterestForOneMonth( @employeeId int, @interestRate int)
AS
	UPDATE Accounts
	SET Balance = dbo.fn_calculateNewSum(Balance, @interestRate, 1)
	WHERE Id = @employeeId
GO

--Task 5
---------------------------------------------------
CREATE PROC usp_withdrawMoneyFromAccount( @accountId int, @moneyToWithdraw money )
AS
	UPDATE Accounts
	SET Balance = Balance - @moneyToWithdraw
	WHERE Id = @accountId
GO

CREATE PROC usp_depositMoneyToAccount( @accountId int, @moneyToDeposit money )
AS
	UPDATE Accounts
	SET Balance = Balance + @moneyToDeposit
	WHERE Id = @accountId
GO

EXEC usp_withdrawMoneyFromAccount 1, 1000.0000 

--Task 6
---------------------------------------------------
CREATE TABLE Logs(
	[Id] int NOT NULL IDENTITY PRIMARY KEY,
	[AccountId] int NOT NULL,
	[OldSum] money,
	[NewSum] money,
	CONSTRAINT FK_Logs_Accounts 
		FOREIGN KEY(AccountId)
		REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER tr_SaveSumLog ON dbo.Accounts FOR UPDATE
AS
	BEGIN
		DECLARE @accountId int = (SELECT Id FROM deleted)
		DECLARE @oldBalance money = (SELECT Balance FROM deleted)
		DECLARE @newBalance money = (SELECT Balance FROM inserted)

		INSERT INTO dbo.Logs
			VALUES(@accountId, @oldBalance, @newBalance)
	END
GO

--Task 7
---------------------------------------------------
USE TelerikAcademy

CREATE FUNCTION fn_ContainsLetters( @lettersSet nvarchar(50), @word nvarchar(50) )
	RETURNS BIT
AS
BEGIN
	DECLARE @i int = 0
	WHILE @i < LEN( @word )
		BEGIN
			DECLARE @sub nvarchar(50) = SUBSTRING( @word, @i, 1 )
				IF(CHARINDEX(@lettersSet, @sub) <= 0)
					BEGIN
						RETURN 0
					END
				ELSE IF(CHARINDEX(@lettersSet, @sub) > 0)
					BEGIN
						SELECT @i = @i + 1
					END
		END
	RETURN 1
END
GO

CREATE FUNCTION fn_getNamesComprisedOfWord( @lettersSet nvarchar(50) )
	RETURNS TABLE
AS 
	RETURN( SELECT * FROM Employees
		WHERE dbo.fn_ContainsLetters(@lettersSet, FirstName) > 0
		)
GO

--Doesn't find records for some reason
SELECT * FROM dbo.fn_getNamesComprisedOfWord( 'oistmiahf')

--Task 8
---------------------------------------------------


--Task 9
---------------------------------------------------
