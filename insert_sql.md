**Note:** Four queries were used to insert values into the four tables. Their values are taken from the text of the textboxes in the EmployeeInsert.xaml. Here each tab contains various textboxes representing a column in the database.
 

INSERT INTO EMPLOYEE (EID,[First Name], [Last Name], Deparment) VALUES (1, 'Ryan", "Powell', 'Development'), (2, 'Emon', 'Tehrani', 'Development'), (3, 'Caleb', 'Miller', 'Development'), (4, 'John', 'Doe', 'Management'), (5, 'John', 'Miller', 'Assembly' ); 

INSERT INTO TimeCards (TCID, EmployeeID, WeekEndingDate, TotalHours) VALUES (1, 1, '4/27/2023', 5), (2, 2, '4/28/2023', 6), (3, 3, '4/29/2023', 7), (4, 4, '4/30/2023', 8), (5,5,'4/30/2023', 8); 

INSERT INTO TimeEntries ([TEID], [TimeCardID], [Date],[Start Time], [End Time], [TaskID]) VALUES (1,1,'4/27/2023' ,'12:00','5:00',5), (2,2,'4/28/2023' ,'12:00','6:00',6), (3,3,'4/29/2023' ,'12:00','7:00',7), (4,4,'4/30/2023' ,'12:00','8:00',8), (5,5,'4/25/2023', '9:00', '5:00', 5); 

INSERT INTO Tasks (TaskID, [Task Description], [Priority Level], [Task Lead]) VALUES (1, 'UI', 1, 'Emon'), (2, 'Database', 2, 'Caleb'), (3, 'Robot', 3, 'Ryan'), (4, 'Marketing', 4, 'John'), (5,'Assemble parts', 3,'Robby');