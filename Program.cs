using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Teacher> teachers = TeacherDataManagement.LoadTeacherData();

        while (true)
        {
            Console.WriteLine("Teacher Data Management");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Update Teacher");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddTeacher(teachers);
                        break;
                    case 2:
                        UpdateTeacher(teachers);
                        break;
                    case 3:
                        TeacherDataManagement.SaveTeacherData(teachers);
                        Console.WriteLine("Data saved successfully. Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
            }

            Console.WriteLine();
        }
    }

    static void AddTeacher(List<Teacher> teachers)
    {
        Console.Write("Enter teacher ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format. Teacher not added.");
            return;
        }

        Console.Write("Enter teacher Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter teacher Class and Section: ");
        string classSection = Console.ReadLine();

        teachers.Add(new Teacher
        {
            ID = id,
            Name = name,
            ClassSection = classSection
        });

        Console.WriteLine("Teacher added successfully.");
    }

    static void UpdateTeacher(List<Teacher> teachers)
    {
        Console.Write("Enter teacher ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format. Update failed.");
            return;
        }

        Console.Write("Enter new teacher Name: ");
        string newName = Console.ReadLine();

        Console.Write("Enter new teacher Class and Section: ");
        string newClassSection = Console.ReadLine();

        TeacherDataManagement.UpdateTeacherData(teachers, id, newName, newClassSection);

        Console.WriteLine("Teacher data updated successfully.");
    }
}
