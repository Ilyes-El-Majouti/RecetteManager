using System;

namespace RecetteManager.Utils
{
    public static class ConsoleHelper
    {
        public static void PrintHeader(string title)
        {
            Console.Clear();
            Console.WriteLine($"=== {title} ===\n");
        }

        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        public static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Veuillez entrer une valeur non vide.");
            }
        }
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                    return result;

                Console.WriteLine("Veuillez entrer un nombre valide.");
            }
        }
    }
}