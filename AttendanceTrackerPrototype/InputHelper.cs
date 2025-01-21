using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTrackerPrototype
{
    public static class InputHelper
    {

        public static string PromptAndClear(string prompt)
        {
            do
            {
                Console.Write(prompt); // Display the prompt
                string input = Console.ReadLine(); // Read the user's input

                // Clear the line after input
                int currentLine = Console.CursorTop - 1; // Get the current line
                Console.SetCursorPosition(0, currentLine); // Move cursor to the start of the line
                Console.Write(new string(' ', Console.WindowWidth)); // Overwrite the entire line with spaces
                Console.SetCursorPosition(0, currentLine); // Move the cursor back to the start of the cleared line

                if (!string.IsNullOrWhiteSpace(input))
                {


                    return input.Trim(); // Return trimmed input
                }
                else
                {
                    Console.Write("Incorrect input, try again. ");
                    continue;
                }

            } while (true);
        }
    }

}