using System;

namespace CarRentalSystem.Common
{
    // ---------- INPUT HELPERS (replace cin >> ) ----------
    // Moved unchanged from Program.cs. Every UI class shares ONE input buffer,
    // so these helpers must live in a single shared place.
    // cin >> reads one word at a time (stops at spaces). These helpers do the same.
    public static class ConsoleInput
    {
        static string inputBuffer = "";

        public static string ReadWord()
        {
            while (inputBuffer.Trim().Length == 0)
                inputBuffer = Console.ReadLine();

            inputBuffer = inputBuffer.TrimStart();

            int end = 0;
            while (end < inputBuffer.Length && !char.IsWhiteSpace(inputBuffer[end]))
                end++;

            string word = inputBuffer.Substring(0, end);
            inputBuffer = inputBuffer.Substring(end);
            return word;
        }

        public static int ReadInt()
        {
            return Convert.ToInt32(ReadWord());
        }
    }
}
