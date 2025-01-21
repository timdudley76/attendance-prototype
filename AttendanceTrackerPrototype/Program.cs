using System;
using AttendanceTrackerPrototype;

//Written by Tim Dudley 2025

StudentRecord Student = new StudentRecord();


for (int i = 0; i < Shared.MaxRecords; i++)//Hard coding some records in (to be replaced by DB)
{
    switch (i)
    {
        case 0:
            Student.StudentId = "001";
            Student.StudentFirstName = "Dave";
            Student.StudentSurname = "Wilkins";
            Student.StudentGender = "Male";
            Student.YearGroup = "9";
            Student.IsDisadvantaged = "Yes";
            Student.IsSen = "No";
            Student.StudentAbsence = "13";
            Student.ActionsTaken = "";
            break;
        case 1:
            Student.StudentId = "002";
            Student.StudentFirstName = "Mary";
            Student.StudentSurname = "Gavin";
            Student.StudentGender = "Female";
            Student.YearGroup = "7";
            Student.IsDisadvantaged = "Yes";
            Student.IsSen = "Yes";
            Student.StudentAbsence = "56";
            Student.ActionsTaken = "Referral to Local Authority and parental meeting.";
            break;
        case 2:
            Student.StudentId = "003";
            Student.StudentFirstName = "Jenny";
            Student.StudentSurname = "Barker";
            Student.StudentGender = "Female";
            Student.YearGroup = "10";
            Student.IsDisadvantaged = "No";
            Student.IsSen = "No";
            Student.StudentAbsence = "20";
            Student.ActionsTaken = "Parental meeting";
            break;
        case 3:
            Student.StudentId = "004";
            Student.StudentFirstName = "Arthur";
            Student.StudentSurname = "Polowski";
            Student.StudentGender = "Male";
            Student.YearGroup = "9";
            Student.IsDisadvantaged = "Yes";
            Student.IsSen = "No";
            Student.StudentAbsence = "60";
            Student.ActionsTaken = "Parents not engaging";
            break;
        case 4:
            Student.StudentId = "005";
            Student.StudentFirstName = "Milly";
            Student.StudentSurname = "Tupple";
            Student.StudentGender = "Female";
            Student.YearGroup = "7";
            Student.IsDisadvantaged = "Yes";
            Student.IsSen = "No";
            Student.StudentAbsence = "40";
            Student.ActionsTaken = "Email sent.";
            break;
        case 5:
            Student.StudentId = "006";
            Student.StudentFirstName = "Dylan";
            Student.StudentSurname = "Templeton";
            Student.StudentGender = "Male";
            Student.YearGroup = "11";
            Student.IsDisadvantaged = "Yes";
            Student.IsSen = "No";
            Student.StudentAbsence = "65";
            Student.ActionsTaken = "Multiple meetings, attendance referral.";
            break;
        case 6:
            Student.StudentId = "007";
            Student.StudentFirstName = "Jas";
            Student.StudentSurname = "Singh";
            Student.StudentGender = "Female";
            Student.YearGroup = "8";
            Student.IsDisadvantaged = "No";
            Student.IsSen = "No";
            Student.StudentAbsence = "35";
            Student.ActionsTaken = "";
            break;
        default:
            Student.StudentId = "";
            Student.StudentFirstName = "";
            Student.StudentSurname = "";
            Student.StudentGender = "";
            Student.YearGroup = "";
            Student.IsDisadvantaged = "";
            Student.IsSen = "";
            Student.StudentAbsence = "";
            Student.ActionsTaken = "";
            break;

    }

    StudentRecord.StudentRecords[i, 0] = "StudentID: " + Student.StudentId;
    StudentRecord.StudentRecords[i, 1] = "First name: " + Student.StudentFirstName;
    StudentRecord.StudentRecords[i, 2] = "Surname: " + Student.StudentSurname;
    StudentRecord.StudentRecords[i, 3] = "Gender: " + Student.StudentGender;
    StudentRecord.StudentRecords[i, 4] = "Current year group: " + Student.YearGroup;
    StudentRecord.StudentRecords[i, 5] = "Is student disadvantaged?: " + Student.IsDisadvantaged;
    StudentRecord.StudentRecords[i, 6] = "Is student an SEN student?: " + Student.IsSen;
    StudentRecord.StudentRecords[i, 7] = "Current absence: " + Student.StudentAbsence;
    StudentRecord.StudentRecords[i, 8] = "What actions have been taken?: " + Student.ActionsTaken;

}

//Top level navigation
MenuHandler.MainMenu();







