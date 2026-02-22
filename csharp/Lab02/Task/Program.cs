using System;

namespace Task;

public class Program 
{
    static int[] generatedArray;
    static int[,] matrix;
    static Random rand = new Random();

    static void Main(string[] args) 
    {
        while (true)
        {
            Console.Clear();
            Greeting();
            Console.WriteLine("1. Array generation and Quick Sort (descending)");
            Console.WriteLine("2. Find primes in array (Sieve of Eratosthenes)");
            Console.WriteLine("3. Count repetitions using linear search");
            Console.WriteLine("4. Find min and max in array using linear search");
            Console.WriteLine("5. Binary search in array");
            Console.WriteLine("6. Matrix generation and sum of row/col");
            Console.WriteLine("7. Find min and max in matrix using Math methods");
            Console.WriteLine("8. Roots of nonlinear equation (Bisection method)");
            Console.WriteLine("9. String operations (find, replace, insert, delete)");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Choose a task (0-9): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": Task1(); break;
                case "2": Task2(); break;
                case "3": Task3(); break;
                case "4": Task4(); break;
                case "5": Task5(); break;
                case "6": Task6(); break;
                case "7": Task7(); break;
                case "8": Task8(); break;
                case "9": Task9(); break;
                case "0": Console.WriteLine("Goodbye!"); return;
                default: Console.WriteLine("Invalid choice!"); break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void Greeting()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("     📘 Laboratory Work No. 2");
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
        Console.WriteLine("=== Task 1: Array Generation and Quick Sort (Descending) ===\n");
        int n = ReadInt("Enter number of elements (N): ", 1, 100000);
        generatedArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            generatedArray[i] = rand.Next(-100, 101); // Random values from -100 to 100
        }
        Console.WriteLine("\nArray before sorting:");
        PrintArray(generatedArray);

        QuickSortDescending(generatedArray, 0, n - 1);

        Console.WriteLine("\nArray after sorting (Descending):");
        PrintArray(generatedArray);
    }

    static void Task2()
    {
        Console.Clear();
        Console.WriteLine("=== Task 2: Find primes in array (Sieve of Eratosthenes) ===\n");
        if (generatedArray == null) { Console.WriteLine("Please generate array in Task 1 first."); return; }

        int a = ReadInt("Enter range start (A): ");
        int b = ReadInt("Enter range end (B): ");
        
        if (a > b) { int temp = a; a = b; b = temp; }

        int maxVal = b; 
        foreach (int val in generatedArray)
        {
            if (val > maxVal) maxVal = val;
        }

        if (maxVal < 2)
        {
            Console.WriteLine("No prime numbers possible in this range/array.");
            return;
        }

        bool[] isPrime = new bool[maxVal + 1];
        for (int i = 2; i <= maxVal; i++) isPrime[i] = true;

        for (int p = 2; p * p <= maxVal; p++)
        {
            if (isPrime[p])
            {
                for (int i = p * p; i <= maxVal; i += p)
                    isPrime[i] = false;
            }
        }

        Console.WriteLine($"\nPrime numbers from the array that fall in the range [{a}, {b}]:");
        bool foundAny = false;
        foreach (int val in generatedArray)
        {
            if (val >= a && val <= b && val >= 2 && isPrime[val])
            {
                Console.Write(val + " ");
                foundAny = true;
            }
        }
        if (!foundAny) Console.WriteLine("None");
        else Console.WriteLine();
    }

    static void Task3()
    {
        Console.Clear();
        Console.WriteLine("=== Task 3: Count repetitions using linear search ===\n");
        if (generatedArray == null) { Console.WriteLine("Please generate array in Task 1 first."); return; }

        bool[] visited = new bool[generatedArray.Length];
        for (int i = 0; i < generatedArray.Length; i++)
        {
            if (visited[i]) continue;
            int count = 1;
            for (int j = i + 1; j < generatedArray.Length; j++)
            {
                if (generatedArray[i] == generatedArray[j])
                {
                    count++;
                    visited[j] = true;
                }
            }
            Console.WriteLine($"Element {generatedArray[i],4} repeats {count} times.");
        }
    }

    static void Task4()
    {
        Console.Clear();
        Console.WriteLine("=== Task 4: Find min and max using linear search ===\n");
        if (generatedArray == null || generatedArray.Length == 0) { Console.WriteLine("Please generate array in Task 1 first."); return; }

        int min = generatedArray[0], minIdx = 0;
        int max = generatedArray[0], maxIdx = 0;

        for (int i = 1; i < generatedArray.Length; i++)
        {
            if (generatedArray[i] < min)
            {
                min = generatedArray[i];
                minIdx = i;
            }
            if (generatedArray[i] > max)
            {
                max = generatedArray[i];
                maxIdx = i;
            }
        }

        Console.WriteLine($"Minimum element: {min} at index {minIdx}");
        Console.WriteLine($"Maximum element: {max} at index {maxIdx}");
    }

    static void Task5()
    {
        Console.Clear();
        Console.WriteLine("=== Task 5: Binary search in array ===\n");
        if (generatedArray == null || generatedArray.Length == 0) { Console.WriteLine("Please generate array in Task 1 first."); return; }

        int target = ReadInt("Enter the element to search for: ");

        // Custom Binary Search
        int left = 0, right = generatedArray.Length - 1;
        int customIndex = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (generatedArray[mid] == target)
            {
                customIndex = mid;
                break; // found
            }
            else if (generatedArray[mid] < target)
            {
                right = mid - 1; // array is descending
            }
            else
            {
                left = mid + 1;
            }
        }

        if (customIndex != -1)
            Console.WriteLine($"[Custom Binary Search] Element {target} found at index {customIndex}.");
        else
            Console.WriteLine($"[Custom Binary Search] Element {target} is NOT present in the array.");

        // Using Array.BinarySearch
        int arrIndex = Array.BinarySearch(generatedArray, target, new DescendingComparer());
        if (arrIndex >= 0)
            Console.WriteLine($"[Array.BinarySearch] Element {target} found at index {arrIndex}.");
        else
            Console.WriteLine($"[Array.BinarySearch] Element {target} is NOT present in the array.");
    }

    static void Task6()
    {
        Console.Clear();
        Console.WriteLine("=== Task 6: Matrix generation and sum calculations ===\n");
        
        int rows = ReadInt("Enter number of rows: ", 1, 100);
        int cols = ReadInt("Enter number of columns: ", 1, 100);

        matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(-50, 51);
            }
        }

        Console.WriteLine("\nGenerated Matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],4} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        int targetRow = ReadInt($"Enter row index to sum (0 to {rows - 1}): ", 0, rows - 1);
        int targetCol = ReadInt($"Enter column index to sum (0 to {cols - 1}): ", 0, cols - 1);

        long rowSum = 0;
        for (int j = 0; j < cols; j++) rowSum += matrix[targetRow, j];

        long colSum = 0;
        for (int i = 0; i < rows; i++) colSum += matrix[i, targetCol];

        Console.WriteLine($"\nSum of elements in row {targetRow}: {rowSum}");
        Console.WriteLine($"Sum of elements in col {targetCol}: {colSum}");
    }

    static void Task7()
    {
        Console.Clear();
        Console.WriteLine("=== Task 7: Min and Max in matrix using Math methods ===\n");
        if (matrix == null || matrix.Length == 0) { Console.WriteLine("Please generate matrix in Task 6 first."); return; }

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int min = matrix[0, 0], minR = 0, minC = 0;
        int max = matrix[0, 0], maxR = 0, maxC = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int current = matrix[i, j];

                int tempMin = Math.Min(min, current);
                if (tempMin < min)
                {
                    min = tempMin;
                    minR = i; minC = j;
                }

                int tempMax = Math.Max(max, current);
                if (tempMax > max)
                {
                    max = tempMax;
                    maxR = i; maxC = j;
                }
            }
        }

        Console.WriteLine($"Minimum element: {min} at [Row {minR}, Col {minC}]");
        Console.WriteLine($"Maximum element: {max} at [Row {maxR}, Col {maxC}]");
    }

    static void Task8()
    {
        Console.Clear();
        Console.WriteLine("=== Task 8: Roots of nonlinear equation (Bisection method) ===\n");
        Console.WriteLine("Equation: 6x^4 - 3x^3 + 8x^2 - 25 = 0\n");

        double epsilon = 1e-6;
        Console.WriteLine($"Scanning domain [-10, 10] with epsilon = {epsilon}...\n");
        
        int rootsFound = 0;
        for (double x = -10; x <= 10; x += 0.05)
        {
            double a = x;
            double b = x + 0.05;
            double fa = EquationF(a);
            double fb = EquationF(b);

            if (fa * fb <= 0)
            {
                double root = Bisection(a, b, epsilon);
                Console.WriteLine($"Found root: x = {root:F6}");
                Console.WriteLine($"Verification: F({root:F6}) = {EquationF(root):F10}\n");
                rootsFound++;
            }
        }

        if (rootsFound == 0) Console.WriteLine("No roots found in [-10, 10].");
    }

    static void Task9()
    {
        Console.Clear();
        Console.WriteLine("=== Task 9: String operations ===\n");

        Console.Write("Enter initial string: ");
        string text = Console.ReadLine() ?? "";

        // Find
        Console.Write("\nEnter substring to search for: ");
        string searchStr = Console.ReadLine() ?? "";
        int searchIdx = CustomIndexOf(text, searchStr);
        if (searchIdx != -1)
            Console.WriteLine($"Substring found at index {searchIdx}.");
        else
            Console.WriteLine("Substring not found.");

        // Replace
        Console.Write("\nEnter substring to replace: ");
        string replaceOld = Console.ReadLine() ?? "";
        Console.Write("Enter new substring to replace with: ");
        string replaceNew = Console.ReadLine() ?? "";
        string afterReplace = CustomReplaceAll(text, replaceOld, replaceNew);
        Console.WriteLine($"After Replace: {afterReplace}");
        text = afterReplace;

        // Insert
        Console.Write("\nEnter substring to insert: ");
        string insertStr = Console.ReadLine() ?? "";
        int insertIdx = ReadInt($"Enter index to insert at (0 to {text.Length}): ", 0, text.Length);
        string afterInsert = CustomInsert(text, insertIdx, insertStr);
        Console.WriteLine($"After Insert: {afterInsert}");
        text = afterInsert;

        // Delete
        Console.Write("\nEnter substring to delete: ");
        string deleteStr = Console.ReadLine() ?? "";
        string afterDelete = CustomRemove(text, deleteStr);
        Console.WriteLine($"After Delete: {afterDelete}");
        text = afterDelete;

        Console.WriteLine($"\nFinal string: {text}");
    }

    #endregion

    #region Helper methods

    static void PrintArray(int[] arr)
    {
        if (arr == null || arr.Length == 0) Console.WriteLine("Array is empty.");
        else Console.WriteLine(string.Join(", ", arr));
    }

    static void QuickSortDescending(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QuickSortDescending(arr, left, pivot - 1);
            QuickSortDescending(arr, pivot + 1, right);
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivotValue = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (arr[j] >= pivotValue)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int t = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = t;
        return i + 1;
    }

    class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    static double EquationF(double x)
    {
        return 6 * Math.Pow(x, 4) - 3 * Math.Pow(x, 3) + 8 * Math.Pow(x, 2) - 25;
    }

    static double Bisection(double a, double b, double epsilon)
    {
        while ((b - a) / 2.0 > epsilon)
        {
            double mid = (a + b) / 2.0;
            if (EquationF(mid) == 0.0) return mid;

            if (EquationF(a) * EquationF(mid) < 0)
                b = mid;
            else
                a = mid;
        }
        return (a + b) / 2.0;
    }

    static int CustomIndexOf(string source, string target, int startIndex = 0)
    {
        if (string.IsNullOrEmpty(target) || source.Length == 0) return -1;
        for (int i = startIndex; i <= source.Length - target.Length; i++)
        {
            bool match = true;
            for (int j = 0; j < target.Length; j++)
            {
                if (source[i + j] != target[j])
                {
                    match = false;
                    break;
                }
            }
            if (match) return i;
        }
        return -1;
    }

    static string CustomReplaceAll(string source, string oldStr, string newStr)
    {
        if (string.IsNullOrEmpty(oldStr)) return source;
        string result = "";
        int i = 0;
        while (i < source.Length)
        {
            int matchIdx = CustomIndexOf(source, oldStr, i);
            if (matchIdx == i)
            {
                result += newStr;
                i += oldStr.Length;
            }
            else
            {
                result += source[i];
                i++;
            }
        }
        return result;
    }

    static string CustomInsert(string source, int idx, string insertStr)
    {
        string result = "";
        for(int i=0; i<source.Length; i++)
        {
            if (i == idx) result += insertStr;
            result += source[i];
        }
        if (idx == source.Length) result += insertStr;
        return result;
    }

    static string CustomRemove(string source, string target)
    {
        return CustomReplaceAll(source, target, "");
    }

    static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result))
            {
                if (result >= min && result <= max)
                    return result;
                else
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

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

    #endregion
}