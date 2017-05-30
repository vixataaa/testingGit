USE TelerikAcademy

-- Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
-- Use a nested SELECT statement. 

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary, d.Name
FROM Employees AS [e]
	JOIN Departments AS [d]
		ON d.DepartmentID = e.DepartmentID
WHERE Salary =
	(SELECT MIN(Salary) 
	 FROM Employees
	 WHERE DepartmentID = e.DepartmentID)
ORDER BY Salary

-- Write a SQL query to find the average salary in the department #1.

SELECT DepartmentID, AVG(Salary) AS [AvrgSalary] FROM Employees
WHERE DepartmentID = 1
GROUP BY DepartmentID

-- Write a SQL query to find the average salary in the "Sales" department.

SELECT AVG(Salary) FROM Employees AS [e]
JOIN Departments AS [d]
ON e.DepartmentID = d.DepartmentID
AND d.Name = 'Sales'

-- Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(FirstName) AS [Employees] FROM Employees AS [e]
JOIN Departments AS [d]
ON e.DepartmentID = d.DepartmentID
AND d.Name = 'Sales'

-- Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(ManagerID) FROM Employees AS [e]
WHERE e.ManagerID IS NOT NULL

-- Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(FirstName) FROM Employees AS [e]
WHERE e.ManagerID IS NULL

-- Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name, AVG(Salary) AS [AverageSalary] FROM Employees AS [e]
JOIN Departments AS [d]
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name

-- Write a SQL query to find the count of all employees in each department and for each town.
---- Each department and each town
SELECT COUNT(*) as [EmployeeCount], t.Name as [TownName], d.Name as [DeptName]
FROM Employees as [e]
	JOIN Addresses as [a]
		ON e.AddressID = a.AddressID
	JOIN Towns as [t]
		ON a.TownID = t.TownID
	JOIN Departments as [d]
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, t.Name

-- Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName, m.LastName
FROM Employees as [e]
	JOIN Employees as [m]
		ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(m.EmployeeID) = 5

-- Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName, e.LastName, ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)')
FROM Employees as [e]
	LEFT OUTER JOIN Employees as [m]
		ON e.ManagerID = m.EmployeeID

-- Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT e.FirstName, e.LastName from Employees as [e]
	WHERE LEN(e.LastName) = 5

-- Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT CONVERT(VARCHAR(24), GETDATE(), 113) AS [Current Time]

-- Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--	Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--	Define the primary key column as identity to facilitate inserting records.
--	Define unique constraint to avoid repeating usernames.
--	Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users
(
	[UserId] INT PRIMARY KEY IDENTITY,
	[Username] NVARCHAR(50) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) CHECK (DATALENGTH([Password]) > 5) NOT NULL,
	[FullName] NVARCHAR (100),
	[LastLogin] DATE
)

-- Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--	Test if the view works correctly.
CREATE VIEW [UsersLoggedToday] AS
SELECT * FROM Users
	WHERE DAY(Users.LastLogin) = DAY(GETDATE())

-- Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
-- Define primary key and identity column.
CREATE TABLE Groups
(
	GroupId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE NOT NULL,
)

-- Write a SQL statement to add a column GroupID to the table Users.
--	Fill some data in this new column and as well in the `Groups table.
--	Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users
	ADD GroupId INT,
	FOREIGN KEY(GroupId) REFERENCES Groups(GroupId)

-- Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups 
	VALUES
	('Group 1'),
	('Group 2'),
	('Group 3'),
	('Group 4'),
	('Group 5'),
	('Group 6'),
	('Group 7'),
	('Group 8'),
	('Group 9'),
	('Group 10')

INSERT INTO Users 
	VALUES 
	('tosho1', '1234', 'Tosho Gosho', GETDATE(), 1),
	('tosho2', '1234', 'Tosho Gosho', GETDATE(), 3),
	('tosho3', '1234', 'Tosho Gosho', GETDATE(), 1),
	('tosho4', '1234', 'Tosho Gosho', GETDATE(), 2),
	('tosho5', '1234', 'Tosho Gosho', GETDATE(), 4),
	('tosho6', '1234', 'Tosho Gosho', GETDATE(), 2),
	('tosho7', '1234', 'Tosho Gosho', GETDATE(), 1),
	('tosho8', '1234', 'Tosho Gosho', GETDATE(), 2),
	('tosho9', '1234', 'Tosho Gosho', GETDATE(), 3)

-- TEST
SELECT u.Username, g.Name FROM Users as [u]
	JOIN Groups as [g]
		ON g.GroupId = u.GroupId

-- Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Groups
	SET Groups.Name = 'Secret group'
		WHERE Groups.GroupId = 2

UPDATE Users
	SET Users.FullName = 'Stoyan Stoyanov'
		WHERE Users.UserId = 20

-- Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE Users
	WHERE Users.Username LIKE '%1'

DELETE Groups
	WHERE Groups.GroupId = 5

-- Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--	Combine the first and last names as a full name.
--	For username use the first letter of the first name + the last name (in lowercase).
--	Use the same for the password, and NULL for last login time.
INSERT INTO Users
	SELECT LOWER(LEFT(e.FirstName, 3) + e.LastName), 
		LOWER(LEFT(e.FirstName, 1) + e.LastName), 
		e.FirstName + ' ' + e.LastName, 
		NULL, 
		NULL 
	FROM Employees as [e]

-- Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

-- Write a SQL statement that deletes all users without passwords (NULL password).

-- Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name as [DepartmentName], e.JobTitle, AVG(Salary) FROM Employees as [e]
	JOIN Departments as [d]
		ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle

-- Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT MIN(Salary), MIN(FirstName + ' ' + LastName) as [FullName], d.Name, e.JobTitle FROM Employees as [e]
	JOIN Departments as [d]
		ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle, d.Name

-- Write a SQL query to display the town where maximal number of employees work.
SELECT TOP(1) t.Name, COUNT(*) FROM Employees as [e]
	JOIN Addresses as [a]
		ON a.AddressID = e.AddressID
	JOIN Towns as [t]
		ON t.TownID = a.TownID
GROUP BY t.Name

-- Write a SQL query to display the number of managers from each town.
SELECT t.Name as [TownName], COUNT(DISTINCT m.EmployeeID) FROM Employees AS [e]
	JOIN Employees as [m]
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses as [a]
		ON m.AddressID = a.AddressID
	JOIN Towns as [t]
		ON t.TownID = a.TownID
GROUP BY t.Name


-- Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--	Don't forget to define identity, primary key and appropriate foreign key.
--	Issue few SQL statements to insert, update and delete of some data in the table.
--	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--		For each change keep the old record data, the new record data and the command (insert / update / delete).

-- Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
--	At the end rollback the transaction.

-- Start a database transaction and drop the table EmployeesProjects.
--	Now how you could restore back the lost table data?

-- Find how to use temporary tables in SQL Server.
--	Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.