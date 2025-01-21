using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTrackerPrototype
{
    //Written by Tim Dudley 2025
    public class StudentRecordsManager
    {
        // Method to view all records
        public static void ViewAllRecords()
        {
            int currentIndex = 0;

            while (true)
            {
                Console.Clear();
                MenuHandler.RenderStudentRecordsMenuHeader(); // Render menu header

                // Check if a record exists at the current index
                if (!string.IsNullOrWhiteSpace(StudentRecord.StudentRecords[currentIndex, 0].Substring(11)))
                {
                    Console.WriteLine($"Viewing record number {currentIndex + 1}.\n");

                    // Display all fields for the record
                    for (int j = 0; j < 9; j++)
                    {
                        Console.WriteLine(StudentRecord.StudentRecords[currentIndex, j]?.ToString() ?? "");
                    }
                }
                else
                {
                    Console.WriteLine($"No record found at index position {currentIndex + 1}.");
                }

                // User navigation options
                Console.WriteLine("\nOptions: [N]ext, [P]revious, [E]xit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine()?.ToLower();

                // Handle user navigation
                switch (input)
                {
                    case "n": // Next record
                        if (currentIndex < Shared.MaxRecords - 1)
                        {
                            currentIndex++;
                        }
                        else
                        {
                            Console.WriteLine("You are already at the last record.");
                            Console.ReadKey();
                        }
                        break;

                    case "p": // Previous record
                        if (currentIndex > 0)
                        {
                            currentIndex--;
                        }
                        else
                        {
                            Console.WriteLine("You are at the first record.");
                            Console.ReadKey();
                        }
                        break;

                    case "e": // Exit
                        Console.WriteLine("\nExiting the record viewer.");
                        return;

                    default: // Invalid input
                        Console.WriteLine("You entered an invalid character. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Method to add a new record
        public static void NewRecord()
        {
            StudentRecord student = new StudentRecord();

            Console.WriteLine("Enter details for a new record.\n");

            // Count the number of existing records
            int currentNumRecords = 0;
            for (int i = 0; i < Shared.MaxRecords; i++)
            {
                if (!string.IsNullOrWhiteSpace(StudentRecord.StudentRecords[i, 0]?.Substring(11)))
                {
                    currentNumRecords++;
                }
            }

            // Check if max records are reached
            if (currentNumRecords >= Shared.MaxRecords)
            {
                Console.WriteLine("Error: Maximum number of records reached. Cannot add a new record.");
                Console.WriteLine("Press any key to return to the Student Records menu.");
                Console.ReadKey();
                return;
            }

            int newRecordIndex = currentNumRecords;
            student.StudentId = "00" + (newRecordIndex + 1).ToString(); // Generate new ID

            // Input validation for each field
            student.StudentFirstName = PromptInput("First name: ");
            student.StudentSurname = PromptInput("Surname: ");
            student.StudentGender = PromptInput("Gender (Male/Female): ", new[] { "male", "female" });
            student.YearGroup = PromptRangeInput("Year group (7-11): ", 7, 11);
            student.IsDisadvantaged = PromptInput("Is the student disadvantaged? (Yes/No): ", new[] { "yes", "no" });
            student.IsSen = PromptInput("Does the student have a need? (Yes/No): ", new[] { "yes", "no" });
            student.StudentAbsence = PromptRangeInput("Student's absence (0 - 100): ", 0, 100);
            student.ActionsTaken = PromptInput("Actions taken: ");

            Console.Write("\nSave the entered information? (Yes/No): ");
            string input = Console.ReadLine()?.ToLower();

            if (input == "yes")
            {
                // Save record to the array
                StudentRecord.StudentRecords[newRecordIndex, 0] = "StudentID: " + student.StudentId;
                StudentRecord.StudentRecords[newRecordIndex, 1] = "First name: " + student.StudentFirstName;
                StudentRecord.StudentRecords[newRecordIndex, 2] = "Surname: " + student.StudentSurname;
                StudentRecord.StudentRecords[newRecordIndex, 3] = "Gender: " + student.StudentGender;
                StudentRecord.StudentRecords[newRecordIndex, 4] = "Current year group: " + student.YearGroup;
                StudentRecord.StudentRecords[newRecordIndex, 5] = "Is student disadvantaged?: " + student.IsDisadvantaged;
                StudentRecord.StudentRecords[newRecordIndex, 6] = "Is student an SEN student?: " + student.IsSen;
                StudentRecord.StudentRecords[newRecordIndex, 7] = "Current absence: " + student.StudentAbsence;
                StudentRecord.StudentRecords[newRecordIndex, 8] = "What actions have been taken?: " + student.ActionsTaken;

                Console.WriteLine("\nStudent information successfully entered.");
            }
            else
            {
                Console.WriteLine("\nStudent information entry cancelled.");
            }
        }

        // Method to edit an existing record
        public static void EditRecord()
        {
            Console.WriteLine("Showing current students on record.\n");

            // Display all student records
            for (int i = 0; i < Shared.MaxRecords; i++)
            {
                if (!string.IsNullOrWhiteSpace(StudentRecord.StudentRecords[i, 0]?.Substring(11)))
                {
                    Console.WriteLine(
                        $"{StudentRecord.StudentRecords[i, 0].Substring(11)} " +
                        $"{StudentRecord.StudentRecords[i, 1].Substring(12)} " +
                        $"{StudentRecord.StudentRecords[i, 2].Substring(9)}"
                    );
                }
            }

            Console.Write("\nEnter the ID number of the record to edit: ");
            string retrieveID = Console.ReadLine();
            Console.Clear();
            MenuHandler.RenderStudentRecordsMenuHeader();

            Console.WriteLine($"Editing record with ID: {retrieveID}\n");
            for (int i = 0; i < Shared.MaxRecords; i++)
            {
                if (StudentRecord.StudentRecords[i, 0].Substring(11) == retrieveID)
                {
                    // Display fields for editing
                    for (int j = 1; j < 9; j++)
                    {
                        Console.WriteLine($"{j} - {StudentRecord.StudentRecords[i, j]}");
                    }

                    Console.Write("\nEnter the number of the field to edit (1-8): ");
                    string fieldToEdit = Console.ReadLine();
                    Console.Write("Enter the new value: ");
                    string newValue = Console.ReadLine();

                    switch (fieldToEdit)
                    {
                        case "1":
                            StudentRecord.StudentRecords[i, 1] = "First name: " + newValue;
                            break;
                        case "2":
                            StudentRecord.StudentRecords[i, 2] = "Surname: " + newValue;
                            break;
                            // Add remaining cases...
                    }

                    Console.WriteLine("\nRecord updated successfully.");
                    break;
                }
            }
        }

        // Helper method for prompting input with validation
        private static string PromptInput(string prompt, string[] validValues = null)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.ToLower();
                if (!string.IsNullOrWhiteSpace(input) && (validValues == null || validValues.Contains(input)))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        // Helper method for prompting a range input
        private static string PromptRangeInput(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                {
                    return value.ToString();
                }

                Console.WriteLine($"Invalid input. Please enter a value between {min} and {max}.");
            }
        }
    }
}
