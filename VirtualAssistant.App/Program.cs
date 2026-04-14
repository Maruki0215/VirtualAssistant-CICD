using System;
using VirtualAssistant.Services.Services;

namespace VirtualAssistant.App
{
    /// <summary>
    /// The main entry point for the Virtual Assistant application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main method that starts the application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            var authService = new AuthenticationService();

            const int testNumber = 100;
            const double pi = 3.14159;
            const int radius = 7;

            // This is safe - no division by zero
            int result = testNumber / 1;
            Console.WriteLine($"Result: {result}");

            // Correct comparison operator
            if (testNumber == 100)
            {
                Console.WriteLine("The value of n is 100.");
            }

            // Using named constant instead of magic number
            double area = pi * radius * radius;
            Console.WriteLine($"Area: {area}");

            // Call methods with proper error handling
            try
            {
                bool loginResult = authService.Login("admin", "admin123");
                Console.WriteLine($"Login result: {loginResult}");

                int countDiv = authService.GetUserCountDivider(1);
                Console.WriteLine($"Count divided: {countDiv}");

                bool exists = authService.CheckUserExists("admin");
                Console.WriteLine($"User exists: {exists}");

                double stats = authService.CalculateUserStats();
                Console.WriteLine($"Stats: {stats}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}