# Attendance Tracker Prototype

## Overview
The **Attendance Tracker Prototype** is a C# console application designed to manage student records, track attendance, and identify students requiring interventions. It serves as a prototype to demonstrate the use of basic C# programming concepts, file handling, and data validation.

## Features
- **Student Record Management**: Add, edit, and view student records.
- **Attendance Analysis**: Identify students based on absence percentages.
- **Vulnerable Student Reports**: Highlight disadvantaged or SEN (Special Educational Needs) students.
- **Meeting Logs**: Check for missing meeting notes in student records.
- **Intervention Alerts**: Generate alerts for students requiring attention based on specific criteria.

## Installation
1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/timdudley76/attendance-prototype.git
   ```
2. Open the solution in Visual Studio.
3. Build the solution to restore dependencies and ensure the application compiles successfully.
4. Run the application in the console.

## How to Use
1. **Add New Student Records**:
   - Input the required details such as name, year group, absence percentage, etc.
2. **View Records**:
   - Navigate through student records using the options provided in the console.
3. **Analyze Attendance**:
   - Enter an absence percentage to generate a list of students exceeding the threshold.
4. **Check for Missing Meeting Logs**:
   - Identify students who have no meeting notes recorded.
5. **Generate Intervention Alerts**:
   - Review and address alerts for students requiring support.

## Technologies Used
- **Programming Language**: C#
- **Framework**: .NET Core
- **IDE**: Visual Studio
- **Version Control**: Git and GitHub

## Folder Structure
```
AttendanceTrackerPrototype/
├── AttendanceReports.cs       # Handles attendance-related reports
├── InterventionAlerts.cs      # Generates alerts for student interventions
├── MenuHandler.cs             # Manages the application menu
├── Program.cs                 # Entry point of the application
├── StudentRecord.cs           # Represents the structure for student data
├── StudentRecordsManager.cs   # Handles CRUD operations for student records
```

## Future Enhancements
- Add a **Graphical User Interface (GUI)** for better usability.
- Implement a database (e.g., SQLite) for persistent data storage.
- Add user authentication for secure access to records.
- Enable exporting reports in **CSV** or **PDF** formats.

## License
This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

## Acknowledgments
- **Visual Studio**: For providing a robust development environment.
- **GitHub**: For hosting and version control.
- **Microsoft Documentation**: For detailed references and guidance on C# and .NET.
