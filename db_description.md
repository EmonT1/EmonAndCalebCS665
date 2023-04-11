**Database Description**
In our project the database we designed and used was an employee timecard management database
In this database there are 4 tables which have at least 4 fields (Columns) each and are as follows:
1. Employees:
    - EID (Primary Key)
    - First Name 
    - Last Name 
    - Department
2. TimeCards:
    - TCID  (Primary Key)
    - EmployeeID (Foreign Key)
    - WeekEndingDate
    - Total Hours
3. Time Entries:
    - TEID (Primary Key)
    - TimeCardID (Foreign Key)
    - Date
    - Start Time 
    - End Time
    - TaskID (Foreign Key)
4. Tasks
    - TaskID (Primary Key)
    - Task Description 

It is important to not that all tables are in 3NF and the functional dependencies for each table are:
Employees: 
EID -> First Name, Last Name, Department

TimeCards:
TCID -> EmployeeID, WeekEndingDate, TotalHours

TimeEntries:
TEID -> TimeCardID, Date, Start Time, End Time, TaskID

Tasks:
TaskID -> TaskDescription 

Some example rows for each Table
Employees:
| EID     | First Name    | Last Name     | Department  |
| :--     | :--           | :--           | :--         |
| 1       | Caleb         | Miller        | Development |
| 2       | Cord          | Gross         | R&D         |

TimeCards 
| TCID    | EmployeeID    | WeekEndingDate    | Total Hours | 
| :--     | :--           | :--               | :--         |
| 1       | 1             | '4/11/2023'       | 20          |
| 2       | 2             | '4/11/2023'       | 40          |

Time Entries
|   TEID    |   TimeCardID  |   Date        |   Start Time  |   End Time    |   TaskID  |
|   :--     |   :--         |   :--         |   :--         |   :--         |   :--     |
|   1       |   1           |   '4/11/2023' |   '9:15'      |   '3:00'      |   2       |
|   2       |   2           |   '4/11/2023' |   '9:15'      |   '5:00'      |   1       |

Tasks
|   TaskID  |   Taskdescription |
|   :--     |   :--             |
|   1       |   'programming'   |
|   2       |   'Research'      |




