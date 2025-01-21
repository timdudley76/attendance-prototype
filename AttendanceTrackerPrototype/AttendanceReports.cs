using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTrackerPrototype
{
    //Written by Tim Dudley 2025
    public class AttendanceReports
    {
        // Method to search records by percentage absence
        public static void AbsencePercentages()
        {
            int userPercentage = 0;
            bool validInput = false;

            do
            {
                Console.WriteLine("Search student by percentage (absence).\n");
                Console.Write("Enter the percentage number without the % character: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userPercentage)) // Validate user input as an integer
                {
                    validInput = true;
                }
                else
                {
                    // Error handling for invalid input
                    Console.WriteLine("Invalid input. Please enter a number only. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuHandler.RenderAttendanceReportsMenuHeader(); // Re-render the menu header
                }
            } while (!validInput);

            bool attendanceMatch = false; // Flag to track if any matches are found
            for (int i = 0; i < Shared.MaxRecords; i++)
            {
                // Extract relevant fields from student records
                string idNum = StudentRecord.StudentRecords[i, 0].Substring(11);
                string firstName = StudentRecord.StudentRecords[i, 1].Substring(12);
                string lastName = StudentRecord.StudentRecords[i, 2].Substring(9);

                if (!string.IsNullOrWhiteSpace(idNum))
                {
                    int checkAbsence = int.Parse(StudentRecord.StudentRecords[i, 7].Substring(17)); // Parse absence percentage

                    if (checkAbsence > userPercentage)
                    {
                        if (!attendanceMatch)
                        {
                            // Display header if matches are found
                            Console.WriteLine($"\nShowing students who have absence over {userPercentage}%:\n");
                        }

                        Console.WriteLine($"{firstName} {lastName} [ID: {idNum}]");
                        attendanceMatch = true;
                    }
                }
            }

            if (!attendanceMatch)
            {
                // If no matches are found
                Console.WriteLine($"No students have over {userPercentage}% absence.");
            }

            Console.WriteLine();
        }

        // Method to display students who are vulnerable (SEN or disadvantaged)
        public static void VulnerableStudents()
        {
            Console.WriteLine("Vulnerable students as defined by SEN or Disadvantaged.");
            bool vulnerableMatch = false;

            for (int i = 0; i < Shared.MaxRecords; i++)
            {
                if (!string.IsNullOrWhiteSpace(StudentRecord.StudentRecords[i, 0].Substring(11)))
                {
                    // Extract fields and convert to lowercase for comparison
                    string idNum = StudentRecord.StudentRecords[i, 0].Substring(11);
                    string firstName = StudentRecord.StudentRecords[i, 1].Substring(12);
                    string lastName = StudentRecord.StudentRecords[i, 2].Substring(9);
                    string isDisadvantaged = StudentRecord.StudentRecords[i, 5].Substring(27).ToLower();
                    string isSEN = StudentRecord.StudentRecords[i, 6].Substring(28).ToLower();

                    // List to collect labels for vulnerabilities
                    List<string> labels = new List<string>();
                    if (isDisadvantaged == "yes") labels.Add("DA");
                    if (isSEN == "yes") labels.Add("SEN");

                    if (labels.Any())
                    {
                        // Output student info with vulnerabilities
                        Console.WriteLine($"{firstName} {lastName} [{string.Join(", ", labels)}].");
                        vulnerableMatch = true;
                    }
                }
            }

            if (!vulnerableMatch)
            {
                // If no vulnerable students are found
                Console.WriteLine("There are no students classed as SEN or Disadvantaged.");
            }

            Console.WriteLine();
        }

        // Method to search students by year group
        public static void StudentsYearGroup()
        {
            int userYearGroup = 0;
            bool validInput = false;
            Console.WriteLine("Search students by a year group.\n");

            do
            {
                Console.Write("Enter the year group by number (7-11): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userYearGroup)) // Validate input as integer
                {
                    if (userYearGroup >= 7 && userYearGroup <= 11) // Ensure year group is in range
                    {
                        validInput = true;
                    }
                    else
                    {
                        // Error for out-of-range input
                        Console.WriteLine("Incorrect input. Must be a number between 7 and 11. Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        MenuHandler.RenderAttendanceReportsMenuHeader();
                    }
                }
                else
                {
                    // Error for invalid input
                    Console.WriteLine("Invalid input. Please enter a number only. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuHandler.RenderAttendanceReportsMenuHeader();
                }
            } while (!validInput);

            bool yearGroupMatch = false; // Flag for matching year group
            for (int i = 0; i < Shared.MaxRecords; i++)
            {
                // Extract student data
                string idNum = StudentRecord.StudentRecords[i, 0].Substring(11);
                string firstName = StudentRecord.StudentRecords[i, 1].Substring(12);
                string lastName = StudentRecord.StudentRecords[i, 2].Substring(9);

                if (!string.IsNullOrWhiteSpace(idNum))
                {
                    int checkYearGroup = int.Parse(StudentRecord.StudentRecords[i, 4].Substring(20)); // Parse year group

                    if (checkYearGroup == userYearGroup)
                    {
                        if (!yearGroupMatch)
                        {
                            // Display header for matches
                            Console.WriteLine($"\nShowing students from year {userYearGroup}\n");
                        }

                        Console.WriteLine($"{firstName} {lastName} [ID: {idNum}]");
                        yearGroupMatch = true;
                    }
                }
            }

            if (!yearGroupMatch)
            {
                // If no matches are found
                Console.WriteLine($"There are no students from year {userYearGroup}.");
            }
            Console.WriteLine();
        }
    }

}
