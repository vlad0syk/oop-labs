using Task.Models;

namespace Task;

public class Program 
{
    static void Main(string[] args) 
    {
        while (true)
        {
            Console.Clear();
            Greeting();
            Console.WriteLine("1. Calculation of the expression p = a*x^5 - 1 / b*x^4 + c*x + d and output of personal data");
            Console.WriteLine("2. Calculation of the expression x = √((a-b)/a + |sin(a)/cos(b)|)");
            Console.WriteLine("3. Calculation of the function f(x)");
            Console.WriteLine("4. Output of the month name");
            Console.WriteLine("5. Calculation of the product of the first n terms of the series");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Choose a task (0-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    Task5();
                    break;
                case "0":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void Greeting()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("     📘 Laboratory Work No. 1");
        Console.WriteLine("===========================================");
        Console.WriteLine("💻 Performed by: Vlad Sapozhnyk (8)");
        Console.WriteLine("🎓 Taras Shevchenko National University of Kyiv");
        Console.WriteLine("🏫 Group: IPZ-13, Subgroup: 6");
        Console.WriteLine("===========================================");
    }

    #region Tasks

    static void Task1() 
    {
        Console.Clear();
        Console.WriteLine("=== Task 1: Personal data and expression calculation ===\n");

        User user = new User();

        Console.Write("Enter your surname: ");
        user.LastName = Console.ReadLine();

        Console.Write("Enter your name: ");
        user.FirstName = Console.ReadLine();

        user.Age = ReadInt("Enter your age: ");

        Console.Write("Enter your group: ");
        user.Group = Console.ReadLine();

        user.Course = ReadInt("Enter your course: ");

        Console.Write("Enter your email: ");
        user.Email = Console.ReadLine();

        Console.Clear();

        Console.WriteLine("\n--- Personal data ---");
        Console.WriteLine($"Surname: {user.LastName}");
        Console.WriteLine($"Name: {user.FirstName}");
        Console.WriteLine($"Age: {user.Age}");
        Console.WriteLine($"Group: {user.Group}");
        Console.WriteLine($"Course: {user.Course}");
        Console.WriteLine($"E-mail: {user.Email}");

        Console.WriteLine("\n--- Calculation of the expression p = a*x^5 - 1 / b*x^4 + c*x + d ---");
            
        double a = ReadDouble("Enter the value of a: ");
        double b = ReadDouble("Enter the value of b: ");
        double c = ReadDouble("Enter the value of c: ");
        double d = ReadDouble("Enter the value of d: ");
        double x = ReadDouble("Enter the value of x: ");

        double numerator = a * Math.Pow(x, 5) - 1;
        double denominator = b * Math.Pow(x, 4) + c * x + d;

        if (Math.Abs(denominator) < 1e-10)
        {
            Console.WriteLine("\nError: division by zero!");
        }
        else
        {
            double p = numerator / denominator;
            Console.WriteLine($"\nResult: p = {p:F4}");
        }
    }

    static void Task2() 
    {
        Console.Clear();
        Console.WriteLine("=== Task 2: Calculation of the expression x = √((a-b)/a + |sin(a)/cos(b)|) ===\n");

        double a = ReadDouble("Enter the value of a: ");
        double b = ReadDouble("Enter the value of b: ");

        if (Math.Abs(a) < 1e-10)
        {
            Console.WriteLine("\nError: a cannot be zero (division by zero)!");
            return;
        }

        if (Math.Abs(Math.Cos(b)) < 1e-10)
        {
            Console.WriteLine("\nError: cos(b) = 0 (division by zero)!");
            return;
        }

        double part1 = (a - b) / a;
        double part2 = Math.Abs(Math.Sin(a) / Math.Cos(b));
        double underRoot = part1 + part2;

        if (underRoot < 0)
        {
            Console.WriteLine("\nError: the value under the square root is negative!");
            return;
        }

        double x = Math.Sqrt(underRoot);

        Console.WriteLine($"\n--- Results ---");
        Console.WriteLine($"(a - b) / a = {part1:F4}");
        Console.WriteLine($"|sin(a) / cos(b)| = {part2:F4}");
        Console.WriteLine($"Value under the square root = {underRoot:F4}");
        Console.WriteLine($"x = {x:F4}");
    }

    static void Task3() 
    {
        Console.Clear();
        Console.WriteLine("=== Task 3: Calculation of the function f(x) ===\n");
        Console.WriteLine("f(x) = { x² + 4,  x > 0");
        Console.WriteLine("       { x - 5,   x < 0");
        Console.WriteLine("       { 0,       x = 0\n");

        double x = ReadDouble("Enter the value of x: ");

        double result;

        if (x > 0)
        {
            result = x * x + 4;
            Console.WriteLine($"\nSince x > 0, the formula f(x) = x² + 4 is used");
        }
        else if (x < 0)
        {
            result = x - 5;
            Console.WriteLine($"\nSince x < 0, the formula f(x) = x - 5 is used");
        }
        else
        {
            result = 0;
            Console.WriteLine($"\nSince x = 0, f(x) = 0");
        }

        Console.WriteLine($"f({x}) = {result:F4}");
    }

    static void Task4() 
    {
        Console.Clear();
        Console.WriteLine("=== Task 4: Displaying the name of the month ===\n");

        int month;
        while (true)
        {
            Console.Write("Enter the ordinal number of the month (1-12): ");
            if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
                break;
            Console.WriteLine("Invalid input. Please enter a number from 1 to 12.");
        }

        string monthName;

        switch (month)
        {
            case 1:
                monthName = "January";
                break;
            case 2:
                monthName = "February";
                break;
            case 3:
                monthName = "March";
                break;
            case 4:
                monthName = "April";
                break;
            case 5:
                monthName = "May";
                break;
            case 6:
                monthName = "June";
                break;
            case 7:
                monthName = "July";
                break;
            case 8:
                monthName = "August";
                break;
            case 9:
                monthName = "September";
                break;
            case 10:
                monthName = "October";
                break;
            case 11:
                monthName = "November";
                break;
            case 12:
                monthName = "December";
                break;
            default:
                monthName = "";
                break;
        }

        Console.WriteLine($"\nMonth №{month}: {monthName}");
    }

    static void Task5() 
    {
        Console.Clear();
        Console.WriteLine("=== Task 5: Calculation of the product ∏(k+1)/k ===\n");
        Console.WriteLine("Formula: ∏(k+1)/k from k=1 to n\n");

        int n;
        while (true)
        {
            Console.Write("Enter a natural number n: ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                break;
            Console.WriteLine("Invalid input. Please enter a natural number (n > 0).");
        }

        double product = 1.0;

        Console.WriteLine("\n--- Step-by-step calculation ---");
        for (int k = 1; k <= n; k++)
        {
            double term = (double)(k + 1) / k;
            product *= term;
            Console.WriteLine($"k = {k}: ({k + 1}/{k}) = {term:F4}, intermediate product = {product:F4}");
        }

        Console.WriteLine($"\n--- Result ---");
        Console.WriteLine($"∏(k+1)/k from k=1 to {n} = {product:F6}");
    }
        
    #endregion

    #region Helper methods

    static double ReadDouble(string prompt)
    {
        double result;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out result))
                return result;
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static int ReadInt(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result))
                return result;
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
    
    #endregion

}