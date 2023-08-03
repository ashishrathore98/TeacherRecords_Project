using System;
using System.Collections.Generic;
using System.IO;

public class TeacherDataManagement
{
    private const string DataFilePath = "teachers.txt";

    public static void SaveTeacherData(List<Teacher> teachers)
    {
        using (StreamWriter writer = new StreamWriter(@"D:\SimpliLearn Course\Day19\teachers.txt.txt"))
        {
            foreach (var teacher in teachers)
            {
                writer.WriteLine($"{teacher.ID},{teacher.Name},{teacher.ClassSection}");
            }
        }
    }

    public static List<Teacher> LoadTeacherData()
    {
        List<Teacher> teachers = new List<Teacher>();

        if (File.Exists(DataFilePath))
        {
            using (StreamReader reader = new StreamReader(DataFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 3 && int.TryParse(data[0], out int id))
                    {
                        teachers.Add(new Teacher
                        {
                            ID = id,
                            Name = data[1],
                            ClassSection = data[2]
                        });
                    }
                }
            }
        }

        return teachers;
    }

    public static void UpdateTeacherData(List<Teacher> teachers, int teacherId, string newName, string newClassSection)
    {
        Teacher teacherToUpdate = teachers.Find(t => t.ID == teacherId);
        if (teacherToUpdate != null)
        {
            teacherToUpdate.Name = newName;
            teacherToUpdate.ClassSection = newClassSection;
        }
    }
}
