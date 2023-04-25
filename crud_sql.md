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

"Update Employee SET [First Name] = '" + Fnametxt.Text + "' , [Last Name] = '" + Lnametxt.Text + "' , [Deparment] = '" + Departmenttxt.Text + "' WHERE EID = " + EIDtxt.Text + ";";

"Update TimeCards SET [EmployeeID] = " + TCEIDtxt.Text + ", [WeekEndingDate] = '" + WeekEndingDatetxt.Text + "', [TotalHours] = " + TotalHourstxt.Text + "WHERE TCID = " + TCIDtxt.Text + ";";

"Update TimeEntries SET [TimeCardID] = " + TimeCardIDtxt.Text + ", [Date] = '" + Datetxt.Text + "' , [Start Time] = '" + StartTimetxt.Text + "' , [End Time] = '" + EndTimetxt.Text + "' , [TaskID] = " + TaskID.Text + "WHERE TEID = " + TEIDtxt.Text + ";";

"Update Tasks SET [Task Description] = '" + TaskDescriptiontxt.Text + "' , [Priority Level] = " + PriorityLeveltxt.Text + ", [Task Lead] = '" + TaskLeadtxt.Text + "' WHERE [TaskID] = " + Task_ID.Text + ";";

INSERT INTO EMPLOYEE (EID,[First Name], [Last Name], Deparment) VALUES (@EID, @Fname, @Lname, @Department)

INSERT INTO TimeCards (TCID, EmployeeID, WeekEndingDate, TotalHours) VALUES (@TCID, @EmpID, @WED, @TH)

INSERT INTO TimeEntries ([TEID], [TimeCardID], [Date], [Start Time], [End Time], [TaskID]) VALUES (@TEID, @TimeCardID, @Date, @StartTime, @EndTime, @Taskid)

INSERT INTO Tasks (TaskID, [Task Description], [Priority Level], [Task Lead]) VALUES (@Task_ID, @Task_Description, @Priority, @Lead)