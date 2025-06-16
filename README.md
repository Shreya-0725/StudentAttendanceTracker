# StudentAttendanceTracker
A simple ASP.NET Web Forms application to mark and track student attendance using a dropdown, checkbox, and GridView, connected to a SQL Server database.

## Features
- Dropdown to select students
- Date input to select attendance date
- Checkbox to mark Present or Absent
- GridView to display all attendance records

## Technologies Used
- ASP.NET Web Forms (C#)
- SQL Server
- ADO.NET

## Database Structure

### Students Table (already created)
- ID (int, Primary Key)
- Name (nvarchar)
- Age (int)

### Attendance Table
```sql
CREATE TABLE Attendance (
    ID INT PRIMARY KEY IDENTITY,
    StudentID INT FOREIGN KEY REFERENCES Students(ID),
    AttendanceDate DATE,
    Status VARCHAR(10)
);
