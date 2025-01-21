using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace AttendanceTrackerPrototype
{
    //Written by Tim Dudley 2025
    public class InterventionAlerts
    {
        public static void MissingNotes()
        {
            bool noMissingNotes = true;

            // Notify the user that the program is checking for missing notes
            Console.WriteLine("Checking for missing notes.\n");

            // Iterate through all student records
            for (int i = 0; i < Shared.MaxRecords; i++)
            {
                // Extract student details (ID, first name, and last name) using Substring
                string idNum = StudentRecord.StudentRecords[i, 0].Substring(11); // Extract student ID
                string firstName = StudentRecord.StudentRecords[i, 1].Substring(12); // Extract first name
                string lastName = StudentRecord.StudentRecords[i, 2].Substring(9); // Extract last name

                // Check if the student ID is not empty and the notes/actions column is empty
                if (!string.IsNullOrWhiteSpace(StudentRecord.StudentRecords[i, 0].Substring(11)) &&
                    string.IsNullOrWhiteSpace(StudentRecord.StudentRecords[i, 8].Substring(31)))
                {
                    if (noMissingNotes)
                    {
                        // Display header for matches
                        Console.WriteLine("The following students have missing notes.\n");
                    }
                    // Notify about the missing notes for the student
                    Console.WriteLine($"{firstName} {lastName} [ID: {idNum}].");

                    // Set the flag to indicate missing notes were found
                    noMissingNotes = false;
                }
            }

            // Optionally, handle the case when all records have notes

            if (noMissingNotes)
            {
                Console.WriteLine("No missing notes for existing records.");
            }
            else
            { 
                Console.WriteLine("\nPlease ensure you update the record with the latest information."); 
            }

        }

        public static void MissingMeetings()
        {
            Console.WriteLine("Checking for missing meetings.\n");
            bool headerDisplayed = false;

            // Loop through all student records in the array
            for (int i = 0; i < Shared.MaxRecords; i++)
            {
                // Extract relevant student details using Substring
                string idNum = StudentRecord.StudentRecords[i, 0].Substring(11); // Extract student ID
                string firstName = StudentRecord.StudentRecords[i, 1].Substring(12); // Extract first name
                string lastName = StudentRecord.StudentRecords[i, 2].Substring(9); // Extract last name

                // Check if the student record has a valid ID (not empty or whitespace)
                if (!string.IsNullOrWhiteSpace(StudentRecord.StudentRecords[i, 0].Substring(11)))
                {
                    // Split the notes/actions column into individual words
                    string[] checkMeetings = StudentRecord.StudentRecords[i, 8].Split(" ");
                    string[] wordsToCheck = { "meeting", "meetings" }; // Define the word we are looking for

                    bool meetingFound = false; // Flag to indicate if a meeting was found

                    // Iterate through each word in the notes/actions column
                    foreach (string word in checkMeetings)
                    {
                        // Remove any punctuation from the current word
                        string sanitisedWord = new string(word.Where(character => !char.IsPunctuation(character)).ToArray());

                        // Check if the sanitised word matches the target word (case-insensitive)
                        if (wordsToCheck.Any(word => word.Equals(sanitisedWord, StringComparison.OrdinalIgnoreCase)))
                        {
                            meetingFound = true; // Set the flag to true if a meeting is found
                            break; // Exit the loop early since a match is found
                        }
                    }

                    // If no meeting was found, print a message for the current student
                    if (!meetingFound)
                    {
                        if (!headerDisplayed)
                        {
                            // Display header for matches
                            Console.WriteLine("The following students have no meetings logged.\n");
                            headerDisplayed = true;
                        }
                        Console.WriteLine($"{firstName} {lastName} [ID: {idNum}].");
                    }

                }
            }
            if (headerDisplayed)
            {
                Console.WriteLine("\nPlease ensure you update the record with the latest information.");
            }
            else
            {
                Console.WriteLine("All students have meetings logged.");
            }

        }

        public static void ReferralLogs()
        {
            Console.WriteLine("Checking for referrals.\n");
            bool referralFound = false;
            bool referralHeader = false;
            // Loop through all student records in the array
            for (int i = 0; i < Shared.MaxRecords; i++)
            {
                // Extract relevant student details using Substring
                string idNum = StudentRecord.StudentRecords[i, 0].Substring(11); // Extract student ID
                string firstName = StudentRecord.StudentRecords[i, 1].Substring(12); // Extract first name
                string lastName = StudentRecord.StudentRecords[i, 2].Substring(9); // Extract last name

                // Check if the student record has a valid ID (not empty or whitespace)
                if (!string.IsNullOrWhiteSpace(StudentRecord.StudentRecords[i, 0].Substring(11)))
                {
                    // Split the notes/actions column into individual words
                    string[] checkMeetings = StudentRecord.StudentRecords[i, 8].Split(" ");
                    string wordToCheck = "referral"; // Define the word we are looking for

                    // Iterate through each word in the notes/actions column
                    foreach (string word in checkMeetings)
                    {
                        // Remove any punctuation from the current word
                        string sanitisedWord = new string(word.Where(c => !char.IsPunctuation(c)).ToArray());

                        // Check if the sanitised word matches the target word (case-insensitive)
                        if (sanitisedWord.Equals(wordToCheck, StringComparison.OrdinalIgnoreCase))
                        {
                            if (!referralHeader)
                            {
                                Console.WriteLine("Referrals have been made for the following students.");
                                referralHeader = true;
                            }
                            // If a match is found, print the student details and referral information
                            Console.WriteLine($"{firstName} {lastName} [ID: {idNum}].");
                            referralFound = true; // Mark that a referral was found
                        }
                    }
                }
            }

            if (!referralFound)
            {
                Console.WriteLine("No referrals have been made for students on record.");
            }
            Console.WriteLine();
        }

    }
}
