SELECT * FROM Employee;
SELECT * FROM TimeCards;
SELECT * FROM TimeEntries;
SELECT * FROM Tasks;

SELECT Employee.EID, Employee.[First Name], TimeCards.TCID, TimeCards.WeekEndingDate, TimeCards.TotalHours
FROM Employee
INNER JOIN TimeCards ON Employee.EID = TimeCards.EmployeeID;

SELECT TimeCards.TCID, TimeCards.EmployeeID, TimeEntries.[Date], TimeEntries.TaskID
FROM TimeCards
INNER JOIN TimeEntries ON TimeCards.TCID = TimeEntries.TimeCardID;

UPDATE Employee
SET EID = 6
WHERE [First Name] = 'Caleb';

DELETE FROM " + selectedTableName + " WHERE EID = " + DelID.Text;