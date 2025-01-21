using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTrackerPrototype
{
    //Written by Tim Dudley 2025
    public class MenuHandler
    {

        public static void MainMenu()//Main Menu
        {
            string menuSelection = "";
            string? readResult;

            do
            {
                RenderMainMenuHeader();

                readResult = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(readResult))
                {
                    menuSelection = readResult.ToLower().Trim();
                }

                switch (menuSelection)
                {
                    case "1":
                        StudentRecordsMenu();
                        break;
                    case "2":
                        AttendanceReportsMenu();
                        break;
                    case "3":
                        InterventionsAlertsMenu();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
            while (menuSelection != "4");
        }

        private static void RenderMainMenuHeader()
        {
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("Attendance Tracker Prototype v1.0");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine();

            Console.WriteLine("1 - Student Records Menu.");
            Console.WriteLine("2 - Attendance Reports Menu.");
            Console.WriteLine("3 - Intervention Alerts.");
            Console.WriteLine("4 - Exit the program.");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
        }

        public static void StudentRecordsMenu()//Student records menu
        {
            string menuSubSelection = "";

            do
            {
                RenderStudentRecordsMenuHeader();
                Console.Write("Enter your choice: ");
                menuSubSelection = Console.ReadLine();

                switch (menuSubSelection)
                {
                    case "1":
                        Console.Clear();
                        RenderStudentRecordsMenuHeader();
                        StudentRecordsManager.ViewAllRecords();
                        Console.WriteLine("Press any key to return to the Student Records menu.");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        RenderStudentRecordsMenuHeader();
                        StudentRecordsManager.NewRecord();
                        Console.WriteLine("Press any key to return to the Student Records menu.");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        RenderStudentRecordsMenuHeader();
                        StudentRecordsManager.EditRecord();
                        Console.WriteLine("Press any key to return to the Student Records menu.");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("Returning to main menu...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
            while (menuSubSelection != "4");
        }


        public static void RenderStudentRecordsMenuHeader()
        {
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("Attendance Tracker Prototype v1.0");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.WriteLine("Main Menu | Student Records Menu");
            Console.WriteLine();
            Console.WriteLine("1 - View all records.");
            Console.WriteLine("2 - Add a new record.");
            Console.WriteLine("3 - Edit a record.");
            Console.WriteLine("4 - Return to main menu.");
            Console.WriteLine();

            
        }

        public static void AttendanceReportsMenu()//Attendance Reports Menu
        {
            string menuSubSelection = "";

            do
            {
                RenderAttendanceReportsMenuHeader();
                Console.Write("Enter your choice: ");
                menuSubSelection = Console.ReadLine();

                switch (menuSubSelection)
                {
                    case "1":
                        Console.Clear();
                        RenderAttendanceReportsMenuHeader();
                        AttendanceReports.AbsencePercentages();
                        Console.WriteLine("Press any key to return to the Student Records menu.");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        RenderAttendanceReportsMenuHeader();
                        AttendanceReports.VulnerableStudents();
                        Console.WriteLine("Press any key to return to the Student Records menu.");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        RenderAttendanceReportsMenuHeader();
                        AttendanceReports.StudentsYearGroup();
                        Console.WriteLine("Press any key to return to the Student Records menu.");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Returning to main menu...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
            while (menuSubSelection != "4");
        }


        public static void RenderAttendanceReportsMenuHeader()
        {
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("Attendance Tracker Prototype v1.0");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.WriteLine("Main Menu | Attendance Reports");
            Console.WriteLine();
            Console.WriteLine("1 - Absence by percentage.");
            Console.WriteLine("2 - Current vulnerable students.");
            Console.WriteLine("3 - Search by a year group.");
            Console.WriteLine("4 - Return to main menu.");
            Console.WriteLine();


        }


        public static void InterventionsAlertsMenu()//Intervention alerst menu
        {
            string menuSubSelection = "";

            do
            {
                RenderInterventionsAlertsMenuHeader();
                Console.Write("Enter your choice: ");
                menuSubSelection = Console.ReadLine();

                switch (menuSubSelection)
                {
                    case "1":
                        Console.Clear();
                        RenderInterventionsAlertsMenuHeader();
                        InterventionAlerts.MissingNotes();
                        Console.WriteLine("Press any key to return to the Student Records menu.");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        RenderInterventionsAlertsMenuHeader();
                        InterventionAlerts.MissingMeetings();
                        Console.WriteLine("Press any key to return to the Student Records menu.");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        RenderInterventionsAlertsMenuHeader();
                        InterventionAlerts.ReferralLogs();
                        Console.WriteLine("Press any key to return to the Student Records menu.");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Returning to main menu...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
            while (menuSubSelection != "4");
        }


        public static void RenderInterventionsAlertsMenuHeader()
        {
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("Attendance Tracker Prototype v1.0");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.WriteLine("Main Menu | Interventions Alerts");
            Console.WriteLine();
            Console.WriteLine("1 - Check for missing notes.");
            Console.WriteLine("2 - Check for no meetings.");
            Console.WriteLine("3 - Check for referrals made.");
            Console.WriteLine("4 - Return to main menu.");
            Console.WriteLine();


        }
    }
}

