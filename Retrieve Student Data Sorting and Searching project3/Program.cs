using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = ReadStudentData("C:\\Users\\kshiv\\Downloads\\StudentData2.txt");


        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Display all students");
            Console.WriteLine("2. Search for a student by name");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayStudents(students);
                    break;

                case "2":
                    Console.Write("Enter the student's name to search: ");
                    string searchName = Console.ReadLine();
                    SearchStudentByName(students, searchName);
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static List<Student> ReadStudentData(string filename)
    {
        List<Student> students = new List<Student>();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',').Select(p => p.Trim()).ToArray();
                if (parts.Length == 2)
                {
                    students.Add(new Student(parts[0], parts[1]));
                }
            }
        }

        return students.OrderBy(s => s.Name).ToList();
    }

    static void DisplayStudents(List<Student> students)
    {
        Console.WriteLine("Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}, {student.Class}");
        }
    }

    static void SearchStudentByName(List<Student> students, string name)
    {
        var results = students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

        if (results.Count > 0)
        {
            Console.WriteLine("Search results:");
            foreach (var student in results)
            {
                Console.WriteLine($"{student.Name}, {student.Class}");
            }
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}

class Student
{
    public string Name { get; set; }
    public string Class { get; set; }

    public Student(string name, string studentClass)
    {
        Name = name;
        Class = studentClass;
    }
}
