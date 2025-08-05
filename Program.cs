using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the simple C# calculator!");
            Console.WriteLine("Enter the first number:");
            int a = Numcheck(Console.ReadLine()); // Get and validate the first number

            Console.WriteLine("Enter the second number:");
            int b = Numcheck(Console.ReadLine()); // Get and validate the second number

            Console.WriteLine("Please choose an option (+, -, *, /):");
            string option = CheckOption(Console.ReadLine()); // Get and validate the operation

            double result = 0;

            switch (option)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    if (b != 0)
                    {
                        result = (double)a / b; // Cast to double for accurate division
                    }
                    else
                    {
                        Console.WriteLine("Dividing by zero is not allowed!!!");
                        return; // Exit the program or the current calculation
                    }
                    break;
                default:
                    Console.WriteLine("An unexpected error occurred with the option.");
                    return; // Exit the program
            }

            Console.WriteLine($"Result: {a} {option} {b} = {result}");
        }

        // Check and validate the operation (+, -, *, /)
        static string CheckOption(string option)
        {
            // Use a regex pattern to check for a single valid character
            string pattern = @"^[+\-*/]$";

            while (!Regex.IsMatch(option, pattern))
            {
                Console.WriteLine("Please choose a valid option (+, -, *, /):");
                option = Console.ReadLine();
            }
            return option;
        }

        // Check and validate the number input
        static int Numcheck(string input)
        {
            string pattern = @"^-?\d+$"; // Pattern now handles negative numbers as well

            while (!Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("Please enter a valid number:");
                input = Console.ReadLine();
            }
            return Convert.ToInt32(input);
        }
    }
}