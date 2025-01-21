using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTrackerPrototype
{
    //Written by Tim Dudley 2025

    public static class Shared
    {
        public const int MaxRecords = 8; // Maximum records constant
    }
    public class StudentRecord
    {
        public static string[,] StudentRecords = new string[Shared.MaxRecords, 9];

        public string StudentId { get; set; } = "";
        public string StudentFirstName { get; set; } = "";
        public string StudentSurname { get; set; } = "";
        public string StudentGender { get; set; } = "";
        public string YearGroup { get; set; } = "";
        public string IsDisadvantaged { get; set; } = "";
        public string ActionsTaken { get; set; } = "";
        public string IsSen { get; set; } = "";
        public string StudentAbsence { get; set; } = "";
    }
}
