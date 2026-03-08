using System;
using System.IO;

namespace Task.Models;

public partial class Student
{
    public partial class DiplomaProject
    {
        public void SelectTopic(string filePath)
        {
            Console.Write("Enter keywords to search for a topic: ");
            string keywords = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(keywords))
            {
                Console.WriteLine("Keywords cannot be empty.");
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Topics file not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            bool topicFound = false;

            foreach (string line in lines)
            {
                if (line.Contains(keywords, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Selected topic: {line}");
                    Topic = line;
                    topicFound = true;
                    break;
                }
            }

            if (!topicFound)
            {
                Console.WriteLine("No topic found containing the given keywords.");
            }
        }
    }
}
