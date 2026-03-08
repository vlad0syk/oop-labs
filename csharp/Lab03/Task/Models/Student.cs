using System;
using System.IO;

namespace Task.Models;  

public partial class Student
{
    private string firstName; 
    private string lastName; 
    private string address;
    private string passport; 
    private int age;
    public string phoneNumber;
    public int rating;

    public string FirstName 
    {
        get => firstName;   
        set => firstName = value;
    }
    public string LastName 
    {
         get => lastName; 
         set => lastName = value;   
    }
    public string Address 
    {
         get => address; 
         set => address = value; 
    }
    public string Passport 
    {
         get => passport; 
         set => passport = value; 
    }
    public int Age 
    {
         get => age; 
         set => age = value; 
    }

    public Student()
    {
        firstName = string.Empty;
        lastName = string.Empty;
        address = string.Empty;
        passport = string.Empty;
        age = 0;
        phoneNumber = string.Empty;
        rating = 0;
    }

    public Student(string firstName, string lastName, string address, string passport, int age, string phoneNumber, int rating)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.passport = passport;
        this.age = age;
        this.phoneNumber = phoneNumber;
        this.rating = rating;
    }

    public void ReadFromConsole()
    {
        Console.Write("Enter First Name: ");
        FirstName = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Last Name: ");
        LastName = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Address: ");
        Address = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Passport: ");
        Passport = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Age: ");
        if (int.TryParse(Console.ReadLine(), out int parsedAge)) Age = parsedAge;
        Console.Write("Enter Phone Number: ");
        phoneNumber = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Rating: ");
        if (int.TryParse(Console.ReadLine(), out int parsedRating)) rating = parsedRating;
    }

    public void WriteToConsole()
    {
        Console.WriteLine($"Student: {FirstName} {LastName}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"Passport: {Passport}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Phone Number: {phoneNumber}");
        Console.WriteLine($"Rating: {rating}");
    }

    public void WriteToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"Student: {FirstName} {LastName}, Address: {Address}, Passport: {Passport}, Age: {Age}, Phone: {phoneNumber}, Rating: {rating}");
        }
    }

    public void CalculateRating()
    {
        Console.Write("Enter the number of grades: ");
        if (int.TryParse(Console.ReadLine(), out int numGrades) && numGrades > 0)
        {
            int sum = 0;
            for (int i = 0; i < numGrades; i++)
            {
                Console.Write($"Enter grade {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int grade))
                {
                    sum += grade;
                }
                else
                {
                    Console.WriteLine("Invalid input. Grade will be counted as 0.");
                }
            }
            rating = sum / numGrades;
            Console.WriteLine($"Calculated average rating: {rating}");
        }
        else
        {
            Console.WriteLine("Invalid number of grades.");
        }
    }

    public void RecordRatingToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{FirstName} {LastName} - Rating: {rating}");
        }
    }

    public partial class DiplomaProject
    {
        public string Topic { get; set; } = string.Empty;
        public int ImplementedAlgorithms { get; set; }
        public int TopicComplexity { get; set; }

        public int DetermineGrade()
        {
            // Example grade calculation logic based on algorithms and complexity
            // Assuming base grade of 50, +10 for each algorithm, and +5 for each complexity level (up to max 100)
            int calculatedGrade = 50 + (ImplementedAlgorithms * 10) + (TopicComplexity * 5);
            return Math.Min(100, Math.Max(0, calculatedGrade));
        }
    }
}