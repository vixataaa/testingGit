USE BankingSystem

-- Create a stored procedure that accepts a number as a parameter and 
-- returns all persons who have more money in their accounts than the supplied number.
GO
ALTER PROC usp_MoreMoneyThan 
	@amount money
AS
	SELECT p.FirstName, 
		p.LastName, 
		a.Balance 
	FROM People AS [p]
		JOIN Accounts AS [a]
			ON p.Id = a.PersonId
		WHERE a.Balance > @amount
GO

-- Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--	It should calculate and return the new sum.
--	Write a SELECT to test whether the function works as expected.
GO
CREATE FUNCTION ufn_CalculateInterest(
	@moneyAmount MONEY,
	@interestRate MONEY,
	@numberOfMonths MONEY)
RETURNS MONEY
AS
-- Returns amount of money after calculating interest rate
BEGIN
	DECLARE @result MONEY
	SELECT @result = @moneyAmount + (@moneyAmount * @interestRate) * @numberOfMonths
	RETURN @result
END
GO

---- TEST
SELECT BankingSystem.dbo.ufn_CalculateInterest(1000, 0.1, 5)

-- Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
--	It should take the AccountId and the interest rate as parameters.
GO
ALTER PROC usp_ApplyMonthlyInterest
	@accountId INT,
	@interestRate MONEY
AS
	DECLARE @initialBalance MONEY
	SET @initialBalance = 
		(
		SELECT Balance
		FROM Accounts
			WHERE Id = @accountId
		)
	
	DECLARE @appliedInterestBalance MONEY
	SELECT @appliedInterestBalance = BankingSystem.dbo.ufn_CalculateInterest(@initialBalance, @interestRate, 1)

	UPDATE Accounts 
		SET Balance = @appliedInterestBalance
		WHERE Id = @accountId
GO

EXEC usp_ApplyMonthlyInterest 2, 0.1

-- Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
-- WITHDRAW MONEY
GO
ALTER PROC usp_WithdrawMoney
	@accountId INT,
	@amount MONEY
AS
	BEGIN TRAN
		UPDATE Accounts
			SET Balance = Balance - @amount
			WHERE Id = @accountId
		IF (SELECT Balance FROM Accounts
				WHERE Id = @accountId) < 0
			BEGIN
				ROLLBACK
			END
		ELSE
			BEGIN
				COMMIT
			END
GO

EXEC usp_WithdrawMoney 2, 1610

-- DEPOSIT MONEY
GO
CREATE PROC usp_DepositMoney
	@accountId INT,
	@amount MONEY
AS
	BEGIN TRAN
		UPDATE Accounts
			SET Balance = Balance + @amount
			WHERE Id = @accountId
	COMMIT
GO

EXEC usp_DepositMoney 2, 500.49

-- Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--	Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
-- TABLE
CREATE TABLE Logs
(
	Id INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL,
	FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
)

-- TRIGGER
GO
ALTER TRIGGER LogBalanceChanges
ON Accounts
INSTEAD OF UPDATE
AS
	SET NOCOUNT ON
	DECLARE @initialBalance MONEY
	SET @initialBalance = (
		SELECT a.Balance FROM Accounts AS [a]
			WHERE Id = (
				SELECT i.Id FROM
					inserted AS [i]
		)
	)

	DECLARE @afterBalance MONEY
	SET @afterBalance = (
		SELECT Balance FROM inserted
	)

	UPDATE Accounts
		SET Balance = (
			SELECT i.Balance 
			FROM inserted AS [i]
		)
		WHERE Id = (
			SELECT i.id
			FROM inserted AS [i]
		)

	INSERT INTO Logs
		VALUES
		((SELECT PersonId FROM inserted), @initialBalance, @afterBalance)
GO

EXEC usp_WithdrawMoney 5, 500

-- 

