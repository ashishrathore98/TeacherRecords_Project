using System;
using System.Collections.Generic;
using System.IO;

public class TeacherDataProcessor
{
    private const string FilePath = "@\"D:\\SimpliLearn Course\\Day19\\teachers.txt.txt\"";

    public static void SaveTeachers(List<Teacher> teachers)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var teacher in teachers)
                {
                    writer.WriteLine(teacher.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while saving teacher data: " + ex.Message);
        }
    }

    public static List<Teacher> LoadTeachers()
    {
        List<Teacher> teachers = new List<Teacher>();
        try
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        if (data.Length == 3)
                        {
                            int id = int.Parse(data[0]);
                            string name = data[1];
                            string classSection = data[2];

                            Teacher teacher = new Teacher { ID = id, Name = name, ClassSection = classSection };
                            teachers.Add(teacher);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while loading teacher data: " + ex.Message);
        }

        return teachers;
    }
}
