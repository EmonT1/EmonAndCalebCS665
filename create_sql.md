SQL Queries to Make all the tables
CREATE TABLE [dbo].[Employee]
(
    [EID] INT NOT NULL PRIMARY KEY, 
    [First Name] NVARCHAR(MAX) NOT NULL, 
    [Last Name] NVARCHAR(MAX) NOT NULL, 
    [Deparment] NVARCHAR(MAX) NOT NULL
);
CREATE TABLE [dbo].[TimeCards]
(
    [TCID] INT NOT NULL PRIMARY KEY, 
    [EmployeeID] INT NOT NULL, 
    [WeekEndingDate] DATE NOT NULL, 
    [TotalHours] INT NOT NULL, 
    CONSTRAINT [FK_TimeCards_Employee]
    FOREIGN KEY ([EmployeeID]) REFERENCES [Employee]([EID])
    ON DELETE CASCADE
    ON UPDATE CASCADE,
);
CREATE TABLE [dbo].[TimeEntries]
(
    [TEID] INT NOT NULL PRIMARY KEY, 
    [TimeCardID] INT NOT NULL, 
    [Date] DATE NOT NULL, 
    [Start Time ] TIME NOT NULL, 
    [End Time] TIME NOT NULL, 
    [TaskID] INT NOT NULL, 
    CONSTRAINT [FK_TimeEntries_TimeCards] 
    FOREIGN KEY ([TimeCardID]) REFERENCES [TimeCards]([TCID]), 
    CONSTRAINT [FK_TimeEntries_Tasks] 
    FOREIGN KEY ([TaskID]) REFERENCES [Tasks]([TaskID])
);
CREATE TABLE [dbo].[Tasks]
(
    [TaskID] INT NOT NULL PRIMARY KEY, 
    [Task Description] NVARCHAR(MAX) NOT NULL
);

