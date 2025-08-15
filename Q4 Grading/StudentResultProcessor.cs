using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment3.Question4_Grading
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using (var reader = new StreamReader(inputFilePath))
            {
                string line;
                int lineNumber = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');

                    if (parts.Length != 3)
                        throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields but found {parts.Length}.");

                    if (!int.TryParse(parts[0].Trim(), out int id))
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format.");

                    string fullName = parts[1].Trim();
                    if (string.IsNullOrWhiteSpace(fullName))
                        throw new MissingFieldException($"Line {lineNumber}: Missing full name.");

                    if (!int.TryParse(parts[2].Trim(), out int score))
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Score is not a valid integer.");

                    if (score < 0 || score > 100)
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Score must be between 0 and 100.");

                    students.Add(new Student(id, fullName, score));
                    lineNumber++;
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine(student.ToString());
                }
            }
        }
    }
}
