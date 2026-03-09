using System;
using System.IO;
using Task.Models;

namespace Task
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Greeting();
            Console.WriteLine("=== Testing Teacher Class ===");
            Teacher teacher = new Teacher("John Doe", "10", "Computer Science", 30);
            teacher.WriteToConsole();
            
            Console.WriteLine("\nTesting Teacher method IncreaseStudents(+5):");
            teacher.IncreaseStudents(5);
            teacher.WriteToConsole();

            Console.WriteLine("\nTesting Teacher method DecreaseStudents(-10):");
            teacher.DecreaseStudents(10);
            teacher.WriteToConsole();

            string teacherFile = "teacher_data.txt";
            teacher.RecordInfoToFile(teacherFile);
            Console.WriteLine($"\nTeacher info recorded to {teacherFile}");


            Console.WriteLine("\n=== Testing Student Class ===");
            Student student = new Student("Jane", "Smith", "123 Main St", "AB123456", 20, "555-0100", 0);
            student.WriteToConsole();

            Console.WriteLine("\nTesting Student method CalculateRating():");
            student.CalculateRating(); 

            string studentFile = "student_data.txt";
            student.RecordRatingToFile(studentFile);
            Console.WriteLine($"\nStudent rating recorded to {studentFile}");


            Console.WriteLine("\n=== Testing DiplomaProject Class ===");
            Student.DiplomaProject project = new Student.DiplomaProject 
            { 
                ImplementedAlgorithms = 3, 
                TopicComplexity = 4 
            };
            
            string topicsFile = "topics.txt";
            File.WriteAllLines(topicsFile, new string[] { 
                "Machine Learning in Healthcare", 
                "Blockchain for Supply Chain", 
                "Web Application Security", 
                "AI Chatbot Implementation" 
            });

            Console.WriteLine($"\nCreated mock topics file: {topicsFile}");
            Console.WriteLine("Testing SelectTopic method:");
            project.SelectTopic(topicsFile);

            Console.WriteLine($"\nTesting DetermineGrade method (Algorithms: {project.ImplementedAlgorithms}, Complexity: {project.TopicComplexity}):");
            int grade = project.DetermineGrade();
            Console.WriteLine($"Calculated Grade: {grade}");


            Console.WriteLine("\n=== Testing CreativeWork Methods ===");
            Random rand = new Random();
            int n = 10;
            int[] array = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-100, 101);
            }

            Console.WriteLine("\nGenerated Array:");
            CreativeWork.PrintArray(array);

            CreativeWork.QuickSortDescending(array, 0, array.Length - 1);

            Console.WriteLine("\nArray sorted in descending order (QuickSort):");
            CreativeWork.PrintArray(array);
            
            Console.WriteLine("\n=== All Tests Completed! ===");
        }

        static void Greeting()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("     📘 Laboratory Work No. 3");
            Console.WriteLine("===========================================");
            Console.WriteLine("💻 Performed by: Vlad Sapozhnyk (8)");
            Console.WriteLine("🎓 Taras Shevchenko National University of Kyiv");
            Console.WriteLine("🏫 Group: IPZ-13, Subgroup: 6");
            Console.WriteLine("===========================================");
        }
    }
}