SQL Queries to Make all the tables
CREATE TABLE [dbo].[Employee]
(
    [EID] INT NOT NULL PRIMARY KEY, 
    [First Name] NVARCHAR(MAX) NOT NULL, 
    [Last Name] NVARCHAR(MAX) NOT NULL, 
    [Deparment] NVARCHAR(MAX) NOT NULL
);
CREATE TABLE [dbo].[TimeCards] (
    [TCID]           INT  NOT NULL,
    [EmployeeID]     INT  NOT NULL,
    [WeekEndingDate] DATE NOT NULL,
    [TotalHours]     INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([TCID] ASC),
    CONSTRAINT [FK_TimeCards_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EID]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO

CREATE TRIGGER [dbo].[Trigger_TimeCards]
    ON TimeCards
	AFTER UPDATE 
	AS 
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM Employee WHERE EID IN (SELECT EID FROM inserted))
		BEGIN
			RAISERROR('Employee ID not found in Employee table', 16, 1);
			ROLLBACK TRANSACTION;
		END
	END;

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
CREATE TABLE [dbo].[Tasks] (
    [TaskID]           INT            NOT NULL,
    [Task Description] NVARCHAR (MAX) NOT NULL,
    [Priority Level] INT NOT NULL, 
    [Task Lead] NVARCHAR(MAX) NOT NULL, 
    PRIMARY KEY CLUSTERED ([TaskID] ASC)
);
