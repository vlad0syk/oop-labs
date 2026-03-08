using System;
using System.IO;

namespace Task.Models;  

public class Teacher
{
    private string teacherName;
    private string teachingLoadHours;
    private string subject;
    private int amountOfStudents;

    public string TeacherName   
    {
        get => teacherName; 
        set => teacherName = value; 
    }
    public string TeachingLoadHours 
    {
        get => teachingLoadHours; 
        set => teachingLoadHours = value; 
    }
    public string Subject 
    {
        get => subject; 
        set => subject = value; 
    }
    public int AmountOfStudents 
    {
        get => amountOfStudents; 
        set => amountOfStudents = value; 
    }

    public Teacher()
    {
        teacherName = string.Empty;
        teachingLoadHours = string.Empty;
        subject = string.Empty;
        amountOfStudents = 0;
    }

    public Teacher(string teacherName, string teachingLoadHours, string subject, int amountOfStudents)
    {
        this.teacherName = teacherName;
        this.teachingLoadHours = teachingLoadHours;
        this.subject = subject;
        this.amountOfStudents = amountOfStudents;
    }

    public void ReadFromConsole()
    {
        Console.Write("Enter Teacher Name: ");
        TeacherName = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Teaching Load Hours: ");
        TeachingLoadHours = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Subject: ");
        Subject = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Amount of Students: ");
        if (int.TryParse(Console.ReadLine(), out int parsedAmount)) AmountOfStudents = parsedAmount;
    }

    public void WriteToConsole()
    {
        Console.WriteLine($"Teacher: {TeacherName}");
        Console.WriteLine($"Teaching Load Hours: {TeachingLoadHours}");
        Console.WriteLine($"Subject: {Subject}");
        Console.WriteLine($"Amount of Students: {AmountOfStudents}");
    }

    public void WriteToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"Teacher: {TeacherName}, Teaching Load Hours: {TeachingLoadHours}, Subject: {Subject}, Amount of Students: {AmountOfStudents}");
        }
    }

    public void RecordInfoToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"Name: {TeacherName}, Load: {TeachingLoadHours}, Course: {Subject}, Enrolled: {AmountOfStudents}");
        }
    }

    public void IncreaseStudents(int count)
    {
        if (count > 0)
        {
            AmountOfStudents += count;
            
            if (int.TryParse(TeachingLoadHours, out int currentLoad))
            {
                TeachingLoadHours = (currentLoad + count * 2).ToString(); 
            }
        }
    }

    public void DecreaseStudents(int count)
    {
        if (count > 0 && AmountOfStudents >= count)
        {
            AmountOfStudents -= count;
            
            if (int.TryParse(TeachingLoadHours, out int currentLoad))
            {
                TeachingLoadHours = Math.Max(0, currentLoad - count * 2).ToString(); 
            }
        }
    }
}